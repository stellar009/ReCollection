using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

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
            DontDestroyOnLoad(gameObject);
        }

        m_GameInputs = new GameInputs();
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

    void InvertMovement(InputAction.CallbackContext ctx)
    {
        movement = ctx.ReadValue<float>();
    }

    public void InvertControl()
    {
        m_GameInputs.Player.MovementInverted.Enable();
        m_GameInputs.Player.MovementInverted.performed += InvertMovement;
    }

    public void RevertControl()
    {
        m_GameInputs.Player.MovementInverted.Disable();
        m_GameInputs.Player.MovementInverted.performed -= InvertMovement;
    }
}
