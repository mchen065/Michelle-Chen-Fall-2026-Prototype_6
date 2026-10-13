using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public Manager Manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            Manager.CollectKey();

            gameObject.SetActive(false);
        }
    }
}

