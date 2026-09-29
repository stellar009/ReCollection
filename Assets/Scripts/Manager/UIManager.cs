using TMPro;
using UnityEngine;

public class UIManager : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject gamePanel;
    public TextMeshProUGUI gamePanelText;
    public GameObject pauseMenu;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        DisablePanel(gamePanel);
        DisablePanel(pauseMenu);
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
        GameInputManager.Instance.DisableControls();
    }

    void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        GameInputManager.Instance.EnableControls();
    }

    public void EnablePauseMenu()
    {
        EnablePanel(pauseMenu);
    }

    public void DisablePauseMenu()
    {
        DisablePanel(pauseMenu);
    }
}
