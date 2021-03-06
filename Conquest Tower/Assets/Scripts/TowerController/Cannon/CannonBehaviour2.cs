﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CannonBehaviour2 : MonoBehaviour
{
    //Target
    private Transform target = null;
    private Transform targetEnemy;
    //Fire
    public Transform CannonBallSpawn;
    public Rigidbody CannonBall;
    [Header("Optional")]
    public float CannonBallSpeed = 10f;
    public float range = 15f;
    public float turnSpeed = 10f;


    public string enemyTag = "Ground";


    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("UpdateTarget", 0f, 0.5f);
        InvokeRepeating("FireTest", 1f, 1.5f);
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

            Vector3 dir = target.position - transform.position;
            Quaternion lookRotation = Quaternion.LookRotation(dir);
            Vector3 rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * turnSpeed).eulerAngles;
            transform.rotation = Quaternion.Euler(rotation.x, rotation.y, rotation.z);
            

        }


        void FireTest()
        {
            if (target != null)
            {
                Rigidbody bulletClone = Instantiate(CannonBall, CannonBallSpawn.transform.position, CannonBallSpawn.transform.rotation);
                bulletClone.velocity = transform.forward * CannonBallSpeed;


            }
        }
    }

