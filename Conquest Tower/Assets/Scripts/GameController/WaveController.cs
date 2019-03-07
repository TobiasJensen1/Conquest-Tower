using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class WaveController : MonoBehaviour
{

    public GameObject Npc;
    public GameObject button;
    [SerializeField]
    private int npcAmount;
    private int wave = 1;

    // Start is called before the first frame update
    void Start()
    {
        wave = 1;
        button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
        npcAmount = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
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

        if (wave == 1)
        {
            npcAmount = 2;
            button.GetComponent<Button>().interactable = false;
            for (int i = 0; i < npcAmount; i++)
            {
                Instantiate(Npc, transform.position, Quaternion.identity);
                yield return new WaitForSeconds(2);    
            }
            wave++;
            button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
            button.GetComponent<Button>().interactable = true;
        }
    }

    IEnumerator startWave2()
    {
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

    }

    IEnumerator startWave3()
    {
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

    }
    IEnumerator startWave4()
    {
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

    }
    IEnumerator startWave5()
    {
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

    }
}
