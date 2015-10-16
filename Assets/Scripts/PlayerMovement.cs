using UnityEngine;
using System.Collections;

public class PlayerMovement : MonoBehaviour {

    public float speed = 0.1f;
 

    private Rigidbody RB;

    private bool collided;

    //Needed for double speed powerup
    private bool boolDoubleSpeed = false;
    private float doubleSpeed;
    private float time = 5.0f;
    private float timeElapsed = 0;

    // Use this for initialization
    void Start () {
        RB = GetComponent<Rigidbody>();
        doubleSpeed = speed * 2;
    }
	
	// Update is called once per frame


	void Update () {

        RB.velocity = Vector3.zero;

        if(boolDoubleSpeed)
        {
            speed = doubleMovementSpeed(speed);
        }

        transform.rotation = Camera.main.transform.rotation;

        if (Input.GetKey("w"))
        {
            var move = transform.forward;
            move.y = 0;
            transform.localPosition = transform.localPosition + move * speed;
        }
        if (Input.GetKey("s"))
        {
            var move = transform.forward;
            move.y = 0;
            transform.localPosition = transform.localPosition - move * speed;
        }
        if (Input.GetKey("d"))
        {
            var move = transform.right;
            move.y = 0;
            transform.localPosition = transform.localPosition + move * speed;
        }
        if (Input.GetKey("a"))
        {
            var move = transform.right;
            move.y = 0;
            transform.localPosition = transform.localPosition - move * speed;
        }
    }

    private float doubleMovementSpeed(float speed)
    {
        if (timeElapsed < time)
        {
            speed = doubleSpeed;
            timeElapsed += Time.deltaTime;
        }
        else
        {
            speed = speed / 2;
            boolDoubleSpeed = false;
            timeElapsed = 0;
        }
        return speed;
    }
}
