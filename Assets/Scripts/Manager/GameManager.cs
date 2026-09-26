using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    private bool isFlipped;
    [HideInInspector] public bool invertControls;

    private void Awake()
    {
        QualitySettings.vSyncCount = 1;
    }

    public void FlipGravity(Rigidbody2D rb)
    {
        isFlipped = !isFlipped;
        rb.gravityScale = isFlipped ? -35f : 35f;
    }

    public void GameOver()
    {
        Application.Quit();
        Debug.Log("Exited");
    }
}
