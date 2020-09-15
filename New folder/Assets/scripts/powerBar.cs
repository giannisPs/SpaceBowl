using UnityEngine;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class powerBar : MonoBehaviour
{

    
   

    public bool increasing = false;
    private bool power = false;

    public float barSpeed = 20; //how fast bar will fill in.

    public Image currentForceBar;
    public Text ratioText;


    private float currentPower = 0;
    private float maxPower = 100;

    private GameObject player; //player gameobject
    private float ballSpeed=0;

    //private GameObject _GameManager; //gamemanager gameobject


    // Use this for initialization
    void Start()
    {
        player = GameObject.Find("Ball"); //finding player gameobject so we can make it jump.
        //UpdateHealthbar();

    }

    // Update is called once per frame
    void Update()
    {
        float ratio = currentPower / maxPower;
        currentForceBar.rectTransform.localScale = new Vector3(1, ratio, 1);
        if (!power)
        {
            if (Input.GetButtonDown("Fire1"))
            { //if jump button is held down se increasing to true.
                increasing = true;
            }
            else if (Input.GetButtonUp("Fire1"))
            {
                ballSpeed =25* currentPower;

                player.GetComponent<Rigidbody>().AddForce(ballSpeed * transform.forward ); //add force to the player so it jumps.


                increasing = false; //set bar increasing back to false.

            }
        }

       

        if (increasing) //if bar is increasing, calculate thepower
        {
            if (currentPower <= 100)
            {
                currentPower += Time.deltaTime * barSpeed;
            }
            else
            {
                currentPower = 100;
            }
        }
        else //else set thepower back to 0.
        {
            currentPower = 0;
        }
    }
 


    
}