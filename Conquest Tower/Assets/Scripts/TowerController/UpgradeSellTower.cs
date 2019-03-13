using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UpgradeSellTower : MonoBehaviour
{


    Vector3 clickPosition;


    //Sell/Upgrade
    public GameObject SellBut;
    GameObject chosenTower;

    public GameObject UpgradeBut;

    bool CanUpgradenew;

    PlayerInfo playerinfo;

    public Material cannonColor;

    public Material mageColor;

    public Text sidebartext;
    public Text sellText;
    public Text upgradeText;

    //sounds
    public AudioClip upgrade;
    public AudioClip sell;



    //Tower Range
    SpriteRenderer sprite;
    List<GameObject> placedTowers = new List<GameObject>();





    // Start is called before the first frame update
    void Start()
    {
        playerinfo = GetComponent<PlayerInfo>();
    }

     void OnEnable()
    {
        GameObject towercontroller = GameObject.Find("TowerController");
        TowerPlacer towerplacer = towercontroller.GetComponent<TowerPlacer>();
        CanUpgradenew = towerplacer.CanUpgrade;
        placedTowers = towerplacer.placedTowers;
    }

    // Update is called once per frame
    void Update()
    {
        if (chosenTower != null)
        {
            if (chosenTower.gameObject.name == "Tower Mage(Clone)")
            {
                if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 3)
                {
                    UpgradeBut.GetComponent<Button>().interactable = false;
                    UpgradeBut.GetComponentInChildren<Text>().text = "Max Level!";
                }
                else
                {
                    UpgradeBut.GetComponent<Button>().interactable = true;
                    UpgradeBut.GetComponentInChildren<Text>().text = "Upgrade Tower";
                }
            }
            else
            {
                if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 3)
                {
                    UpgradeBut.GetComponent<Button>().interactable = false;
                    UpgradeBut.GetComponentInChildren<Text>().text = "Max Level!";
                }
                else
                {
                    UpgradeBut.GetComponent<Button>().interactable = true;
                    UpgradeBut.GetComponentInChildren<Text>().text = "Upgrade Tower";
                }

            }
        }
        


        if (Input.GetButtonDown("Fire1"))
        {
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;

            Renderer rendTurret;
            Renderer rendTop;
            Renderer rendBarrel;

            for (int i = 0; i < placedTowers.Count; i++)
            {
                if (placedTowers[i].name == "Tower Mage(Clone)")
                {
                    placedTowers[i].gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    placedTowers[i].transform.GetComponent<Renderer>().material = mageColor;
                    placedTowers[i].transform.GetChild(1).GetComponent<Renderer>().material = mageColor;
                    placedTowers[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().material = mageColor;
                }
                else
                {
                    placedTowers[i].gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                    placedTowers[i].transform.GetComponent<Renderer>().material = cannonColor;
                    placedTowers[i].transform.GetChild(1).GetComponent<Renderer>().material = cannonColor;
                    placedTowers[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().material = cannonColor;
                }
            }

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;

                if (hit.collider.gameObject.layer != 10)
                {
                    if (hit.transform.tag == "Tower" && CanUpgradenew && hit.collider.gameObject.transform.tag != "TurretHitbox")
                    {
                        //poppe knapper op "upgrade" "Sell" "info om tower"
                        chosenTower = hit.transform.gameObject;
                        SpriteRenderer sprite = hit.transform.gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>();
                        sprite.enabled = true;
                        rendTurret = chosenTower.transform.GetComponent<Renderer>();
                        rendTop = chosenTower.transform.GetChild(1).GetComponent<Renderer>();
                        rendBarrel = chosenTower.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>();
                        SellBut.SetActive(true);
                        UpgradeBut.SetActive(true);
                        rendTurret.material.SetColor("_Color", Color.yellow);
                        rendTop.material.SetColor("_Color", Color.yellow);
                        rendBarrel.material.SetColor("_Color", Color.yellow);
                        SidebarText(sidebartext, chosenTower);

                        if(chosenTower.gameObject.name == "Tower Mage(Clone)")
                        {
                            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 1)
                            {
                                sellText.text = "Sell Value: 25";
                                upgradeText.text = "Upgrade Cost: 100";
                            }
                            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 2)
                            {
                                sellText.text = "Sell Value: 50";
                                upgradeText.text = "Upgrade Cost: 300";
                            }
                            if(chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 3)
                            {
                                sellText.text = "Sell Value: 150";
                                upgradeText.text = "";
                            }
                        } else
                        {
                            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 1)
                            {
                                sellText.text = "Sell Value: 25";
                                upgradeText.text = "Upgrade Cost: 100";
                            }
                            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 2)
                            {
                                sellText.text = "Sell Value: 50";
                                upgradeText.text = "Upgrade Cost: 300";
                            }
                            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 3)
                            {
                                sellText.text = "Sell Value: 150";
                                upgradeText.text = "";
                            }
                        }
                    }
                    else
                    {
                        SellBut.SetActive(false);
                        UpgradeBut.SetActive(false);
                        if (chosenTower.gameObject.name == "Tower Mage(Clone)")
                        {
                            rendTurret = chosenTower.transform.GetComponent<Renderer>();
                            rendTop = chosenTower.transform.GetChild(1).GetComponent<Renderer>();
                            rendBarrel = chosenTower.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>();
                            rendTurret.material = mageColor;
                            rendTop.material = mageColor;
                            rendBarrel.material = mageColor;
                            sidebartext.enabled = false;
                            
                        }
                        else
                        {
                            rendTurret = chosenTower.transform.GetComponent<Renderer>();
                            rendTop = chosenTower.transform.GetChild(1).GetComponent<Renderer>();
                            rendBarrel = chosenTower.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>();
                            rendTurret.material = cannonColor;
                            rendTop.material = cannonColor;
                            rendBarrel.material = cannonColor;
                            sidebartext.enabled = false;
                        }

                    }
                    
                }
                
            }
            
        }
    }
    
    public void SellTower()
    {
        //audio
        GetComponent<AudioSource>().clip = sell;
        sellText.text = "";
        upgradeText.text = "";
        Destroy(chosenTower);
        int place = placedTowers.IndexOf(chosenTower);
        placedTowers.RemoveAt(place);
        float towerLevel;
        if (chosenTower.gameObject.name == "Tower Mage(Clone)"){
            towerLevel = chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level;
        }
        else {
            towerLevel = chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level;
        }


        if (towerLevel == 1)
        {
            playerinfo.Coins += 25;
            GetComponent<AudioSource>().Play();
        }
        if (towerLevel == 2)
        {
            playerinfo.Coins += 50;
            GetComponent<AudioSource>().Play();
        }
        if(towerLevel == 3)
        {
            playerinfo.Coins += 150;
            GetComponent<AudioSource>().Play();
        }
        chosenTower = null;
        SellBut.SetActive(false);
        UpgradeBut.SetActive(false);
        sidebartext.enabled = false;
    }

    public void UpgradeTower()
    {
        //audio
        GetComponent<AudioSource>().clip = upgrade;
        sellText.text = "";
        upgradeText.text = "";
        if (chosenTower.gameObject.name == "Tower Mage(Clone)")
        {

            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 1 && playerinfo.Coins >= 100)
            {
                print("upgrade 1");
                chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level++;
                playerinfo.Coins -= 100;
                
                GetComponent<AudioSource>().Play();
            }
           else if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 2 && playerinfo.Coins >= 300)
            {
                print("upgrade 2");
                chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level++;
                playerinfo.Coins -= 300;

                GetComponent<AudioSource>().Play();
            }
        }
        else
        {

            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 1 && playerinfo.Coins >= 100)
            {
                chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level++;
                playerinfo.Coins -= 100;

                GetComponent<AudioSource>().Play();
            }
           else if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 2 && playerinfo.Coins >= 300)
            {
                chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level++;
                playerinfo.Coins -= 300;

                GetComponent<AudioSource>().Play();
            }
        }

        SellBut.SetActive(false);
        UpgradeBut.SetActive(false);
        sidebartext.enabled = false;
    }

    public void SidebarText(Text text, GameObject tower)
    {
        string towerText = "";
        text.enabled = true;

        if (chosenTower.gameObject.name == "Tower Mage(Clone)")
        {
            towerText += 
                "Mage Tower" +

                "\n\nLevel: " + tower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level + " / 3";

            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 1)
            {
                towerText += "\n\nDamage: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().Crystal.GetComponent<CannonBulletCollision>().damage + "";
            }
            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 2)
            {
                towerText += "\n\nDamage: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().Crystal1.GetComponent<CannonBulletCollision>().damage + "";
            }
            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().level == 3)
            {
                towerText += "\n\nDamage: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().Crystal2.GetComponent<CannonBulletCollision>().damage + "";
            }
            towerText += "\n\nSpeed: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().CrystalSpeed + "" +

            "\n\nRange: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<MageTowerBehaviour>().range + "";


            text.text = towerText;

        }
        else
        {


            towerText +=
            "Cannon" +

                "\n\nLevel: " + tower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level + " / 3";

            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 1)
            {
                towerText += "\n\nDamage: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBall.GetComponent<CannonBulletCollision>().damage + "";
            }
            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 2)
            {
                towerText += "\n\nDamage: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBall1.GetComponent<CannonBulletCollision>().damage + "";
            }
            if (chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 3)
            {
                towerText += "\n\nDamage: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBall2.GetComponent<CannonBulletCollision>().damage + "";
            }
            towerText += "\n\nSpeed: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBallSpeed + "" +

            "\n\nRange: " + chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().range + "";


            text.text = towerText;
        }
    }
}

