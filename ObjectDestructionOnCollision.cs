using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class ObjectDestructionOnCollision : MonoBehaviour
{
    [SerializeField] GameObject customGameObject;
    [SerializeField] float lifetime = 0.2f;

    void Update()
    {
        // Debug.Log("Tag: " + gameObject.tag);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            Debug.Log("Hit Player!");
            Destroy(gameObject);
        }

        if (collision.gameObject.CompareTag("Enemy"))
        {
            Debug.Log("Hit Enemy!");
            var customObject = (GameObject) Instantiate(gameObject, transform.position, Quaternion.identity);
            Destroy(customObject, lifetime);
        }
    }
}
