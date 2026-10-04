using UnityEngine;

public class ControlInversion : MonoBehaviour
{ 
    public AudioClip ctrlShift;

    private GameManager m_GameManager;
    private AudioSource m_AudioSrc;

    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
        m_AudioSrc = FindFirstObjectByType<AudioSource>();
    }

    // runs when something bumps into this
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.CompareTag("Player"))
        {
            m_AudioSrc.PlayOneShot(ctrlShift);

            m_GameManager.invertControls = !m_GameManager.invertControls;

            Invoke(nameof(Reactivation), 4f);

            gameObject.SetActive(false);
        }
    }

    void Reactivation()
    {
        m_GameManager.ReActivateObject(gameObject);
    }
}
