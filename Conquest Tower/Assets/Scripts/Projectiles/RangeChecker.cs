using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RangeChecker : MonoBehaviour
{
    List<GameObject> _targets = new List<GameObject>();

    //Used to differentiate between enemy and wall
    public List<string> tags;

    //Used to get target
    void OnTriggerEnter(Collider other)
    {
        //checks if we have found the right tag
        bool invalid = true;
        for (int i = 0; i < tags.Count; i++)
        {
            //goes through all the tags that we have
            if (other.CompareTag(tags[i]))
            {
                //if we found the tag we break out instead of keep looping through
                invalid = false;
                break;
            }
        }
        if (invalid)
            return;

        _targets.Add(other.gameObject);
    }

    //Used to remove target
    void OnTriggerExit(Collider other)
    {
        for (int i = 0; i < _targets.Count; i++)
        {
            //If we find the object we can remove it and break out
            //The reason is to avoid targeting non-enemies
            if (other.gameObject == _targets[i])
            {
                _targets.Remove(other.gameObject);
                return;
            }
        }
    }

    public List<GameObject> GetValidatedTargets()
    {
        return _targets;
    }

    //Used to check if a target is in range
    public bool InRange(GameObject go)
    {
        //This has the updated version of what is in range of your turret
        for (int i = 0; i < _targets.Count; i++)
        {
            if (go == _targets[i])
                return true;
        }
        return false;
    }
}
