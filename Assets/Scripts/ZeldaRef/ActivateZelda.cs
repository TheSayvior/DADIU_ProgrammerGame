﻿using UnityEngine;
using System.Collections;

public class ActivateZelda : MonoBehaviour
{
    private bool playOnce = false;
    public string weapon;
    public GameObject AudioM;

    //GUI
    public GameObject canvas;
    public GameObject minimapOutliner;
    public GameObject ZeldaCinematic;

    public Camera mainCam;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(GameMasterPublicVariables.zeldaOver == true)
        {
            canvas.SetActive(true);
            minimapOutliner.SetActive(true);

            mainCam.enabled = true;

            ZeldaCinematic.SetActive(false);

            if (!playOnce)
            {
                AudioM.GetComponent<AudioController>().startNyt();
            }
            Destroy(this.gameObject);
        }
    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            canvas.SetActive(false);
            minimapOutliner.SetActive(false);

            mainCam.enabled = false;

            ZeldaCinematic.SetActive(true);

            GameMasterPublicVariables.startZelda = true;
            AudioM.GetComponent<AudioController>().cain2.Play();
            player.gameObject.SendMessage("ChangeWeapon", weapon);
        }
    }
}
