using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private GameManager m_GameManager;
    private SpriteRenderer m_SpriteRenderer;

    [Header("Player Settings")]
    public float speed = 5f;

    private float m_PlayerMovement;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_SpriteRenderer = GetComponent<SpriteRenderer>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if(GameInputManager.Instance.movement == 1)
        {
            m_SpriteRenderer.flipX = false;
        }
        else if(GameInputManager.Instance.movement == -1)
        {
            m_SpriteRenderer.flipX = true;
        }

        m_PlayerMovement = m_GameManager.invertControls ? -GameInputManager.Instance.movement : GameInputManager.Instance.movement;

        m_Rigidbody.linearVelocity = new Vector2(m_PlayerMovement * speed, m_Rigidbody.position.y);
    }
}
