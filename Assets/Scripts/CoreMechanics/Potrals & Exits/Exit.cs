using UnityEngine;

public class Exit : MonoBehaviour
{
    private GameManager m_GameManager;  

    // find the game manager in the scene
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            m_GameManager.GameOver();
        }
    }
}
