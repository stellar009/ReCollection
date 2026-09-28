using TMPro;
using UnityEngine;

public class TutorialManager : MonoBehaviour
{
    private GameManager m_GameManager;

    [Header("UI Settimgs")]
    public GameObject infoPanel;
    public GameObject gameOverPanel;

    public TextMeshProUGUI m_Tmp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisablePanel(gameOverPanel);
        m_GameManager = FindObjectOfType<GameManager>();
        EnablePanel(infoPanel);
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

    public void EnableGameOverPanel(string gameOverText, Color textColor = default)
    {
        m_Tmp.color = textColor;
        m_Tmp.text = gameOverText;
        EnablePanel(gameOverPanel);
    }
}
