using UnityEngine;

public class PoolItem : MonoBehaviour
{
    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Enemy"))
        {
            // Deactivate the GameObject instead of returning it to the pool.
            // gameObject.SetActive(false);
            Destroy(gameObject);

            // Optionally, if you have a reference to the ObjectPool and want to maintain pool integrity,
            // you can still return it to the pool even if it's not immediately necessary:
            // pool.ReturnObjectToPool(gameObject);

            // This could be useful if you later decide to "respawn" the coin or use it again.
        }
    }
}