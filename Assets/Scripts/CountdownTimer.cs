using UnityEngine;
using UnityEngine.UI;
using System.Collections;

public class CountdownTimer : MonoBehaviour {

    public Text timerTxt;
    float timelimit = 180;


	// Use this for initialization
	void Start () {

	}
	
	// Update is called once per frame
	void Update () {
        TimerCountdown();
	}

    void TimerCountdown()
    {
        timelimit -= Time.deltaTime;
        timerTxt.text = "Time left: " + timelimit.ToString("f2");
    }
}
