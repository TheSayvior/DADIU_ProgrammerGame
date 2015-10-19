using UnityEngine;
using System.Collections;

public class GameMasterPublicVariables : MonoBehaviour {

    public static bool EnemyHalfSpeed = false;

    public static int killedAI = 0;
    public static int spawnedAI = 0;

	// Use this for initialization
	void Start () {
        Cursor.visible = false;
        Cursor.lockState = CursorLockMode.Locked;
	}
	
	// Update is called once per frame
	void Update () {
	
	}

    public void restartLevel()
    {
        Application.LoadLevel(Application.loadedLevel);
    }
}
