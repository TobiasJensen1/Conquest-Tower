using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseScript : MonoBehaviour
{
    public GameObject pause;
    public GameObject Pause_Start_UI;
    public GameObject start_text;
    // Start is called before the first frame update
    void Start()
    {
        //Time.timeScale = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void StopPause()
    {
        pause.SetActive(false);
        gameObject.SetActive(false);
        Pause_Start_UI.SetActive(false);
        start_text.SetActive(false);
    }

    public void Retry()
    {
        SceneManager.LoadScene("ConquestTower");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }
}
