using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerInfo : MonoBehaviour
{

    public float Health;
    public float Coins;

    public Text HealthText;
    public Text CoinsText;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        HealthText.text = Health + "/10";
        CoinsText.text = "" + Coins;
    }
}
