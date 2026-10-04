using UnityEngine;

// touch it and suddenly left is right and right is left lol
public class ControlInversion : MonoBehaviour
{
    // the sound that plays when controls get flipped 
    public AudioClip ctrlShift;

    // gamemanager reference — that's where invertControls lives
    private GameManager m_GameManager;
    //AudioSource reference
    private AudioSource m_AudioSrc;

    // grab references at scene start
    void Start()
    {
        // find the game manager in the scene
        m_GameManager = FindObjectOfType<GameManager>();
        // grab the audio source
        m_AudioSrc = FindFirstObjectByType<AudioSource>();
    }

    // runs when something bumps into this
    private void OnCollisionEnter2D(Collision2D collision)
    {
        // only care if it's the player
        if (collision.collider.CompareTag("Player"))
        {
            // play the "controls flipped" sound
            m_AudioSrc.PlayOneShot(ctrlShift);

            // toggle the invert flag — game manager holds it, player script reads it
            m_GameManager.invertControls = !m_GameManager.invertControls;

            // bring this object back in 4 seconds (in theory lol, see below)
            Invoke(nameof(Reactivation), 4f);

            // hide this object so the player can't re-trigger it instantly
            gameObject.SetActive(false);
        }
    }

    // turns this game object back on
    void Reactivation()
    {
        // ask the game manager to do it since we might be asleep
        m_GameManager.ReActivateObject(gameObject);
    }
}
