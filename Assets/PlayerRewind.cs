using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class PlayerSnapshot
{
    public Vector3 position;

    public PlayerSnapshot(Vector3 newPosition)
    {
        position = newPosition;
    }
}

public class PlayerRewind : MonoBehaviour
{
    // shows where my player is at 
    public List<PlayerSnapshot> playerSnapshots =
        new List<PlayerSnapshot>();

    public bool isRewinding = false;

    private float recordTimer = 0;

    void Update()
    {
        if (isRewinding == false)
        {
            recordTimer += Time.deltaTime;

            // Save position every 0.1 seconds
            if (recordTimer >= 0.1f)
            {
                SaveSnapshot();

                recordTimer = 0;
            }
        }
    }

    void SaveSnapshot()
    {
        PlayerSnapshot snapshot =
            new PlayerSnapshot(transform.position);

        playerSnapshots.Add(snapshot);
    }

    public void StartRewind()
    {
        if (isRewinding == false)
        {
            StartCoroutine(RewindCoroutine());
        }
    }

    IEnumerator RewindCoroutine()
    {
        isRewinding = true;

        // this code helps go backwards through the saved positions
        for (int i = playerSnapshots.Count - 1; i >= 0; i--)
        {
            transform.position =
                playerSnapshots[i].position;

            yield return new WaitForSeconds(0.02f);
        }

        playerSnapshots.Clear();

        isRewinding = false;
    }
}


