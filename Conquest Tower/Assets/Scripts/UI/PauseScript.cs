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
        GetComponent<AudioSource>().Play();
        
        StartCoroutine("farvel");
        
    }

    public void Retry()
    {
        SceneManager.LoadScene("ConquestTower");
    }
    public void Quit()
    {
        SceneManager.LoadScene("MainMenu");
    }

    IEnumerator farvel()
    {
        yield return new WaitForSeconds(0.3f);
        Pause_Start_UI.SetActive(false);
        pause.SetActive(false);
        gameObject.SetActive(false);
        start_text.SetActive(false);
    }
}
