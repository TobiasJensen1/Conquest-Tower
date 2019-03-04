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
        npcAmount = 1;

    }

    // Update is called once per frame
    void Update()
    {
        
    }


    public void initiateWave()
    {
        for (int i = 0; i < npcAmount; i++)
        {
            Instantiate(Npc, transform.position, Quaternion.identity);
        }

        npcAmount += 5;
        wave++;
        button.GetComponentInChildren<Text>().text = "Start Wave " + wave;
    }
}
