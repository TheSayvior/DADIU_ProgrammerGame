using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

    public Text timerTxt, findDoor;
    float timer, timeBonus, time, count = 0;
    public static float timeLeft;
    public float timeForKill, startTime, shotgunSpawnKills, akSpawnKills;
    public GameObject zeldaDoor, ak, AudioM;
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
		if (GameMasterPublicVariables.killedAI >= shotgunSpawnKills && count == 0) {
			zeldaDoor.SetActive (true);
            AudioM.GetComponent<AudioController>().cain1.Play();
            StartCoroutine(doorText());
            count = 1;
		}
		if (GameMasterPublicVariables.killedAI >= akSpawnKills && count == 1) {
			ak.SetActive (true);
            count = 2;
		}
	}

    void TimerCountdown()
    {
        timer -= Time.deltaTime;
        timeBonus = GameMasterPublicVariables.killedAI * timeForKill;
        timeLeft = timer + timeBonus;
        timerTxt.text = "Time left: " + timeLeft.ToString("f2");
    }

    IEnumerator doorText()
    {
        findDoor.text = "Find the door!!!";
        yield return new WaitForSeconds(2.5f);
        findDoor.text = "";
    }
}
