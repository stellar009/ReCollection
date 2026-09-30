using UnityEngine;

public class ControlInversion : MonoBehaviour
{
    public AudioClip ctrlShift;

    private GameManager m_GameManager;
    private AudioSource m_AudioSrc;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_AudioSrc = FindObjectOfType<AudioSource>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            m_AudioSrc.PlayOneShot(ctrlShift);
            m_GameManager.invertControls = !m_GameManager.invertControls;
            gameObject.SetActive(false);
        }
    }
}
