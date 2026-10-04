using UnityEngine;

// the exit door / goal of the level, when the player touches it the level is cleared
public class Exit : MonoBehaviour
{
    private GameManager m_GameManager;  // reference to the game manager, grabbed at start

    // find the game manager in the scene
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // when something touches this, check if it's the player
    // if yes -> level cleared, game over (the good kind of game over lol)
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            m_GameManager.GameOver();
        }
    }
}
