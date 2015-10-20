using UnityEngine;
using System.Collections;

public class ActivateZelda : MonoBehaviour
{

    public string weapon;
    public GameObject AudioM;

    //GUI
    public GameObject canvas;
    public GameObject minimapOutliner;
    public GameObject ZeldaCinematic;

    // Use this for initialization
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

    }

    void OnTriggerEnter(Collider player)
    {
        if (player.tag == "Player")
        {
            Debug.Log("hello");

            canvas.SetActive(false);
            minimapOutliner.SetActive(false);
            Camera.main.enabled = false;

            ZeldaCinematic.SetActive(true);

            //GameMasterPublicVariables.startZelda = true;



            AudioM.GetComponent<AudioController>().startNyt();
            player.gameObject.SendMessage("ChangeWeapon", weapon);
        }
    }
}
