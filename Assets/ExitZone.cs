using UnityEngine;

public class ExitZone : MonoBehaviour
{
    public Manager Manager;

    public GameObject winScreen;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Manager.HasAllKeys())
            {
                winScreen.SetActive(true);

                Manager.WinGame();
            }
        }
    }
}
