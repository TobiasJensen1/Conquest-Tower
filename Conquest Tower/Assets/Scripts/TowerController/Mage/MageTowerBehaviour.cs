using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MageTowerBehaviour : MonoBehaviour
{
    //Target
    private Transform target = null;
    private Transform targetEnemy;
    //Fire
    public Transform CrystalSpawn;
    public Rigidbody Crystal;
    public Rigidbody Crystal1;
    public Rigidbody Crystal2;

    [Header("Optional")]
    public float CrystalSpeed = 10f;
    public float range = 20;
    public float turnSpeed = 10f;
    public float level = 1;

    public string enemyTag = "Ground";

    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("FireTest", 0.5f, 1.5f);
    }


    // Update is called once per frame
    void Update()
    {
        if (target)
        {
            LockOnTarget();
        }

    }

    void UpdateTarget()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nearestEnemy = null;
        foreach (GameObject enemy in enemies)
        {
            float distanceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if (distanceToEnemy < shortestDistance)
            {
                shortestDistance = distanceToEnemy;
                nearestEnemy = enemy;
            }
        }

        if (nearestEnemy != null && shortestDistance <= range)
        {
            target = nearestEnemy.transform;
            targetEnemy = nearestEnemy.transform;
        }
        else
        {
            target = null;
        }
    }

    void LockOnTarget()
    {
        
        Vector3 dir = target.position - new Vector3(transform.GetChild(0).transform.GetChild(0).transform.position.x, transform.GetChild(0).transform.GetChild(0).transform.position.y, transform.GetChild(0).transform.GetChild(0).transform.position.z);
        Quaternion lookRotation = Quaternion.LookRotation(dir);
        Vector3 rotation = Quaternion.Slerp(transform.GetChild(0).transform.GetChild(0).rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
        transform.GetChild(0).transform.GetChild(0).rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
        
    }

    void FireTest()
    {
        if (target != null)
        {
            GetComponent<AudioSource>().Play();
            if (level == 1)
            {
                Rigidbody bulletClone = Instantiate(Crystal, CrystalSpawn.transform.position, CrystalSpawn.transform.rotation);
                bulletClone.velocity = transform.GetChild(0).transform.GetChild(0).transform.forward * CrystalSpeed;
                
            }
            if (level == 2)
            {
                Rigidbody bulletClone = Instantiate(Crystal1, CrystalSpawn.transform.position, CrystalSpawn.transform.rotation);
                bulletClone.velocity = transform.GetChild(0).transform.GetChild(0).transform.forward * CrystalSpeed;
            }
            if (level == 3)
            {
                Rigidbody bulletClone = Instantiate(Crystal2, CrystalSpawn.transform.position, CrystalSpawn.transform.rotation);
                bulletClone.velocity = transform.GetChild(0).transform.GetChild(0).transform.forward * CrystalSpeed;
            }

        }
    }
}
