using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isFlipped;
    [HideInInspector] public bool invertControls;
    [HideInInspector] public bool isPlayerCollided;
    public float gravitationForce = 50f;


    private UIManager m_UIManager;
    private TutorialManager m_TutorialManager;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
    }

    private void Start()
    {
        m_TutorialManager = FindObjectOfType<TutorialManager>();
        m_UIManager = FindObjectOfType<UIManager>();
    }

    public void FlipGravity(Rigidbody2D rb)
    {
        isFlipped = !isFlipped;
        rb.gravityScale = isFlipped ? -gravitationForce : gravitationForce;
    }

    public void GameOver()
    {
        GameInputManager.Instance.DisableControls();

        if (m_TutorialManager)
        {
            m_TutorialManager.EnableGameOverPanel($"Completed", Color.softYellow);
        }
        else if (m_UIManager)
        {
            m_UIManager.EnableGamePanel($"{SceneManager.GetActiveScene().name} Cleared", Color.softYellow);
        }
    }

    public void PlayerDead(Rigidbody2D playerRB)
    {
        playerRB.gameObject.SetActive(false);
        isPlayerCollided = true;

        if(m_TutorialManager)
        {
            m_TutorialManager.EnableGameOverPanel($"Failed", Color.softYellow);
        }
        else if(m_UIManager)
        {
            m_UIManager.EnableGamePanel($"{SceneManager.GetActiveScene().name} Failed", Color.softYellow);
        }
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("First");
    }
}
