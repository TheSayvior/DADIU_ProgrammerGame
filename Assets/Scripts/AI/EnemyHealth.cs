using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    public int startingHealth = 100;
    public int currentHealth;
    //public int scoreValue = 10;
    bool isDead;


    void Awake()
    {
        currentHealth = startingHealth;
    }

    public void TakeDamage(int amount)
    {
        if (isDead)
            return;
        currentHealth -= amount;
        Debug.Log(currentHealth);
        if (currentHealth <= 0)
        {
            Death();
        }
    }


    void Death()
    {
        isDead = true;
        GameMasterPublicVariables.killedAI++;
        Destroy(gameObject);
    }
}
