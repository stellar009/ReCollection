using UnityEngine;

// a portal — teleports the player to a spawn point when they touch it
// also plays a little sound and disappears for a bit before coming back
public class Portals : MonoBehaviour
{
    public Transform spawnPoint;    // where the player gets teleported to
    public AudioClip tpAudio;   // the teleport sound effect

    private GameManager m_GameManager;
    private AudioSource m_AudioSource;

    // grab references and warn if the spawn point wasn't set
    void Start()
    {
        // forgot to set the spawn point in the inspector? yell about it
        if (spawnPoint == null) Debug.Log("No Spawn Point");
        m_AudioSource = FindFirstObjectByType<AudioSource>();
        m_GameManager = FindObjectOfType<GameManager>();
    }

    // when the player bumps into the portal
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            // play the tp sound
            m_AudioSource.PlayOneShot(tpAudio);

            // teleport the player to the spawn point
            MoveObject(collision.collider.gameObject, spawnPoint);

            // schedule the portal to come back in 4 seconds
            Invoke(nameof(Reactivation), 4f);

            // hide the portal for now
            gameObject.SetActive(false);
        }
    }

    // teleports an object to a target position
    // does the turn off -> move -> turn on dance so it's a clean teleport
    void MoveObject(GameObject gameObject, Transform target)
    {
        gameObject.SetActive(false);
        gameObject.transform.position = target.position;
        gameObject.SetActive(true);
    }

    // called by Invoke after 4 seconds
    void Reactivation()
    {
        m_GameManager.ReActivateObject(gameObject);
    }
}
