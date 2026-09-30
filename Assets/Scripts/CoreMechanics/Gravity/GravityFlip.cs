using UnityEngine;

public class GravityFlip : MonoBehaviour
{
    public AudioClip gravityShift;

    private GameManager m_GameManager;
    private AudioSource m_AudioSrc;

    private void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_AudioSrc = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_AudioSrc.PlayOneShot(gravityShift);
            m_GameManager.FlipGravity(collision.collider.attachedRigidbody);
            gameObject.SetActive(false);
        }
    }
}
