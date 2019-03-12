using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{

    public AudioClip WaveHorn;

    public GameObject Npc;
    public GameObject boss;
    public GameObject button;


    public Text waveText;
    public Text informationText;
    public GameObject tc;
    PlayerInfo playerinfo;
    [SerializeField]
    private int npcAmount;
    private int wave = 1;
    private int waveCount = 1;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
        npcAmount = 1;

        playerinfo = GetComponent<PlayerInfo>();
      GetComponent<AudioSource>().clip = WaveHorn;
    }

    // Update is called once per frame
    void Update()
    {
        if (wave == 5)
        {
            waveText.text = "Final Wave!";
        }
        else
        {
            waveText.text = "Wave " + waveCount;
        }
    }


    public void initiateWave()
    {
        if (wave == 1)
        {
            StartCoroutine("startWave1");
        }
        if(wave == 2)
        {
            StartCoroutine("startWave2");
        }
        if(wave == 3)
        {
            StartCoroutine("startWave3");
        }
        if (wave == 4)
        {
            StartCoroutine("startWave4");
        }
        if (wave == 5)
        {
            StartCoroutine("startWave5");
        }
    }

    IEnumerator startWave1()
    {
        GetComponent<AudioSource>().Play();
        if (wave == 1)
        {
            informationText.text = "Wave 1 Incoming!";
            npcAmount = 2;
            button.GetComponent<Button>().interactable = false;
            
            for (int i = 0; i < npcAmount; i++)
            {
                
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2f);
                
               
            }
            

            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 100;
        
        
    }

    IEnumerator startWave2()
    {
        informationText.text = "Wave 2 Incoming!";
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 2)
        {
            npcAmount = 5;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 300;
        
    }

    IEnumerator startWave3()
    {
        informationText.text = "Wave 3 Incoming!";
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 3)
        {
            npcAmount = 10;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 700;
        
    }
    IEnumerator startWave4()
    {
        informationText.text = "Wave 4 Incoming!";
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 4)
        {
            npcAmount = 15;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1f);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Final Wave";
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 1050;
        
    }
    IEnumerator startWave5()
    {
        informationText.text = "Final Wave Incoming!";
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 5)
        {
            npcAmount = 20;
            button.GetComponent<Button>().interactable = false;


            GameObject hej = Instantiate(boss, transform.position, Quaternion.identity);
            hej.GetComponent<Animator>().Play("rockgolem_walk01");

            
            button.GetComponent<Button>().interactable = false;
        }
        tc.GetComponent<PlayerInfo>().Coins += 1543785;
        yield return null;
    }

}
