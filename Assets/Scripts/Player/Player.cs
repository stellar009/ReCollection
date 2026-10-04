using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;    
    private GameManager m_GameManager;  

    [Header("Player Settings")]
    public float speed = 5f;    

    private float m_PlayerMovement; 


    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        if (GameInputManager.Instance.isPaused)
        {
            m_Rigidbody.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            m_Rigidbody.bodyType = RigidbodyType2D.Dynamic;
        }

        m_PlayerMovement = m_GameManager.invertControls ? -GameInputManager.Instance.movement : GameInputManager.Instance.movement;

        m_Rigidbody.linearVelocity = new Vector2(m_PlayerMovement * speed, m_Rigidbody.position.y);
    }
}
