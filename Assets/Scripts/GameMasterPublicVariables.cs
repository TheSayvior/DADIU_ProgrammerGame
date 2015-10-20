using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMasterPublicVariables : MonoBehaviour {

    public static bool EnemyHalfSpeed = false, startZelda = false, zeldaOver= false;
    public Text killCount;
    public static int killedAI, spawnedAI;
    public static float enemyIncreaseTimer = 10, AISpeed;
    public int AIplus, forEveryKill;
    //int count = 0;
	// Use this for initialization
	void Start () {
        killedAI = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        EnemyHealth.startingHealth = 1;
        spawnedAI = 0;
	}
	
	// Update is called once per frame
	void Update () {
        killCount.text = "Kills: " + killedAI;
        if (killedAI >= AIplus)
        {
            enemyIncreaseTimer -= 1;
            EnemyHealth.startingHealth += 1;
            AIplus += forEveryKill;
            AISpeed += 0.25f;
        }
	}

    public void restartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}
