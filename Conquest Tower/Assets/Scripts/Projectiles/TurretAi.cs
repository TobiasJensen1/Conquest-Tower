using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretAi : MonoBehaviour
{
    public enum AiStates {
        NEAREST,
        FURTHEST
    };

    //the ai state will be the nearest by default
    public AiStates aiState = AiStates.NEAREST;

    //To make it function we need to use the scripts we made
    TrackingSystem _tracker;
    ShootingSystem _shooter;
    RangeChecker _range;

    // Use this for initialization
    void Start()
    {
        //Getting the scripts
        _tracker = GetComponent<TrackingSystem>();
        _shooter = GetComponent<ShootingSystem>();
        _range = GetComponent<RangeChecker>();
    }

    // Update is called once per frame
    void Update()
    {
        //If we don't have any of the 3 scripts, we don't update, we return
        if (!_tracker || !_shooter || !_range)
            return;

        switch (aiState)
        {
            case AiStates.NEAREST:
                TargetNearest();
                break;
            case AiStates.FURTHEST:
                TargetFurthest();
                break;
        }
    }

    void TargetNearest()
    {
        //Retrieving the list the rangechecker have made
        List<GameObject> validatedTargets = _range.GetValidatedTargets();
        //Set to null to avoid error
        GameObject currentTarget = null;
        float closestDistance = 0.0f;

        for (int i = 0; i < validatedTargets.Count; i++)
        {
            //gets the current distance
            float distance = Vector3.Distance(transform.position, 
                validatedTargets[i].transform.position);

            if (!currentTarget || distance < closestDistance)
            {
                currentTarget = validatedTargets[i];
                closestDistance = distance;
            }
        }

        _tracker.SetTarget(currentTarget);
        _shooter.SetTarget(currentTarget);
    }

    void TargetFurthest()
    {
        List<GameObject> validatedTargets = _range.GetValidatedTargets();

        GameObject currentTarget = null;
        float furthestDistance = 0.0f;

        for (int i = 0; i < validatedTargets.Count; i++)
        {
            float distance = Vector3.Distance(transform.position, 
                validatedTargets[i].transform.position);

            if (!currentTarget || distance > furthestDistance)
            {
                currentTarget = validatedTargets[i];
                furthestDistance = distance;
            }
        }
        _tracker.SetTarget(currentTarget);
        _shooter.SetTarget(currentTarget);
    }
}
/*
 * Extra code from guide used
 * 
 * Used in switch:
 *          case AiStates.WEAKEST:
                TargetWeakest();
                break;
            case AiStates.STRONGEST:
                TargetStrongest();
                break;
 * 
 * 
 * void TargetWeakest()
    {
        List<GameObject> validTargets = m_range.GetValidatedTargets();

        GameObject curTarget = null;
        int lowestHealth = 0;

        for (int i = 0; i < validTargets.Count; i++)
        {
            int maxHp = validTargets[i].GetComponent<Health>().maxHealth;

            if (!curTarget || maxHp < lowestHealth)
            {
                lowestHealth = maxHp;
                curTarget = validTargets[i];
            }
        }

        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);
    }

    void TargetStrongest()
    {
        List<GameObject> validTargets = m_range.GetValidatedTargets();

        GameObject curTarget = null;
        int highestHealth = 0;

        for (int i = 0; i < validTargets.Count; i++)
        {
            int maxHp = validTargets[i].GetComponent<Health>().maxHealth;

            if (!curTarget || maxHp > highestHealth)
            {
                highestHealth = maxHp;
                curTarget = validTargets[i];
            }
        }

        m_tracker.SetTarget(curTarget);
        m_shooter.SetTarget(curTarget);
    }
 */
