using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TimedDestruction : MonoBehaviour
{
    public float lifetime = 5.0f; // Time in seconds after which the object will be destroyed

    void Start()
    {
        Destroy(gameObject, lifetime); // Destroy this object after 'lifetime' seconds
    }
}
