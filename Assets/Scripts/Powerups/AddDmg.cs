﻿using UnityEngine;
using System.Collections;

public class AddDmg : MonoBehaviour {

    public int bonusDmg = 5;
    // Animations
    private float aniTimeElapsed;
    private float aniTime = 0.5f;
    private bool aniUp = true;

    void Update()
    {
        if ((aniTimeElapsed > aniTime))
        {
            aniUp = false;
        }
        if ((aniTimeElapsed < 0.0f))
        {
            aniUp = true;
        }

        transform.Rotate(new Vector3(0, 2, 0));

        if (aniUp)
        {
            transform.position = new Vector3(transform.position.x, transform.position.y + Time.deltaTime, transform.position.z);
            aniTimeElapsed += Time.deltaTime;
        }
        else
        {
            transform.position = new Vector3(transform.position.x, transform.position.y - Time.deltaTime, transform.position.z);
            aniTimeElapsed -= Time.deltaTime;
        }
    }

    void OnTriggerEnter(Collider col)
    {
        if (col.tag == "Wall")
        {
            SpawnPowerUp.takenPowerUps++;
            Destroy(this.gameObject);
            return;
        }
        if (col.tag != "Player")
        {
            return;
        }
        GameMasterPublicVariables.dmg = GameMasterPublicVariables.dmg + bonusDmg;
        SpawnPowerUp.takenPowerUps++;
        Destroy(this.gameObject);
    }

    void OnTriggerStay(Collider col)
    {
        if (col.tag == "Wall")
        {
            SpawnPowerUp.takenPowerUps++;
            Destroy(this.gameObject);
            return;
        }
    }
}
