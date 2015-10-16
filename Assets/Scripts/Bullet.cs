using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour {

    public int damagePerShot;
    Vector3 direction;

    // Use this for initialization
    void Start () {
	    
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.anyKey)
        {
            transform.position = transform.position + direction;
        }
    }

    void setDirection(Vector3 dir)
    {
        direction = dir;
    }
    
    void setDmg(int dmg)
    {
        damagePerShot = dmg;
    }

    void OnCollisionEnter(Collision col)
    {
        if (col.gameObject.tag == "AI")
        {
            EnemyHealth enemyHealth = col.gameObject.GetComponent<EnemyHealth>();
            if (enemyHealth != null)
            {
                enemyHealth.TakeDamage(damagePerShot, Vector3.zero);
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.tag =="Wall")
        {
            Destroy(gameObject);
        }
    }
}
