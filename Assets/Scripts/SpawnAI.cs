using UnityEngine;
using System.Collections;

public class SpawnAI : MonoBehaviour {
    public GameObject AI;
    public int startEnemies;
    int x, z, numberOfAIsStart = 0;

	// Use this for initialization
	void Start () {
        while (numberOfAIsStart != startEnemies)
        {
            StartCoroutine("SpawnOneAICou");
        }
	}
	
	// Update is called once per frame
	void Update () {

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
        }
    }

    IEnumerator SpawnOneAICou()
    {
        SpawnOneAI();
        yield return null;
    }
}
