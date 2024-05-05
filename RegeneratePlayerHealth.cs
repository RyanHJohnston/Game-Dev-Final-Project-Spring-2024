using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneratePlayerHealth : MonoBehaviour
{
    [SerializeField] public PlayerState playerState;
    [SerializeField] public int healthRegenerationCount = 1;
    [SerializeField] public int seconds = 1;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HealthRegen") && !IsInvoking("RegenerateHealth") && playerState.totalHealth < playerState.maxHealth)
        {
            InvokeRepeating("RegenerateHealth", 0f, 1f);
            Invoke("StopRegeneration", 10);
        }
    }

    private void RegenerateHealth()
    {
        playerState.totalHealth += 1;
        Debug.Log("[PLAYER REGENERATE] Health Increased to: " + playerState.totalHealth);
    }

    private void StopRegeneration()
    {
        CancelInvoke("RegenerateHealth");
    }



}
