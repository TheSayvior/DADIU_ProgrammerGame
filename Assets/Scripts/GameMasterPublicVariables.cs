using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class GameMasterPublicVariables : MonoBehaviour {

    public static bool EnemyHalfSpeed = false, startZelda = false, zeldaOver= false;
    public Text killCount,Score;
    public static int killedAI, spawnedAI;
    public static float enemyIncreaseTimer = 10, AISpeed;
    public int AiPlus, forEveryKill;
    //int count = 0;
	// Use this for initialization
	void Start () {
        Time.timeScale = 1;
        killedAI = 0;
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
        EnemyHealth.startingHealth = 1;
        spawnedAI = 0;
        Score.enabled = false;
        Score.text = "0";
	}
	
	// Update is called once per frame
	void Update () {
        killCount.text = "Kills: " + killedAI;
        if (killedAI >= AiPlus)
        {
            EnemyHealth.startingHealth += 1;
            AiPlus += forEveryKill;
            AISpeed += 1f;
        }
        //if (enemyIncreaseTimer == 5)
        //{
        //    enemyIncreaseTimer = 5;
        //}
        //else
        //{
        //    enemyIncreaseTimer -= 1;
        //    moreAI = moreAI + everyKill;
        //}
	}

    public void restartLevel()
    {
        Time.timeScale = 1;
        Application.LoadLevel(Application.loadedLevel);
    }
}
