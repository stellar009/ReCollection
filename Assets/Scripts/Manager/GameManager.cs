using UnityEngine;

public class GameManager : MonoBehaviour
{
    private bool isFlipped;
    [HideInInspector] public bool invertControls;
    [HideInInspector] public bool isPlayerCollided;


    private void Awake()
    {
        //QualitySettings.vSyncCount = 1;
    }

    public void FlipGravity(Rigidbody2D rb)
    {
        isFlipped = !isFlipped;
        rb.gravityScale = isFlipped ? -50f : 50f;
    }

    public void GameOver()
    {
        GameInputManager.Instance.DisableControls();
        Application.Quit();
        Debug.Log("Exited");
    }

    public void PlayerDead(Rigidbody2D playerRB)
    {
        playerRB.gameObject.SetActive(false);
        isPlayerCollided = true;
    }
}
