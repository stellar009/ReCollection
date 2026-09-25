using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [HideInInspector]public bool isFlipped;
    [HideInInspector]public bool invertControls;

    private void Awake()
    {

    }

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // Application.targetFrameRate = maxFrameRate;

        QualitySettings.vSyncCount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void FlipGravity()
    {
        isFlipped = !isFlipped;
        Physics2D.gravity = new Vector2(0f, isFlipped ? 25 : -25);
    }

    public void InvertControls()
    {
        if(!invertControls)
        {
            invertControls = true;
            GameInputManager.Instance.InvertControl();
        }
        else
        {
            invertControls = false;
            GameInputManager.Instance.RevertControl();
        }
    }

    public void GameOver()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
