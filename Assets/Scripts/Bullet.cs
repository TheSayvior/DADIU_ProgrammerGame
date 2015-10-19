using UnityEngine;
using System.Collections;

public class Bullet : MonoBehaviour
{

    public int damagePerShot,bulletDistance;
    Vector3 direction,startingPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.anyKey)
        {
            transform.position = transform.position + direction;
        }
        if( bulletDistance<Vector3.Distance(startingPos, transform.position))
        {
            Destroy(gameObject);
        }
    }

    void setPosition(Vector3 pos)
    {
        startingPos = pos;
        transform.position = pos;
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
                enemyHealth.TakeDamage(damagePerShot);
                Destroy(gameObject);
            }
        }
        else if (col.gameObject.tag == "Wall")
        {
            Destroy(gameObject);
        }
    }
}
