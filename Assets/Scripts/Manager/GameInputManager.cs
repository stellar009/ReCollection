using UnityEngine;
using UnityEngine.InputSystem;

// the input guy — a singleton that reads player input and hands it out to whoever asks
// other scripts grab GameInputManager.Instance.movement etc instead of each having their own input
public class GameInputManager : MonoBehaviour
{
    // singleton instance, the one and only (that's the idea anyway lol)
    public static GameInputManager Instance;

    private GameInputs m_GameInputs;    // the generated input system class from the input actions asset
    private GameManager m_GameManager;  // needed for the pause stuff

    public float movement {  get; private set; }    // current left/right input value, player script reads this
    public bool isPaused { get; private set; }  // whether the game is currently paused

    private void Awake()
    {
        // singleton setup — if no instance exists yet, we're it
        if (!Instance)
        {
            Instance = this;
        }
        // (no else here, so if a second one shows up it just... exists lol, see note below)

        // create the input actions and find the game manager
        m_GameInputs = new GameInputs();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        // turn on both action maps, gameplay + ui
        m_GameInputs.Player.Enable();
        m_GameInputs.UI.Enable();

        // hook up the callbacks — movement reads itself into the property, pause toggles the game
        m_GameInputs.Player.Movement.performed += Movement;

        m_GameInputs.UI.Pause.performed += PauseGame;
    }

    private void OnDisable()
    {
        // unhooking everything on disable, good practice so no ghost callbacks fire later
        m_GameInputs.Player.Disable();
        m_GameInputs.UI.Disable();

        m_GameInputs.Player.Movement.performed -= Movement;

        m_GameInputs.UI.Pause.performed -= PauseGame;
    }

    // stores the movement value whenever the player presses left/right
    void Movement(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<float>();
    }

    // called when the pause button is hit — flips the pause state and tells the game manager
    void PauseGame(InputAction.CallbackContext ctx)
    {
        isPaused = !isPaused;
        Debug.Log(isPaused);    // just for debugging, can remove later
        m_GameManager.PauseGame(isPaused);
    }

    // turns the gameplay controls off (used when a menu/panel is up)
    public void DisableControls()
    {
        m_GameInputs.Player.Disable();
    }

    // turns the gameplay controls back on
    public void EnableControls()
    {
        m_GameInputs.Player.Enable();
    }

    // toggles the ui controls on/off, buttons in menus need these
    public void EnableUIControls(bool enable)
    {
        if(enable)
        {
            m_GameInputs.UI.Enable();
        }
        else
        {
            m_GameInputs.UI.Disable();
        }
    }
}
