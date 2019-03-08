using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.UI;

public class TowerPlacer : MonoBehaviour
{
    //Test
    public GameObject Testers;
    //knapper
    public GameObject SellBut;
    public GameObject Upgradebut;
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
    



    // Start is called before the first frame update
    void Start()
    {

        CanBuild = true;
        CanUpgrade = false;
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);
        navMeshPath = new NavMeshPath();
        targetPosition = GameObject.FindGameObjectWithTag("End").transform;

        InvokeRepeating("CheckPath", 0f, 0.1f);

    }

    // Update is called once per frame



    void Update()
    {

        choseTowerPositionText(Chosen);
        
        Ray rayFirst = Camera.main.ScreenPointToRay(Input.mousePosition);
        RaycastHit hitFirst;
        
        if (Physics.Raycast(rayFirst, out hitFirst)){

            Vector3 clickPosition1 = hitFirst.point;


            if(towerToPlace != null && Chosen == Cannon)
            {
                
                
                SpriteRenderer sprite = towerToPlace.transform.GetChild(4).GetComponent<SpriteRenderer>();
                towerToPlace.transform.position = new Vector3(hitFirst.point.x, 0f, hitFirst.point.z);
                Renderer CannonBase = towerToPlace.transform.GetChild(0).GetComponent<Renderer>();
                Renderer CannonBarrel = towerToPlace.transform.GetChild(1).GetComponent<Renderer>();
                Renderer CannonBall = towerToPlace.transform.GetChild(2).GetComponent<Renderer>();
                
                sprite.color = new Color(1, 1, 1, .3f);
                
                sprite.enabled = true;
                if (hitFirst.transform.tag == "Tower" || hitFirst.transform.tag == "Ground")
                {


                    CannonBase.material.SetColor("_Color", Color.red);
                    CannonBarrel.material.SetColor("_Color", Color.red);
                    CannonBall.material.SetColor("_Color", Color.red);
                } else
                {

                    CannonBase.material = objColor;
                    CannonBarrel.material = BarrelColor;
                    CannonBall.material = BarrelColor;
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

                    print(hit.transform.tag);
                    if (Chosen != null && hit.transform.tag != "Tower" && hit.transform.tag != "Ground")
                    {
                        recent = Instantiate(Chosen, new Vector3(hit.point.x, -0.5f, hit.point.z), Quaternion.identity);
                        recent.transform.gameObject.transform.GetChild(5).transform.gameObject.layer = 9;
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
    
    public void placeLaserTower()
    {
        Chosen = LaserTower;
        
        CanUpgrade = false;
        GetComponent<UpgradeSellTower>().enabled = false;
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);

    }

    public void placeCannonTower()
    {
        Chosen = Cannon;
        towerToPlace = Instantiate(Chosen);
        towerToPlace.layer = 2;
        towerToPlace.GetComponent<BoxCollider>().enabled = false;
        towerToPlace.transform.gameObject.transform.GetChild(1).GetComponent<CannonBehaviour2>().enabled = false;
        towerToPlace.transform.gameObject.transform.GetChild(0).GetComponent<NavMeshObstacle>().enabled = false;
        towerToPlace.transform.gameObject.transform.GetChild(0).GetComponent<NavMeshObstacle>().enabled = false;
        CanUpgrade = false;
        GetComponent<UpgradeSellTower>().enabled = false;
        SellBut.SetActive(false);
        Upgradebut.SetActive(false);

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
            text.text = "Path Blocked!";
            placedTowers.RemoveAt(placedTowers.Count - 1);

        }
    }


    public void placerText(GameObject Chosen)
    {
        if (Chosen == LaserTower)
        {
            text.text = "Laser Tower Placed!";
        }
        if (Chosen == Cannon)
        {
            text.text = "Cannon Placed!";
        }
    }

    public void choseTowerPositionText(GameObject Chosen)
    {
        if (Chosen == LaserTower)
        {
            text.text = "Click where you want to place a Laser Tower!";
        }
        if (Chosen == Cannon)
        {
            text.text = "Click where you want to place a Cannon!";
        }
    }
}
 