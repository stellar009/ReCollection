using UnityEngine;

// the player, pretty much just handles left/right movement
// (and freezes solid when the game is paused lol)
public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;    // grabbed at start, does the actual moving
    private GameManager m_GameManager;  // needed to check if controls are inverted

    [Header("Player Settings")]
    public float speed = 5f;     // how fast the player moves

    private float m_PlayerMovement; // the current movement input (after inversion is applied)


    // grab all the references we need
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // run movement every frame
    void Update()
    {
        PlayerMovement();
    }

    // handles the actual movement logic
    void PlayerMovement()
    {
        // pause check — if paused, freeze the rigidbody completely
        // (setting it to Static so gravity doesn't keep pulling it while paused)
        if (GameInputManager.Instance.isPaused)
        {
            m_Rigidbody.bodyType = RigidbodyType2D.Static;
        }
        else
        {
            // not paused, back to normal physics
            m_Rigidbody.bodyType= RigidbodyType2D.Dynamic;
        }

        // read the input, flip it if controls are inverted (for the gravity flip mechanic)
        // otherwise just use it as is
        m_PlayerMovement = m_GameManager.invertControls ? -GameInputManager.Instance.movement : GameInputManager.Instance.movement;

        // set the velocity, keep the y untouched so gravity does its thing
        m_Rigidbody.linearVelocity = new Vector2(m_PlayerMovement * speed, m_Rigidbody.position.y);
    }
}
