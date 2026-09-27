using UnityEngine;
using UnityEngine.SceneManagement;

public class TutorialManager : MonoBehaviour
{
    private GameManager m_GameManager;

    [Header("UI Settimgs")]
    public GameObject infoPanel;
    public GameObject gameOverPanel;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisablePanel(gameOverPanel);
        m_GameManager = FindObjectOfType<GameManager>();
        EnablePanel(infoPanel);
    }

    private void Update()
    {
        EnableGameOverPanel();
    }

    public void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
        GameInputManager.Instance.DisableControls();
    }

    public void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        GameInputManager.Instance.EnableControls();
    }

    void EnableGameOverPanel()
    {
        if(m_GameManager.isPlayerCollided)
        {
            EnablePanel(gameOverPanel);
        }
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
