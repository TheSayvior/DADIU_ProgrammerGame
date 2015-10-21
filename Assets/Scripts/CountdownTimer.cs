using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

    public Text timerTxt, newWeapon;
    float timer, timeBonus, count;
    public static float timeLeft;
    public float timeForKill, startTime, shotgunSpawnKills, akSpawnKills;
    public GameObject zeldaDoor, ak, AudioM;
    //public static bool shotgunPick = false, akPick = false;

	// Use this for initialization
	void Start () {
        timer = startTime;
        timeLeft = startTime;
        count = 0;
	}
	
	// Update is called once per frame
	void Update () {
        if (GameMasterPublicVariables.startZelda == false)
        {
            TimerCountdown();
        }
		if (GameMasterPublicVariables.killedAI >= shotgunSpawnKills && count == 0) {
			zeldaDoor.SetActive (true);
            count = 1;
            timeForKill = 1.4f;
            AudioM.GetComponent<AudioController>().cain1.Play();
            StartCoroutine(doorText());
		}
		if (GameMasterPublicVariables.killedAI >= akSpawnKills && count == 1) {
			ak.SetActive (true);
            timeForKill = 1.1f;
            AudioM.GetComponent<AudioController>().ak47.Play();
            count = 2;
            StartCoroutine(akText());
        }
        if (ak == null)
        {
            return;
        }
        if (zeldaDoor == null)
        {
            return;
        }
	}

    void TimerCountdown()
    {
        timer -= Time.deltaTime;
        timeBonus = GameMasterPublicVariables.killedAI * timeForKill + GameMasterPublicVariables.pickUpTime;
        timeLeft = timer + timeBonus;
        timerTxt.text = "Time left: " + timeLeft.ToString("f2");
    }

    IEnumerator doorText()
    {
        newWeapon.text = "Find the door!!!";
        yield return new WaitForSeconds(2.5f);
        newWeapon.text = "";
    }

    IEnumerator akText()
    {
        newWeapon.text = "Find the AK47 MOTHERF*CKER!!!";
        yield return new WaitForSeconds(2.5f);
        newWeapon.text = "";
    }
}
