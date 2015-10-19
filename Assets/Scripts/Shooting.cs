using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.2f;
    public float BulletSpeed = 2f;
    public GameObject bullet, shootingLine;
    public bool isShotgun=false;


    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot();
        }

    }


    void Shoot()
    {
        timer = 0f;
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        bul.SendMessage("setPosition",transform.position);
        if (isShotgun)
        {
            bul.SendMessage("setDirection", (transform.position - shootingLine.transform.position).normalized+new Vector3(Random.Range(0f,1f)/10f, Random.Range(0f, 1f)/10f, Random.Range(0f, 1f)/10f) * BulletSpeed);
        }
        else
        {
            bul.SendMessage("setDirection", (transform.position - shootingLine.transform.position).normalized * BulletSpeed);
        }
        bul.SendMessage("setDmg", damagePerShot);
    }
}
