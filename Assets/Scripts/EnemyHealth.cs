using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    //public float sinkSpeed = 2.5f;
    public int scoreValue = 10;

    CapsuleCollider capsuleCollider;
    bool isDead;
    //bool isSinking;


    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount, Vector3 hitPoint)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        capsuleCollider.isTrigger = true;
        Destroy(gameObject);
    }
}
