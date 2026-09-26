using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;
    private GameManager m_GameManager;

    [Header("Player Settings")]
    public float speed = 5f;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();
    }

    void PlayerMovement()
    {
        m_Rigidbody.linearVelocity = new Vector2(GameInputManager.Instance.movement * speed, m_Rigidbody.position.y);
    }
}
