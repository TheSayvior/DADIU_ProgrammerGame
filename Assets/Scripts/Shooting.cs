using UnityEngine;

public class Shooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.2f;
    public float BulletSpeed = 2f;
    public GameObject bullet;
    public bool isShotgun=false;
    RaycastHit hitInfo;
    Vector3 flyToPos;
    //public GameObject AudioM;
    float timer;

    void Update()
    {
        timer += Time.deltaTime;

        if (Input.GetButtonDown("Fire1") && timer >= timeBetweenBullets)
        {
            //AudioM.GetComponent<AudioController>().
            Shoot();
        }

    }


    void Shoot()
    {
        if (Physics.Raycast(Camera.main.transform.position, Camera.main.transform.forward, out hitInfo, 100))
        {
            flyToPos = hitInfo.point;
        }
        else
        {
            flyToPos = Camera.main.transform.position + Camera.main.transform.forward * 10;
        }
        timer = 0f;
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        Debug.Log(bul.transform.position);
        bul.SendMessage("setPosition", transform.position);
        if (isShotgun)
        {
            bul.SendMessage("setDirection", (flyToPos - transform.position).normalized + new Vector3(Random.Range(0f, 1f) / 10f, Random.Range(0f, 1f) / 10f, Random.Range(0f, 1f) / 10f) * BulletSpeed);
        }
        else
        {
            bul.SendMessage("setDirection", (flyToPos - transform.position).normalized * BulletSpeed);
        }
        bul.SendMessage("setDmg", damagePerShot);
    }
}
