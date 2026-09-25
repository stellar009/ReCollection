using TMPro;
using UnityEngine;

public class Player : MonoBehaviour
{
    private Rigidbody2D m_Rigidbody;

    [Header("Player Settings")]
    public float speed = 5f;

    [Header("UI")]
    public TextMeshProUGUI tmp;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        m_Rigidbody = GetComponent<Rigidbody2D>();
        tmp.enabled = false;
    }

    // Update is called once per frame
    void Update()
    {
        PlayerMovement();

        if(transform.position.y < -10 ||transform.position.y > 10)
        {
            gameObject.SetActive(false);
            tmp.enabled = true;
            tmp.text = $"Game Over ";
        }
    }

    void PlayerMovement()
    {
        m_Rigidbody.linearVelocity = new Vector2(GameInputManager.Instance.movement * speed, m_Rigidbody.position.y);
    }
}
