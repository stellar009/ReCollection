using System.Collections;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.SceneManagement;

public class BrandManager : MonoBehaviour
{
    [Header("Panels")]
    public GameObject[] panels;
    public float sequenceDelay = 2f;

    [Header("Optimizations")]
    [SerializeField] private ShaderVariantCollection m_ShaderVariantCollection;

    private WaitForSeconds delay;
    private int panelsLength;
    private float totalDelay;
    private float timer;


    private void Awake()
    {
        QualitySettings.vSyncCount = 1;

        GraphicsSettings.useScriptableRenderPipelineBatching = true;

        m_ShaderVariantCollection.WarmUp();
    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        delay = new WaitForSeconds(sequenceDelay);

        panelsLength = panels.Length;

        totalDelay = panelsLength * sequenceDelay;

        for (int i = 0; i < panelsLength; i++)
        {
            panels[i].SetActive(false);
        }

        StartCoroutine(BrandingSequence());
        StartCoroutine(LoadSceneInBackground());
    }


    IEnumerator BrandingSequence()
    {
        for (int i = 0; i < panelsLength; i++)
        {
            panels[i].SetActive(true);
            yield return delay;
        }
    }

    IEnumerator LoadSceneInBackground()
    {
        AsyncOperation operation = SceneManager.LoadSceneAsync(SceneManager.GetActiveScene().buildIndex + 1);
        operation.allowSceneActivation = false;

        while(!operation.isDone)
        {
            timer += Time.deltaTime;

            if(operation.progress >= 0.9f && timer > totalDelay)
            {
                operation.allowSceneActivation = true;
            }
            yield return null;
        }
    }
}
