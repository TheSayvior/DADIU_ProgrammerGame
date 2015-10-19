using UnityEngine;
using System.Collections;

public class SpawnAI : MonoBehaviour {
    public GameObject AI;
    public int startEnemies = 10;
    public float enemyIncreaseTimer = 10.0f;

    int x, z, numberOfAIsStart = 0, desiredNumberOfAIs = 0;
    private float timeElapsed = 0;
	// Use this for initialization
	void Start () {
        desiredNumberOfAIs = startEnemies;

        while (numberOfAIsStart != desiredNumberOfAIs)
        {
            StartCoroutine("SpawnOneAICou");
        }
	}
	
	// Update is called once per frame
	void Update () {
        int numberOfAis = GameMasterPublicVariables.spawnedAI - GameMasterPublicVariables.killedAI;

        timeElapsed += Time.deltaTime;

        if (timeElapsed > enemyIncreaseTimer) {
            desiredNumberOfAIs += 1;
            timeElapsed = 0;
        }

        if (numberOfAis < desiredNumberOfAIs)
        {
            SpawnOneAI();
        }
	}

    void SpawnOneAI()
    {
        x = Random.Range(-45, 45);
        z = Random.Range(25, -65);
        if (x > 15 || x < -15 && z > 15 || z < -15)
        {
            AI.transform.position = new Vector3(x, 1, z);
            Instantiate(AI);
            numberOfAIsStart++;
            GameMasterPublicVariables.spawnedAI += 1;
        }
    }

    IEnumerator SpawnOneAICou()
    {
        SpawnOneAI();
        yield return null;
    }
}
