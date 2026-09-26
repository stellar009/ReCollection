using UnityEngine;
using UnityEngine.InputSystem;

public class GameInputManager : MonoBehaviour
{
    public static GameInputManager Instance;

    private GameInputs m_GameInputs;
    private GameManager m_GameManager;

    public float movement {  get; private set; }
    public float invertedMovement { get; private set; }

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

    void InvertedMovement(InputAction.CallbackContext ctx)
    {
        invertedMovement = ctx.ReadValue<float>();
    }

    private void Update()
    {
        if(m_GameManager.invertControls)
        {
            m_GameInputs.Player.MovementInverted.Enable();
            m_GameInputs.Player.MovementInverted.performed += InvertedMovement;
            m_GameInputs.Player.Movement.performed -= Movement;
        }
        else
        {
            m_GameInputs.Player.MovementInverted.Disable();
            m_GameInputs.Player.MovementInverted.performed -= InvertedMovement;
            m_GameInputs.Player.Movement.performed += Movement;

        }
    }
}
