using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;
using static TMPro.SpriteAssetUtilities.TexturePacker_JsonArray;

// handles the studio logos / branding screens that show up when the game boots up
// shows each panel one by one then loads the next scene once the sequence is done
public class BrandManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject[] panels;     // the logo panels (like studio logo, engine logo etc)
    public float sequenceDelay = 2f;    // how long each panel stays on screen

    [Header("Optimizations")]
    [SerializeField] private ShaderVariantCollection m_ShaderVariantCollection; // prewarms shaders so no stuttering later

    private WaitForSeconds delay;   // cached so we don't create a new one every frame (saves garbage)
    private int panelsLength;   // just panels.Length stored so we don't call it in loops repeatedly
    private float totalDelay;   // total time the whole logo sequence takes
    private float timer;     // counts up so we know when the sequence is finished


    private void Awake()
    {
        // turn vSync on so the frame rate is capped nicely, no weird tearing
        QualitySettings.vSyncCount = 1;

        // SRP batching = faster rendering when using URP/HDRP, basically free performance
        GraphicsSettings.useScriptableRenderPipelineBatching = true;

        // warm up shaders now while we're on the loading screen
        // so the game doesn't hitch later when it actually needs them
        m_ShaderVariantCollection.WarmUp();
    }

    // runs once at the start
    void Start()
    {
        // cache the delay once, reusing it in the coroutine instead of making new ones
        delay = new WaitForSeconds(sequenceDelay);

        panelsLength = panels.Length;

        // total time = number of panels x time per panel (math lol)
        totalDelay = panelsLength * sequenceDelay;

        // hide all panels first, we'll turn them on one at a time
        for (int i = 0; i < panelsLength; i++)
        {
            panels[i].SetActive(false);
        }

        // kick off both coroutines, one shows logos, the other preloads the next scene
        StartCoroutine(BrandingSequence());
        StartCoroutine(LoadSceneInBackground());
    }

    // shows each panel one by one with the delay between them
    // (panel 1 shows, wait 2 sec, panel 2 shows, wait, etc)
    IEnumerator BrandingSequence()
    {
        for (int i = 0; i < panelsLength; i++)
        {
            panels[i].SetActive(true);
            yield return delay;
        }
    }

    // loads the next scene in the background while the logos are playing
    // but doesn't actually switch to it until the sequence is done
    IEnumerator LoadSceneInBackground()
    {
        // start loading the next scene in the build order
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        // hold the scene back for now, we decide when it's allowed to activate
        operation.allowSceneActivation = false;

        // keep looping until the scene fully loads in
        while (!operation.isDone)
        {
            timer += Time.deltaTime;

            // progress stops at 0.9 when activation is blocked (unity quirk)
            // so if it's done loading AND the logos finished playing, let it go
            if (operation.progress >= 0.9f && timer > totalDelay)
            {
                operation.allowSceneActivation = true;
            }
            yield return null; // wait a frame then check again
        }
    }
}
