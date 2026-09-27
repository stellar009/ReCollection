using UnityEngine;

public class DeadZone : MonoBehaviour
{
    private GameManager m_GameManager;

    private void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            m_GameManager.PlayerDead(collision.collider.GetComponent<Rigidbody2D>());
        }
    }
}
