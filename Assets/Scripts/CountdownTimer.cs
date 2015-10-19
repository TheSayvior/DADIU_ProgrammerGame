using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

    public Text timerTxt;
    float timer, timeBonus, timeLeft;
    public float timeForKill = 10, startTime = 180;
    public GameObject shotgun, ak;
	// Use this for initialization
	void Start () {
        timer = startTime;
        timeLeft = startTime;
	}
	
	// Update is called once per frame
	void Update () {
        TimerCountdown();
        if (timer > 60)
        {
            shotgun.SetActive(true);
        }
        if (timer > 180)
        {
            ak.SetActive(true);
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
