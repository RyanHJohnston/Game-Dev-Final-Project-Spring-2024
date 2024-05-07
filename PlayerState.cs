using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class PlayerState : MonoBehaviour
{
    // player properties
    [SerializeField] public int totalHealth = 100;
    [SerializeField] public int addedHealth = 10;
    [SerializeField] public int healthRegenCount = 1;
    [SerializeField] public int maxHealth = 100;
    [SerializeField] public int damage = 25;
    [SerializeField] public int totalCoinValue;
    [SerializeField] public int coinValue = 25;
    [SerializeField] public bool isInvincible = false;
    [SerializeField] public bool isDead = false;

    /* Audio */
    [SerializeField] public AudioSource playerAudioSource;
    [SerializeField] public AudioClip playerCoinSoundEffect;
    [SerializeField] public AudioClip playerDamageSoundEffect;
    [SerializeField] public AudioClip playerHealthGainSoundEffect;
    [SerializeField] public AudioClip playerHealthRegenSoundEffect;
    [SerializeField] public AudioClip playerHealthMaxReached;
    [SerializeField] public AudioClip playerInvincibilitySoundEffect;
    [SerializeField] public AudioClip playerDeathSoundEffect;


    private Rigidbody2D rb;
    private BoxCollider2D box;

    void Awake()
    {
        totalCoinValue = 0;
    }


    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        box = GetComponent<BoxCollider2D>();
    }

    public void TakeDamage(int damageAmount)
    {
        if (isInvincible)
        {
            Debug.Log(gameObject.name + " is invincible and cannot take damage");
            return;
        }

        Debug.Log(gameObject.name + " current health: " + totalHealth);
        totalHealth -= damageAmount;

        // damage taken from enemies
        if (totalHealth <= 0)
        {
            Debug.Log(gameObject.name + " now has been destroyed.");
            playerAudioSource.clip = playerDeathSoundEffect;
            playerAudioSource.Play();
            Destroy(gameObject);
            isDead = true;
        }
        else
        {
            Debug.Log(gameObject.name + " now has " + totalHealth + "  health.");
        }
    }

    public void AddCoin(int coinValue)
    {
        Debug.Log(gameObject.name + " total coins: " + totalCoinValue);
        totalCoinValue += coinValue;
    }

    public void AddHealth(int addedHealth)
    {
        Debug.Log(gameObject.name + "Health Gained: " + addedHealth);
        totalHealth += addedHealth;
    }

    /// <summary>
    /// If "Event", change player state.
    /// This applies to gold coins, power-ups, enemies, and objects.
    /// <param name="collision">[TODO:description]</param>
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Enemy") ||
                collision.gameObject.CompareTag("StonePillarTop") ||
                collision.gameObject.CompareTag("StonePillarBottom") ||
                collision.gameObject.CompareTag("Bat") ||
                collision.gameObject.CompareTag("spikes") ||
                collision.gameObject.CompareTag("RobotEnemy"))
        {
            playerAudioSource.clip = playerDamageSoundEffect;
            playerAudioSource.Play();
            TakeDamage(damage);
        }

        if (collision.gameObject.CompareTag("GoldCoin"))
        {
            playerAudioSource.clip = playerCoinSoundEffect;
            playerAudioSource.Play(); 
            AddCoin(coinValue);
        }

        if (collision.gameObject.CompareTag("HealthGain"))
        {
            if ((totalHealth + addedHealth) > maxHealth)
            {
                Debug.Log("Max Health Reached");
            }
            else
            {
                AddHealth(addedHealth);
            }

            playerAudioSource.clip = playerHealthGainSoundEffect;
            playerAudioSource.Play();
        }

        if (collision.gameObject.CompareTag("Invincibility"))
        {
            playerAudioSource.clip = playerInvincibilitySoundEffect;
            playerAudioSource.Play();
            StartCoroutine(BecomeInvincible(10));
            
        }
    }


    public IEnumerator BecomeInvincible(float duration)
    {
        isInvincible = true;
        yield return new WaitForSeconds(duration);
        isInvincible = false;
    }

}
