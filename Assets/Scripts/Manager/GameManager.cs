using TMPro;
using UnityEngine;
using UnityEngine.Rendering;
using UnityEngine.Rendering.Universal;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    private bool isFlipped;
    [HideInInspector] public bool invertControls;
    [HideInInspector] public bool isPlayerCollided;
    public float gravitationForce = 50f;

    public TextMeshProUGUI levelText;
    public Volume volume;

    private UIManager m_UIManager;
    private DepthOfField m_Dof;


    private void Awake()
    {
        EnableCursor(false);
    }

    private void Start()
    {
        m_UIManager = FindObjectOfType<UIManager>();

        if (!levelText) return;

        SceneName(levelText);
    }

    public void FlipGravity(Rigidbody2D rb)
    {
        isFlipped = !isFlipped;
        rb.gravityScale = isFlipped ? -gravitationForce : gravitationForce;
    }

    public void GameOver()
    {
        GameInputManager.Instance.DisableControls();

        m_UIManager.EnableGamePanel($"{SceneManager.GetActiveScene().name} Cleared");

        GameInputManager.Instance.EnableUIControls(false);
        EnableCursor(true);
    }

    public void PlayerDead(Rigidbody2D playerRB)
    {
        playerRB.gameObject.SetActive(false);
        isPlayerCollided = true;

        m_UIManager.EnableGamePanel($"{SceneManager.GetActiveScene().name} Failed");

        GameInputManager.Instance.EnableUIControls(false);
        EnableCursor(true);
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void ExitScene()
    {
        SceneManager.LoadScene("First");
    }

    public void PauseGame(bool isPaused)
    {
        if(isPaused)
        {
            m_UIManager.EnablePauseMenu();

            EnableCursor(true);
        }
        else
        {
            m_UIManager.DisablePauseMenu();

            EnableCursor(false);
        }
    }

    void SceneName(TextMeshProUGUI text)
    {
        text.text = SceneManager.GetActiveScene().name;
    }

    public void EnableCursor(bool enable)
    {
        Cursor.lockState = enable ? CursorLockMode.None : CursorLockMode.Locked;
        Cursor.visible = enable;

        EnableBlur(enable);
    }

    void EnableBlur(bool blur)
    {
        volume.profile.TryGet<DepthOfField>(out m_Dof);

        if(blur && m_Dof != null)
        {
            m_Dof.active = true;
            m_Dof.focusDistance.value = 0.1f;
        }
        else
        {
            m_Dof.active = false;
        }
    }

    public void ReActivateObject(GameObject gameObject)
    {
        gameObject.SetActive(true);
    }
}
