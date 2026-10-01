using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform spawnPoint;
    public AudioClip tpAudio;

    private AudioSource m_AudioSource;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawnPoint == null) Debug.Log("No Spawn Point");
        m_AudioSource = FindFirstObjectByType<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            m_AudioSource.PlayOneShot(tpAudio);

            MoveObject(collision.collider.gameObject, spawnPoint);

            gameObject.SetActive(false);
        }
    }

    void MoveObject(GameObject gameObject, Transform target)
    {
        gameObject.SetActive(false);
        gameObject.transform.position = target.position;
        gameObject.SetActive(true);
    }
}
