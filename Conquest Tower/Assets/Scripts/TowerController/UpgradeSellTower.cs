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

    public Material color;

    public Text sidebartext;

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
        if(chosenTower != null)
        {
            if(chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level == 3)
            {
                UpgradeBut.GetComponent<Button>().interactable = false;
                UpgradeBut.GetComponentInChildren<Text>().text = "Max Level!";
            } else
            {
                UpgradeBut.GetComponent<Button>().interactable = true;
                UpgradeBut.GetComponentInChildren<Text>().text = "Upgrade Tower";
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
                placedTowers[i].gameObject.transform.GetChild(0).GetComponent<SpriteRenderer>().enabled = false;
                placedTowers[i].transform.GetComponent<Renderer>().material = color;
                placedTowers[i].transform.GetChild(1).GetComponent<Renderer>().material = color;
                placedTowers[i].transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>().material = color;
            }

            if (Physics.Raycast(ray, out hit))
            {
                clickPosition = hit.point;

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
                }
                else
                {
                    SellBut.SetActive(false);
                    UpgradeBut.SetActive(false);
                    rendTurret = chosenTower.transform.GetComponent<Renderer>();
                    rendTop = chosenTower.transform.GetChild(1).GetComponent<Renderer>();
                    rendBarrel = chosenTower.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>();
                    rendTurret.material = color;
                    rendTop.material = color;
                    rendBarrel.material = color;
                    sidebartext.enabled = false;

                }
            }
            
        }
    }
    
    public void SellTower()
    {
        Destroy(chosenTower);
        int place = placedTowers.IndexOf(chosenTower);
        placedTowers.RemoveAt(place);
        float towerLevel = chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level;
        if(towerLevel == 1)
        {
            playerinfo.Coins += 5000;
        }
        if (towerLevel == 2)
        {
            playerinfo.Coins += 10000;
        }
        if(towerLevel == 3)
        {
            playerinfo.Coins += 3;
        }
        chosenTower = null;
        SellBut.SetActive(false);
        UpgradeBut.SetActive(false);
        sidebartext.enabled = false;
    }

    public void UpgradeTower()
    {
        
        chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level++;
        SellBut.SetActive(false);
        UpgradeBut.SetActive(false);
        sidebartext.enabled = false;
    }

    public void SidebarText(Text text, GameObject tower)
    {
        text.enabled = true;
        text.text = "Cannon" +

        "\n\nLevel: "+ tower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().level + " / 3" +

        "\n\nDamage: "+ chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBall.GetComponent<CannonBulletCollision>().damage+"" +

        "\n\nSpeed: "+ chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().CannonBallSpeed+""+

        "\n\nRange: "+ chosenTower.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().range+"";
    }
}

