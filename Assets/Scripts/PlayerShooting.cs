using UnityEngine;

public class PlayerShooting : MonoBehaviour
{
    public int damagePerShot = 20;
    public float timeBetweenBullets = 0.15f;
    public float speed = 2f;
    public GameObject bullet,shootingLine;


    float timer;

    void Update ()
    {
        timer += Time.deltaTime;

		if(Input.GetButton ("Fire1") && timer >= timeBetweenBullets)
        {
            Shoot ();
        }
    }


    void Shoot ()
    {
        timer = 0f;
        GameObject bul = Instantiate(bullet, transform.position, Quaternion.Euler(0, 0, 0)) as GameObject;
        bul.SendMessage("setDirection",(transform.position-shootingLine.transform.position) * speed);
        bul.SendMessage("setDmg",damagePerShot);
    }
}
