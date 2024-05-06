using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RegeneratePlayerHealth : MonoBehaviour
{
    [SerializeField] public PlayerState playerState;
    [SerializeField] public int healthRegenerationCount = 1;
    [SerializeField] public int seconds = 1;
    [SerializeField] public bool isRegenerating;
    [SerializeField] public AudioSource playerAudioSource;
    [SerializeField] public AudioClip playerHealthRegenerationSoundEffect;

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("HealthRegen") && !IsInvoking("RegenerateHealth") && playerState.totalHealth < playerState.maxHealth)
        {
            isRegenerating = true;
            InvokeRepeating("RegenerateHealth", 0f, 1f);
            playerAudioSource.clip = playerHealthRegenerationSoundEffect;
            playerAudioSource.Play();
            Invoke("StopRegeneration", 10);
            isRegenerating = false;
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
