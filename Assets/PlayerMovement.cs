using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 5f;

    private Rigidbody2D rb;
    private PlayerRewind rewind;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rewind = GetComponent<PlayerRewind>();
    }

    void Update()
    {
        // This code makes it so the player doesnt move while rewinding
        if (rewind.isRewinding)
        {
            rb.linearVelocity = Vector2.zero;
            return;
        }

        float x = 0;
        float y = 0;

        if (Keyboard.current.wKey.isPressed)
            y = 1;

        if (Keyboard.current.sKey.isPressed)
            y = -1;

        if (Keyboard.current.aKey.isPressed)
            x = -1;

        if (Keyboard.current.dKey.isPressed)
            x = 1;

        Vector2 movement = new Vector2(x, y).normalized;

        rb.linearVelocity = movement * speed;
    }
}
