using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

    public Text timerTxt;
    float timer, timeBonus, timeLeft, time;
    public float timeForKill, startTime, shotgunSpawnKills, akSpawnKills;
    public GameObject zeldaDoor, ak;
    //public static bool shotgunPick = false, akPick = false;

	// Use this for initialization
	void Start () {
        timer = startTime;
        timeLeft = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameMasterPublicVariables.startZelda == false)
        {
            TimerCountdown();
        }
		if (ak == null) {
			return;
		}
        if (zeldaDoor == null)
        {
            return;
        }
		if (GameMasterPublicVariables.killedAI >= shotgunSpawnKills) {
			zeldaDoor.SetActive (true);
		}
		if (GameMasterPublicVariables.killedAI >= akSpawnKills) {
			ak.SetActive (true);
		}
	}

    void TimerCountdown()
    {
        timer -= Time.deltaTime;
        timeBonus = GameMasterPublicVariables.killedAI * timeForKill;
        timeLeft = timer + timeBonus;
        timerTxt.text = "Time left: " + timeLeft.ToString("f2");
    }
}
