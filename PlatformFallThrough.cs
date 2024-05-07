using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformFallThrough : MonoBehaviour
{
    private Collider2D collider;    
    private bool isPlayerOnPlatform;

    void Start()
    {
        collider = GetComponent<Collider2D>();
        StartCoroutine(EnableCollider());
    }    

    void Update()
    {
        if (isPlayerOnPlatform && Input.GetAxisRaw("Vertical") < 0)
        {
            collider.enabled = false;
        }
    }

    private IEnumerator EnableCollider()
    {
        yield return new WaitForSeconds(0.5f);
        collider.enabled = true;
    }

    private void SetPlayerOnPlatform(Collision2D other, bool value)
    {
        var player = other.gameObject.GetComponent<PlayerState>();
        if (player != null)
        {
            isPlayerOnPlatform = value;
        }
    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        SetPlayerOnPlatform(collision, true);
    }

    void OnCollisionExit2D(Collision2D collision)
    {
        SetPlayerOnPlatform(collision, true);
    }

}
