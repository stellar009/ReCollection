using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject gamePanel;
    public TextMeshProUGUI gamePanelText;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisablePanel(gamePanel);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void EnableGamePanel(string text, Color textColor = default)
    {
        gamePanelText.text = text;
        gamePanelText.color = textColor;
        EnablePanel(gamePanel);
    }

    void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
    }

    void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
    }
}
