using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class torqueScript : MonoBehaviour {


    public bool increasing = false;
    private bool power = false;

    public float barSpeed = 25; //how fast bar will fill in.

    public Image currentTorqueBar;
    public Text ratio1Text;


    private float torque = 0;
    private float maxPower = 100;
    private float TorqueSpeed = 0;


    private GameObject lane; //player gameobject
    private GameObject playerBall;


    //private GameObject _GameManager; //gamemanager gameobject


    // Use this for initialization
    // Use this for initialization
    void Start () {

        playerBall = GameObject.Find("Ball");
	}
	
	// Update is called once per frame
	void Update () {

        float ratio = torque / maxPower;
        currentTorqueBar.rectTransform.localScale = new Vector3(ratio, 1, 1);
        if (!power)
        {
            if (Input.GetButtonDown("Fire2"))
            { //if  button is held down se increasing to true.
                increasing = true;
            }
            else if (Input.GetButtonUp("Fire2"))
            {
                TorqueSpeed = 25 *torque;
                increasing = false;
                    

            }
        }
        if (increasing) //if bar is increasing, calculate thepower
        {
            if (torque<= 100)
            {
                torque += Time.deltaTime * barSpeed;
            }
            else
            {
                torque = 100;
            }
        }
        else //else set thepower back to 0.
        {
            torque = 0;
        }

    }
    public void OnCollisionEnter(Collision collision)
    {
        collision.gameObject.CompareTag("Ball");
        if (collision.gameObject.CompareTag("Ball"))
        {
            playerBall.GetComponent<Rigidbody>().AddTorque(1, TorqueSpeed, 1);
                }
    }
}
