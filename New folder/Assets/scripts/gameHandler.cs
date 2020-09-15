using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class gameHandler : MonoBehaviour
{

    int numberOfPinsKnocked = 0;
    float timerAfterFirstCol = 0.0f;
    int TIMER_SECONDS = 7;  //5 seconds after first ball-pin collission

    int[,] Player1_scoreTable = new int[10, 2]; // krataei apotelesmata 1 player
    int[,] Player2_scoreTable = new int[10, 2]; // krataei apotelesmata 2 player
    int[,] overallScore = new int[10, 2];       //a8roizei to apotelesmta ka8e guroy
    int frame1 = 1;
    int frame2 = 1;
    int shot1 = 1; int shot2 = 1;
    int finalScore1 = 0, finalScore2 = 0;
    public bool playable;


    GameObject[] pins = new GameObject[10];
    bool[] pinKnocked = new bool[10];
    Vector3[] initialPinPos = new Vector3[10];              //arxiki 8esi kowrinwn

    soundBall soundScript;


    ball ballscript;      //prosvasi sto script ball

    GameObject Ball;                      //mpala
    Vector3 initialBallPos = new Vector3();     //arxiki 8esi mpalas

    Transform player;                           //firstPersonCharacter
    Vector3 initialPlayerPos = new Vector3();   //arxiki 9esi firstPersonCharacter

    Transform fps;                              //FPSController
    Vector3 initialFps = new Vector3();         //arxiki 8esi FPS

    Text scoreText, score2Text;
    Text[] shots = new Text[20];
    Text[] shots2 = new Text[20];

    GameObject OverText1, OverText2, winnerP1Text, winnerP2Text;
    Text shotText, playerText, overallText, frameText;
    Text finalscore1Text, finalscore2Text;

    int s1 = 0, s2 = 0;
    bool player1Plays;

    // Use this for initialization
    void Start()
    {
        pins[0] = GameObject.Find("pin");                   //find game object me to onoma pou exoume sti unity
        pins[1] = GameObject.Find("pin1");
        pins[2] = GameObject.Find("pin2");
        pins[3] = GameObject.Find("pin3");
        pins[4] = GameObject.Find("pin4");
        pins[5] = GameObject.Find("pin5");
        pins[6] = GameObject.Find("pin6");
        pins[7] = GameObject.Find("pin7");
        pins[8] = GameObject.Find("pin8");
        pins[9] = GameObject.Find("pin9");

        shots[0] = GameObject.Find("shot0").GetComponent<Text>();
        shots[1] = GameObject.Find("shot1").GetComponent<Text>();
        shots[2] = GameObject.Find("shot2").GetComponent<Text>();
        shots[3] = GameObject.Find("shot3").GetComponent<Text>();
        shots[4] = GameObject.Find("shot4").GetComponent<Text>();
        shots[5] = GameObject.Find("shot5").GetComponent<Text>();
        shots[6] = GameObject.Find("shot6").GetComponent<Text>();
        shots[7] = GameObject.Find("shot7").GetComponent<Text>();
        shots[8] = GameObject.Find("shot8").GetComponent<Text>();
        shots[9] = GameObject.Find("shot9").GetComponent<Text>();
        shots[10] = GameObject.Find("shot10").GetComponent<Text>();
        shots[11] = GameObject.Find("shot11").GetComponent<Text>();
        shots[12] = GameObject.Find("shot12").GetComponent<Text>();
        shots[13] = GameObject.Find("shot13").GetComponent<Text>();
        shots[14] = GameObject.Find("shot14").GetComponent<Text>();
        shots[15] = GameObject.Find("shot15").GetComponent<Text>();
        shots[16] = GameObject.Find("shot16").GetComponent<Text>();
        shots[17] = GameObject.Find("shot17").GetComponent<Text>();
        shots[18] = GameObject.Find("shot18").GetComponent<Text>();
        shots[19] = GameObject.Find("shot19").GetComponent<Text>();


        shots2[0] = GameObject.Find("shot0_2").GetComponent<Text>();
        shots2[1] = GameObject.Find("shot1_2").GetComponent<Text>();
        shots2[2] = GameObject.Find("shot2_2").GetComponent<Text>();
        shots2[3] = GameObject.Find("shot3_2").GetComponent<Text>();
        shots2[4] = GameObject.Find("shot4_2").GetComponent<Text>();
        shots2[5] = GameObject.Find("shot5_2").GetComponent<Text>();
        shots2[6] = GameObject.Find("shot6_2").GetComponent<Text>();
        shots2[7] = GameObject.Find("shot7_2").GetComponent<Text>();
        shots2[8] = GameObject.Find("shot8_2").GetComponent<Text>();
        shots2[9] = GameObject.Find("shot9_2").GetComponent<Text>();
        shots2[10] = GameObject.Find("shot10_2").GetComponent<Text>();
        shots2[11] = GameObject.Find("shot11_2").GetComponent<Text>();
        shots2[12] = GameObject.Find("shot12_2").GetComponent<Text>();
        shots2[13] = GameObject.Find("shot13_2").GetComponent<Text>();
        shots2[14] = GameObject.Find("shot14_2").GetComponent<Text>();
        shots2[15] = GameObject.Find("shot15_2").GetComponent<Text>();
        shots2[16] = GameObject.Find("shot16_2").GetComponent<Text>();
        shots2[17] = GameObject.Find("shot17_2").GetComponent<Text>();
        shots2[18] = GameObject.Find("shot18_2").GetComponent<Text>();
        shots2[19] = GameObject.Find("shot19_2").GetComponent<Text>();

        playable = false;

        OverText1 = GameObject.Find("OverallText");
        OverText2 = GameObject.Find("OverallText2");
        winnerP1Text = GameObject.Find("p1win");
        winnerP2Text = GameObject.Find("p2win");


        Ball = GameObject.Find("Ball");
        fps = GameObject.Find("FPSController").GetComponent<Transform>();               //xreiazomaste mono to transform   kai oxi olo to component
        player = GameObject.Find("FirstPersonCharacter").GetComponent<Transform>();

        ballscript = GameObject.Find("Ball").GetComponent<ball>();
        soundScript = GameObject.Find("Ball").GetComponent<soundBall>();

        scoreText = GameObject.Find("pinsKnockedText").GetComponent<Text>();
        score2Text = GameObject.Find("pinsKnockedText 2").GetComponent<Text>();
        shotText = GameObject.Find("ShotText").GetComponent<Text>();
        frameText = GameObject.Find("frameText").GetComponent<Text>();
        playerText = GameObject.Find("playerText").GetComponent<Text>();
        overallText = GameObject.Find("OverallText").GetComponent<Text>();



        for (int i = 0; i < 10; i++)
        {

            initialPinPos[i] = pins[i].transform.position;                  //apo8ikeuoyme tis arxikes 8esis korinwn gia to reser\t
        }

        initialFps = fps.transform.position;
        initialBallPos = Ball.transform.localPosition; //arxiki 8esi balas
        initialPlayerPos = player.transform.position;
        player1Plays = true;

    }

    // Update is called once per frame
    void Update()
    {

        gameOver();

        if (player1Plays == true)
        {
            playerText.text = "P 1";
            frameText.text = "Frame " + frame1;
            OverText1.SetActive(true);
            OverText2.SetActive(false);

            if (shot1 == 1)
            {
                shotText.text = "shot 1";

            }
            else
            {
                shotText.text = "shot 2";
            }
        }
        else
        {
            playerText.text = "P 2";
            frameText.text = "Frame " + frame2;
            OverText1.SetActive(false);
            OverText2.SetActive(true);

            if (shot2 == 1)
            {
                shotText.text = "shot 1";
            }
            else
            {
                shotText.text = "shot 2";
            }
        }
        if (ballscript.BallThrown)
        {
            Invoke("CheckPins", TIMER_SECONDS);
            ballscript.BallThrown = false;

        }

    }


    // check poses pins exoun pesei 
    void CheckPins()
    {

        for (int i = 0; i < 10; i++)
        {
            if (pins[i].transform.rotation.x != 0 && pins[i].transform.rotation.y != 0 && pins[i].transform.rotation.z != 0 && pins[i].active == true)    // an exei alla3ei to rotation tote exei pesei i korina 
            {
                numberOfPinsKnocked++;
            }
        }


        score();


        Invoke("ResetBall", 2);


    }

    // reset korines
    void ResetPins()
    {

        for (int i = 0; i < 10; i++)
        {
            pins[i].GetComponent<Rigidbody>().velocity = Vector3.zero;
            pins[i].GetComponent<Rigidbody>().angularVelocity = Vector3.zero;
            pins[i].transform.position = initialPinPos[i];
            pins[i].transform.eulerAngles = Vector3.zero;


        }
    }

    //reset ball kai paixti
    void ResetBall()
    {

        Ball.transform.parent = player.transform;
        Ball.transform.localPosition = initialBallPos;
        Ball.transform.eulerAngles = Vector3.zero;
        fps.transform.position = initialFps;
        ballscript.rb_ball.useGravity = false;
        ballscript.BallThrown = false;

        soundScript.alreadyPlayed = false;
        ballscript.rb_ball.velocity = Vector3.zero;
        ballscript.rb_ball.angularVelocity = Vector3.zero;



    }


    void score()
    {
        if (player1Plays == true)                                  //paizei 1os paixtis
        {


            if (shot1 == 1)                         //1h volh
            {


                Player1_scoreTable[frame1, 0] = numberOfPinsKnocked;

                finalScore1 = finalScore1 + numberOfPinsKnocked; //sum score 1ou

                scoreText.text = "score P 1   " + finalScore1;


                shots[s1].text = " " + numberOfPinsKnocked;
                s1++;


                if (numberOfPinsKnocked == 10)              //strike stin 1h voli
                {
                    player1Plays = false;
                    Invoke("ResetPins", 2);            //reset korines
                    shot1 = 1;
                    frame1++;
                    s1++;


                }
                else
                {
                    for (int i = 0; i < 10; i++)                //deactive tis korines pou exoyn pesei gia na pame stin 2h voli
                    {
                        if (pins[i].transform.rotation.x != 0 && pins[i].transform.rotation.y != 0 && pins[i].transform.rotation.z != 0)
                        {
                            pins[i].SetActive(false);
                        }
                    }

                    shot1 = 2;

                }

                numberOfPinsKnocked = 0;
                // Debug.Log("shot1 " + shot1);

            }
            else if (shot1 == 2)                       //2h volh
            {
                shotText.text = "shot 2";
                Player1_scoreTable[frame1, 1] = numberOfPinsKnocked;

                finalScore1 = finalScore1 + numberOfPinsKnocked; //sum score 1ou

                scoreText.text = "score P 1   " + finalScore1;

                shots[s1].text = " " + numberOfPinsKnocked;
                s1++;


                for (int i = 0; i < 10; i++)           //activate tis korines 
                {
                    pins[i].SetActive(true);
                }
                player1Plays = false;
                Invoke("ResetPins", 2);            //reset korines

                shot1 = 1;

                frame1++;

                numberOfPinsKnocked = 0;
            }


            Debug.Log("p1 :  " + finalScore1);


        }
        else                                                ///PAIZEI O 2os
        {




            if (shot2 == 1)             //1h volh
            {


                Player2_scoreTable[frame2, 0] = numberOfPinsKnocked;
                finalScore2 = finalScore2 + numberOfPinsKnocked;  //sum score 2ou

                shots2[s2].text = " " + numberOfPinsKnocked;
                s2++;
                score2Text.text = "score P 2   " + finalScore2;




                if (numberOfPinsKnocked == 10)              //strike stin 1h voli
                {
                    player1Plays = true;
                    Invoke("ResetPins", 2);            //reset korines
                    shot2 = 1;
                    frame2++;
                    s2++;

                }
                else
                {
                    for (int i = 0; i < 10; i++)                //deactive tis korines pou exoyn pesei gia na pame stin 2h voli
                    {
                        if (pins[i].transform.rotation.x != 0 && pins[i].transform.rotation.y != 0 && pins[i].transform.rotation.z != 0)
                        {
                            pins[i].SetActive(false);
                        }
                    }

                    shot2 = 2;
                }
                numberOfPinsKnocked = 0;

            }
            else                        //2h volh
            {
                shotText.text = "shot 2";
                Player2_scoreTable[frame2, 1] = numberOfPinsKnocked;

                finalScore2 = finalScore2 + numberOfPinsKnocked; //sum score 2ou


                score2Text.text = "score P 2   " + finalScore2;
                shots2[s2].text = " " + numberOfPinsKnocked;
                s2++;


                for (int i = 0; i < 10; i++)           //activate tis korines 
                {
                    pins[i].SetActive(true);
                }
                player1Plays = true;
                Invoke("ResetPins", 2);            //reset korines

                shot2 = 1;

                frame2++;

                numberOfPinsKnocked = 0;
            }

            overallScore[frame2 - 1, 1] = Player2_scoreTable[frame2 - 1, 0] + Player2_scoreTable[frame2 - 1, 1];

        }



    }

    public Transform canvas;
    public Transform Player;
    public GameObject a;

    public void gameOver()
    {
        if (frame1 > 10 && frame2 > 10)
        {


            finalscore1Text.text = " " + finalScore1;
            finalscore2Text.text = " " + finalScore2;
            if (canvas.gameObject.activeInHierarchy == false)
            {

                canvas.gameObject.SetActive(true);
                Time.timeScale = 0;
                Player.GetComponent<FirstPersonController>().enabled = false;
            }
            else
            {
                canvas.gameObject.SetActive(false);
                Time.timeScale = 1;

                Player.GetComponent<FirstPersonController>().enabled = true;
                a.SetActive(true);

            }

            if (finalScore1 > finalScore2)
            {
                winnerP1Text.SetActive(true);
                winnerP2Text.SetActive(false);

            }
            else
            {
                winnerP1Text.SetActive(false);
                winnerP2Text.SetActive(true);
            }




        }

    }

    void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
    }
}


  

