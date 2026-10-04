using System.ComponentModel;
using TMPro;
using UnityEngine;
using UnityEngine.Profiling;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

// the main brain of the game, handles gravity flipping, win/lose screens,
// pause menu, blur effect, cursor stuff... basically a bit of everything lol
public class GameManager : MonoBehaviour
{
    private bool isFlipped; // keeps track of which way gravity is currently pointing
    [HideInInspector] public bool invertControls;   // flips controls too when gravity flips (set from elsewhere)
    [HideInInspector] public bool isPlayerCollided; // set to true when the player hits something they shouldn't
    public float gravitationForce = 50f;    // how strong gravity is, 50 is the default

    public TextMeshProUGUI levelText;   // text that shows the current level name on screen
    public Volume volume;   // the post processing volume, used for the blur effect

    private UIManager m_UIManager;  // grabbed at runtime, handles the ui panels
    private DepthOfField m_Dof; // the blur component we pull out of the volume


    private void Awake()
    {
        // hide the cursor at startup, this is a gameplay scene after all
        EnableCursor(false);
    }

    private void Start()
    {
        // find the ui manager in the scene
        m_UIManager = FindObjectOfType<UIManager>();

        // if there's no level text in this scene just bail out early
        if (!levelText) return;

        // show the scene name on the level text
        SceneName(levelText);
    }

    // flips gravity on the player, called when they hit a flip zone or whatever
    public void FlipGravity(Rigidbody2D rb)
    {
        // toggle the flip state and set gravity to negative or positive accordingly
        isFlipped = !isFlipped;
        rb.gravityScale = isFlipped ? -gravitationForce : gravitationForce;
    }

    // called when the player reaches the end of the level
    public void GameOver()
    {
        // turn off movement controls, show the "cleared" panel, unlock cursor
        GameInputManager.Instance.DisableControls();

        m_UIManager.EnableGamePanel($"{SceneManager.GetActiveScene().name} Cleared");

        // switch input over to ui mode so they can click buttons
        GameInputManager.Instance.EnableUIControls(false);
        EnableCursor(true);
    }

    // called when the player dies
    public void PlayerDead(Rigidbody2D playerRB)
    {
        // hide the player, flag the collision, show the "failed" panel
        playerRB.gameObject.SetActive(false);
        isPlayerCollided = true;

        m_UIManager.EnableGamePanel($"{SceneManager.GetActiveScene().name} Failed");

        GameInputManager.Instance.EnableUIControls(false);
        EnableCursor(true);
    }

    // just reloads the current scene, simple as that
    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    // goes back to the first scene (main menu probably)
    public void ExitScene()
    {
        SceneManager.LoadScene("First");
    }

    // shows/hides the pause menu, isPaused tells it which one to do
    public void PauseGame(bool isPaused)
    {
        if(isPaused)
        {
            m_UIManager.EnablePauseMenu();
            // paused so we need the cursor back for clicking buttons
            EnableCursor(true);
        }
        else
        {
            m_UIManager.DisablePauseMenu();
            // back to the game, hide the cursor again
            EnableCursor(false);
        }
    }

    // just writes the current scene name into whatever text you give it
    void SceneName(TextMeshProUGUI text)
    {
        text.text = SceneManager.GetActiveScene().name;
    }

    // shows or hides the cursor (and locks/unlocks it)
    // also toggles the blur at the same time, they go hand in hand here
    public void EnableCursor(bool enable)
    {
        Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = enable;

        EnableBlur(enable);
    }

    // turns the depth of field blur on/off, gives that nice "menu is in focus" look
    void EnableBlur(bool blur)
    {
        // try to grab the dof component from the volume profile
        volume.profile.TryGet<DepthOfField>(out m_Dof);

        if(blur && m_Dof != null)
        {
            // blur on with a tiny focus distance so basically everything is blurry
            m_Dof.active = true;
            m_Dof.focusDistance.value = 0.1f;
        }
        else
        {
            m_Dof.active = false;
        }
    }

    // little helper to turn objects back on, someone else turns them off somewhere
    public void ReActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
