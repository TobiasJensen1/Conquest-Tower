using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{

    public AudioClip WaveHorn;

    public GameObject Npc;
    public GameObject button;


    public Text waveText;
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
        waveText.text = "Wave " + waveCount;
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
            npcAmount = 2;
            button.GetComponent<Button>().interactable = false;
            for (int i = 0; i < npcAmount; i++)
            {
          
               GameObject newSpider = Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.1f);
                newSpider.GetComponent<Animation>().Play("jump");
                yield return new WaitForSeconds(1.1f);
                newSpider.GetComponent<Animation>().Play("run");

                yield return new WaitForSeconds(2);
                
               
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 100;
        
        
    }

    IEnumerator startWave2()
    {
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 2)
        {
            npcAmount = 5;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(1);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 300;
        
    }

    IEnumerator startWave3()
    {
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 3)
        {
            npcAmount = 10;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 700;
        
    }
    IEnumerator startWave4()
    {
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 4)
        {
            npcAmount = 15;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 1050;
        
    }
    IEnumerator startWave5()
    {
        waveCount++;
        GetComponent<AudioSource>().Play();
        if (wave == 5)
        {
            npcAmount = 20;
            button.GetComponent<Button>().interactable = false;

            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(0.5f);
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
        tc.GetComponent<PlayerInfo>().Coins += 1543785;
        
    }
}
