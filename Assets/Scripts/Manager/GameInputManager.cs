using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance;

    private GameInputs m_GameInputs;
    private GameManager m_GameManager;

    public float movement {  get; private set; }

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

        m_GameInputs.Player.Movement.performed += Movement;
    }

    private void OnDisable()
    {
        m_GameInputs.Player.Disable();

        m_GameInputs.Player.Movement.performed -= Movement;
    }

    void Movement(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<float>();
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
