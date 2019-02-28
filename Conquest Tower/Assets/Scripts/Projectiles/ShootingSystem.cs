using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShootingSystem : MonoBehaviour
{
    public float fireRate;
    public int damage;
    public float fieldOfView;
    public bool beam;
    public GameObject projectile;
    public List<GameObject> projectileSpawns;

    List<GameObject> _lastProjectiles = new List<GameObject>();
    float _fireTimer = 0.0f;
    GameObject _target;

    // Update is called once per frame
    void Update()
    {
        if (!_target)
        {
            if (beam)
                RemoveLastProjectiles();

            return;
        }

        if (beam && _lastProjectiles.Count <= 0)
        {
            float angle = Quaternion.Angle(transform.rotation, 
                Quaternion.LookRotation(_target.transform.position - transform.position));

            if (angle < fieldOfView)
            {
                SpawnProjectiles();
            }
        }
        else if (beam && _lastProjectiles.Count > 0)
        {
            float angle = Quaternion.Angle(transform.rotation, 
                Quaternion.LookRotation(_target.transform.position - transform.position));

            if (angle > fieldOfView)
            {
                RemoveLastProjectiles();
            }
        }
        else
        {
            _fireTimer += Time.deltaTime;

            if (_fireTimer >= fireRate)
            {
                float angle = Quaternion.Angle(transform.rotation, 
                    Quaternion.LookRotation(_target.transform.position - transform.position));

                if (angle < fieldOfView)
                {
                    SpawnProjectiles();

                    _fireTimer = 0.0f;
                }
            }
        }
    }

    void SpawnProjectiles()
    {
        if (!projectile)
        {
            return;
        }

        _lastProjectiles.Clear();

        for (int i = 0; i < projectileSpawns.Count; i++)
        {
            if (projectileSpawns[i])
            {
                GameObject proj = Instantiate(projectile, projectileSpawns[i].transform.position, 
                    Quaternion.Euler(projectileSpawns[i].transform.forward)) as GameObject;

                proj.GetComponent<BaseProjectile>().FireProjectile(projectileSpawns[i], 
                    _target, damage, fireRate);

                _lastProjectiles.Add(proj);
            }
        }
    }

    public void SetTarget(GameObject target)
    {
        _target = target;
    }

    void RemoveLastProjectiles()
    {
        while (_lastProjectiles.Count > 0)
        {
            Destroy(_lastProjectiles[0]);
            _lastProjectiles.RemoveAt(0);
        }
    }
}
