using UnityEngine;

public class Portals : MonoBehaviour
{
    public Transform spawnPoint;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        if (spawnPoint == null) Debug.Log("No Spawn Point");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.collider.CompareTag("Player"))
        {
            collision.collider.gameObject.SetActive(false);
            collision.collider.gameObject.transform.position = spawnPoint.position;
            collision.collider.gameObject.SetActive(true);

            gameObject.SetActive(false);
        }
    }
}
