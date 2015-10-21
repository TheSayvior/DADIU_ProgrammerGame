using UnityEngine;
using System.Collections;

public class SpawnPowerUp : MonoBehaviour
{
    public GameObject PowerUpHalfAiSpeed;
    public GameObject PowerUpIncreaseDmg;
    public GameObject PowerUptimeBonus;

    public GameObject[] spawnPlaces;

    int x, z, PowerUp;
    public int desiredNumberOfPowerUps;
    public int NumberOfDifferentPowerUps = 1;
    public int timeBetweenPowerUps;

    public static int spawnedPowerUps;
    public static int takenPowerUps;

    private float timeElapsed = 0;
    private GameObject player, spawner;
    private Vector3 playerPos;
    // Use this for initialization
    void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player");
        NumberOfDifferentPowerUps = 1;
    }

    // Update is called once per frame
    void Update()
    {
        playerPos = player.transform.position;

        int numberOfPowerUps = spawnedPowerUps - takenPowerUps;

        timeElapsed += Time.deltaTime;

        if (timeElapsed < timeBetweenPowerUps)
        {
            return;
        }

        if (numberOfPowerUps < desiredNumberOfPowerUps)
        {
            StartCoroutine("SpawnOnePowerUps");
        }
    }

    void SpawnOnePowerUp()
    {
        FindSpawnLocation();

        if (GameMasterPublicVariables.killedAI > 150 && GameMasterPublicVariables.killedAI % 50 == 0)
        {
            PowerUp = 2;
        }
        else
        {
            PowerUp = (int)Random.Range(1, NumberOfDifferentPowerUps + 1);
        }


        switch (PowerUp)
        {
            case 1:
                PowerUpHalfAiSpeed.transform.position = spawner.transform.position;
                Instantiate(PowerUpHalfAiSpeed);
                spawnedPowerUps += 1;
                break;
            case 2:
                PowerUpIncreaseDmg.transform.position = spawner.transform.position;
                Instantiate(PowerUpIncreaseDmg);
                spawnedPowerUps += 1;
                break;
            case 3:
                PowerUptimeBonus.transform.position = spawner.transform.position;
                Instantiate(PowerUptimeBonus);
                spawnedPowerUps += 1;
                break;
            default:
                break;

        }
        timeElapsed = 0;
    }

    private void FindSpawnLocation()
    {
        int spawnLocation = Random.Range(0, spawnPlaces.Length);

        spawner = spawnPlaces[spawnLocation];

        if (Vector3.Distance(spawner.transform.position, player.transform.position) < 20)
        {
            FindSpawnLocation();
        }
    }

    IEnumerator SpawnOnePowerUps()
    {
        SpawnOnePowerUp();
        yield return null;
    }
}

