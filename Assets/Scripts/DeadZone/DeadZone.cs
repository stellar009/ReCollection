using UnityEngine;

// the kill zone — if the player falls or touches this, they die
public class DeadZone : MonoBehaviour
{
    private GameManager m_GameManager;  // the game manager, needed to trigger the death

    // grab the game manager at scene start
    private void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // when something touches the dead zone...
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // ...and it's actually the player, then it's game over for them lol
        if (collision.collider.CompareTag("Player"))
        {
            m_GameManager.PlayerDead(collision.collider.GetComponent<Rigidbody2D>());
        }
    }
}
