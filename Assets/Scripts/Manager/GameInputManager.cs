using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance;

    private GameInputs m_GameInputs;
    private GameManager m_GameManager;

    public float movement {  get; private set; }
    public bool isPaused { get; private set; }

    private void Awake()
    {
        if(!Instance)
        {
            Instance = this;
        }

        m_GameInputs = new GameInputs();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnEnable()
    {
        m_GameInputs.Player.Enable();
        m_GameInputs.UI.Enable();

        m_GameInputs.Player.Movement.performed += Movement;

        m_GameInputs.UI.Pause.performed += PauseGame;
    }

    private void OnDisable()
    {
        m_GameInputs.Player.Disable();
        m_GameInputs.UI.Disable();

        m_GameInputs.Player.Movement.performed -= Movement;

        m_GameInputs.UI.Pause.performed -= PauseGame;
    }

    void Movement(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<float>();
    }

    void PauseGame(InputAction.CallbackContext ctx)
    {
        isPaused = !isPaused;
        m_GameManager.PauseGame(isPaused);
    }

    public void DisableControls()
    {
        m_GameInputs.Player.Disable();
    }

    public void EnableControls()
    {
        m_GameInputs.Player.Enable();
    }
}
