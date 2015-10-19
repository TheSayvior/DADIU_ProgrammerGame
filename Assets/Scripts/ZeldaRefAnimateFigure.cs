using UnityEngine;
using System.Collections;

public class ZeldaRefAnimateFigure : MonoBehaviour {

    public float aniSpeed = 1;
    public float waitTime = 4;
    public bool startZelda = false;

    public GameObject background;

    private bool walkIn = true, walkOut = false;

    private float originalZPos;

    private MeshRenderer MR;
    private Texture newBackground;

    // Use this for initialization
    void Start()
    {
        originalZPos = transform.position.z;

        MR = background.GetComponent<MeshRenderer>();

        newBackground = Resources.Load("giveShotgunDone", typeof(Texture)) as Texture;
    }
    // Update is called once per frame
        void Update() {
        if (startZelda == true && (transform.position.z > originalZPos - 0.5))
        {
            if (transform.position.z >= originalZPos + 1.5)
            {
                walkIn = false;
                walkOut = true;
            }

            if (walkIn)
            {
                moveForward();
                return;
            }
            waitTime -= Time.deltaTime;

            if(walkOut && waitTime < 0.0f)
            {
                MR.material.mainTexture = newBackground;
                moveBackward();
            }
        }
    }

    void moveForward()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z + Time.deltaTime * aniSpeed);
    }

    void moveBackward()
    {
        transform.position = new Vector3(transform.position.x, transform.position.y, transform.position.z - Time.deltaTime * aniSpeed);
    }
}
