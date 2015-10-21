using UnityEngine;
using System.Collections;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject PowerUpHalfAiSpeed;
    public GameObject PowerUpIncreaseDmg;
    public GameObject PowerUptimeBonus;

    int x, z;
    public int desiredNumberOfPowerUps;
    public int NumberOfDifferentPowerUps;

    public static int spawnedPowerUps;
    public static int takenPowerUps;

    private float timeElapsed = 0;
    private GameObject player;
    private Vector3 playerPos;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        int numberOfPowerUps = spawnedPowerUps - takenPowerUps;

        if (numberOfPowerUps < desiredNumberOfPowerUps)
        {
            StartCoroutine("SpawnOnePowerUps");
        }
    }

    void SpawnOnePowerUp()
    {
        x = Random.Range(-45, 45);
        z = Random.Range(25, -65);

        if (x > playerPos.x + 15 || x < playerPos.x - 15 && z > playerPos.z + 15 || z < playerPos.z - 15)
        {
            int PowerUp = Random.Range(1, NumberOfDifferentPowerUps);
            switch (PowerUp)
            {
                case 1:
                    PowerUpHalfAiSpeed.transform.position = new Vector3(x, 1.5f, z);
                    Instantiate(PowerUpHalfAiSpeed);
                    spawnedPowerUps += 1;
                    break;
                case 2:
                    PowerUpIncreaseDmg.transform.position = new Vector3(x, 1.5f, z);
                    Instantiate(PowerUpIncreaseDmg);
                    spawnedPowerUps += 1;
                    break;
                case 3:
                    PowerUptimeBonus.transform.position = new Vector3(x, 1.5f, z);
                    Instantiate(PowerUptimeBonus);
                    spawnedPowerUps += 1;
                    break;
                default:
                    break;
                        
            }
        }
    }

    IEnumerator SpawnOnePowerUps()
    {
        SpawnOnePowerUp();
        yield return null;
    }
}

