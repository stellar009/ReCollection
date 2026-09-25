using UnityEngine;

public class ControlInversion : MonoBehaviour
{
    private GameManager m_GameManager;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_GameManager = FindObjectOfType<GameManager>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            m_GameManager.InvertControls();
            gameObject.SetActive(false);
        }
    }
}
