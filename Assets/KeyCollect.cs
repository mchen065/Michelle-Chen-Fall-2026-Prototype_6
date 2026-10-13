using UnityEngine;

public class KeyCollect : MonoBehaviour
{
    public Manager Manager;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerRewind rewind =
                other.GetComponent<PlayerRewind>();

            // Don't collect keys during rewind
            if (rewind != null && rewind.isRewinding)
            {
                return;
            }

            Manager.CollectKey();

            // Only hide THIS key
            gameObject.SetActive(false);
        }
    }
}

