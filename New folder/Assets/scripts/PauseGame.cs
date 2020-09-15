using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityStandardAssets.Characters.FirstPerson;
using UnityEngine.SceneManagement;

public class PauseGame : MonoBehaviour {
    public Transform canvas;
    public Transform Player;
    public GameObject a;
   


    // Update is called once per frame
    void Update () {
	    if (Input.GetKeyDown(KeyCode.Escape))
        {
           a.SetActive(false);
            Pause();
           

        }
	}
    public void Pause()
    {   
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

        
    }

    public void RestartGame()
    {
        //a.SetActive(false);

        canvas.gameObject.SetActive(false);
            Time.timeScale = 1;
            Player.GetComponent<FirstPersonController>().enabled = true;
        SceneManager.LoadScene("Bowl");
    }

    public void Exit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
		Application.Quit ();
#endif
    }
}
