using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour
{

    //Towers
    public GameObject Cannon;
    public GameObject LaserTower;
    //til klikke kode
    bool CanBuild = false;
    public bool CanUpgrade = false;
    public Camera camera;
    private GameObject Chosen;
    Ray placement;
    Vector3 clickPosition;
    //Information text
    public Text text;
    //Obstruction Check
    public NavMeshAgent spawnPosition;
    Transform targetPosition;
    bool pathAvailable;
    NavMeshPath navMeshPath;
    public List<GameObject> placedTowers = new List<GameObject>();
    GameObject recent;
    GameObject towerToPlace;
    public Material objColor;
    public Material BarrelColor;

    SpriteRenderer sprite;

    //Playerinfo 
    PlayerInfo playerinfo;




    // Start is called before the first frame update
    void Start()
    {

        CanBuild = true;
        CanUpgrade = false;
        navMeshPath = new NavMeshPath();
        targetPosition = GameObject.FindGameObjectWithTag("End").transform;

        InvokeRepeating("CheckPath", 0f, 0.1f);

        playerinfo = GetComponent<PlayerInfo>();

    }

    // Update is called once per frame



    void Update()
    {

        choseTowerPositionText(Chosen);
        
        Ray rayFirst = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFirst;

        if (Physics.Raycast(rayFirst, out hitFirst))
        {

            Vector3 clickPosition1 = hitFirst.point;


            if (towerToPlace != null && Chosen == Cannon)
            {

                sprite = Chosen.transform.GetChild(0).GetComponent<SpriteRenderer>();
                towerToPlace.transform.position = new Vector3(hitFirst.point.x, 0f, hitFirst.point.z);
                Renderer rendTurret = towerToPlace.transform.GetComponent<Renderer>();
                Renderer rendTop = towerToPlace.transform.GetChild(1).GetComponent<Renderer>();
                Renderer rendBarrel = towerToPlace.transform.GetChild(1).transform.GetChild(0).GetComponent<Renderer>();
                sprite.color = new Color(1, 1, 1, .3f);

                sprite.enabled = true;
                if (hitFirst.transform.tag == "Tower" || hitFirst.transform.tag == "Ground")
                {


                    rendTurret.material.SetColor("_Color", Color.red);
                    rendTop.material.SetColor("_Color", Color.red);
                    rendBarrel.material.SetColor("_Color", Color.red);
                }
                else
                {

                    rendTurret.material = objColor;
                    rendTop.material = BarrelColor;
                    rendBarrel.material = BarrelColor;
                }
            }
        }

            if (Input.GetButtonDown("Fire1"))
        {
           
            Destroy(towerToPlace);
            
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
            RaycastHit hit;
            
            if (Physics.Raycast(ray, out hit))
            {
                
                clickPosition = hit.point;
                if (CanBuild)
                {
                    if (Chosen != null && hit.transform.tag != "Tower" && hit.transform.tag != "Ground" && playerinfo.Coins >= 50)
                    {
                        recent = Instantiate(Chosen, new Vector3(hit.point.x, -0.5f, hit.point.z), Quaternion.identity);
                        playerinfo.Coins -= 50;
                        sprite = recent.transform.GetChild(0).GetComponent<SpriteRenderer>();
                        sprite.enabled = false;
                        recent.transform.gameObject.transform.GetChild(2).transform.gameObject.layer = 9;
                        placedTowers.Add(recent);
                        placerText(Chosen);
                        }
                    }
                    CanUpgrade = true;
                    GetComponent<UpgradeSellTower>().enabled = true;
                    Chosen = null; 
                }
            }
        }
   

    public void placeCannonTower()
    {

        Chosen = Cannon;
        towerToPlace = Instantiate(Chosen);
        towerToPlace.layer = 2;
        towerToPlace.GetComponent<BoxCollider>().enabled = false;
        towerToPlace.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour>().enabled = false;
        towerToPlace.GetComponent<NavMeshObstacle>().enabled = false;
        CanUpgrade = false;
        GetComponent<UpgradeSellTower>().enabled = false;
    }



    bool CalculateNewPath()
    {
        
            spawnPosition.CalculatePath(targetPosition.position, navMeshPath);
            print("New path calculated");
            if (navMeshPath.status != NavMeshPathStatus.PathComplete)
            {
                return false;
            }
            else
            {
                return true;
            }
        
    }

    void CheckPath()
    {
        if (!CalculateNewPath())
        {
            GameObject destroy = placedTowers[placedTowers.Count-1];
            Destroy(destroy);
            playerinfo.Coins += 50;
            text.text = "Path Blocked!";
            placedTowers.RemoveAt(placedTowers.Count - 1);

        }
    }


    public void placerText(GameObject Chosen)
    {
        if (Chosen == Cannon)
        {
            text.text = "Cannon Placed!";
        }
    }

    public void choseTowerPositionText(GameObject Chosen)
    {
        if (Chosen == Cannon)
        {
            text.text = "Click where you want to place a Cannon!";
        }
    }
}
 
 