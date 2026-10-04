using TMPro;
using UnityEngine;

// handles all the ui panels — the win/lose screen and the pause menu
// mostly just turning panels on and off plus managing controls while they're up
public class UIManager : MonoBehaviour
{
    [Header("UI Setup")]
    public GameObject gamePanel;    // the win/lose panel that shows "Level Cleared" or "Level Failed"
    public TextMeshProUGUI gamePanelText;   // the text on that panel, gets set depending on win or lose
    public GameObject pauseMenu;     // the pause menu, pretty self explanatory

    // make sure everything is hidden when the scene starts
    void Start()
    {
        DisablePanel(gamePanel);
        DisablePanel(pauseMenu);
    }

    // shows the game panel (win/lose screen) with whatever text you pass in
    // GameManager calls this with "cleared" or "failed" text
    public void EnableGamePanel(string text)
    {
        gamePanelText.text = text;
        EnablePanel(gamePanel);
    }

    // turns a panel on and kills the gameplay controls at the same time
    // (can't be running around while a menu is open lol)
    void EnablePanel(GameObject panel)
    {
        panel.SetActive(true);
        GameInputManager.Instance.DisableControls();
    }

    // opposite — hides the panel and gives the controls back
    void DisablePanel(GameObject panel)
    {
        panel.SetActive(false);
        GameInputManager.Instance.EnableControls();
    }

    // shows the pause menu
    public void EnablePauseMenu()
    {
        EnablePanel(pauseMenu);
    }

    // hides the pause menu
    public void DisablePauseMenu()
    {
        DisablePanel(pauseMenu);
    }
}
