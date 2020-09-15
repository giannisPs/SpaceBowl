using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ball : MonoBehaviour {

   public Rigidbody rb_ball;
    Transform fpsControllerTransform;
   public bool BallThrown = false;
    //public float amount = 50f;
   // public bool increasing = false;
    //float h;
    // Use this for initialization
    void Start () {

        rb_ball = GetComponent<Rigidbody>();
        rb_ball.useGravity = false;

        fpsControllerTransform = GameObject.Find("FirstPersonCharacter").GetComponent<Transform>();
		
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetButtonUp("Fire1"))
        {   //left click
            //Debug.Log("left click"); //printf 
            rb_ball.useGravity = true;
            rb_ball.AddForce(transform.forward * 1500);
            BallThrown = true;
            transform.parent = null;
        }
        
        
        //if (Input.GetButtonDown("torqueLeft"))
        //{
        //     h =  amount * Time.deltaTime;
        //}
        //else if (Input.GetButtonUp("torqueLeft"))
        //{
        //    rb_ball.AddTorque(transform.up * h);
        //}
        //     //float h = Input.GetAxis("torqueLeft") * amount * Time.deltaTime;
        ////    float v = Input.GetAxis("torqueRight") * amount * Time.deltaTime;

        //    rb_ball.AddTorque(transform.up * h);
        //    //rb_ball.AddTorque(transform.right * v);

        //if (increasing) //if bar is increasing, calculate thepower
        //{
        //    if (amount <= 100)
        //    {
        //        amount += Time.deltaTime ;
        //    }
        //    else
        //    {
        //        amount = 100;
        //    }
        //}
        //else //else set thepower back to 0.
        //{
        //    amount = 0;
        //}
    }
       
}

