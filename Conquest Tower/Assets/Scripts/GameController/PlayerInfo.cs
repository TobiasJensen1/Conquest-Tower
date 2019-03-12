using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public float Health;
    public float Coins;

    public Text HealthText;
    public Text CoinsText;

    public GameObject Pause_UI;
    public GameObject ret_but;
    public GameObject qu_but;
    public GameObject gameovertext;
    public GameObject pause;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = Health + "/10";
        CoinsText.text = "" + Coins;
        GameOver();
    }

    void GameOver()
    {
        if(Health <= 0)
        {
     Pause_UI.SetActive(true);
     ret_but.SetActive(true);
     qu_but.SetActive(true);
     gameovertext.SetActive(true);
     pause.SetActive(true);

        }
    }
}
