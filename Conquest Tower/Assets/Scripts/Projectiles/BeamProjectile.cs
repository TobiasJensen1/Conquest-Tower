using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BeamProjectile : BaseProjectile
{
    public float beamLength = 10.0f;
    GameObject _launcher;
    GameObject _target;
    int _damage;
    float _attackSpeed;
    float _attackTimer;

    // Update is called once per frame
    void Update()
    {
        _attackTimer += Time.deltaTime;

        if (_launcher)
        {
            GetComponent<LineRenderer>().SetPosition(0, _launcher.transform.position);
            GetComponent<LineRenderer>().SetPosition(1, _launcher.transform.position + (_launcher.transform.forward * beamLength));
            RaycastHit hit;

            if (Physics.Raycast(_launcher.transform.position, _launcher.transform.forward, out hit, beamLength))
            {
                if (hit.transform.gameObject == _target)
                {
                    //To be checked on
                    //if (m_attackTimer >= m_attackSpeed)
                    //{
                    //    DamageData dmgData = new DamageData();
                    //    dmgData.damage = m_damage;

                    //    MessageHandler msgHandler = m_target.GetComponent<MessageHandler>();

                    //    if (msgHandler)
                    //    {
                    //        msgHandler.GiveMessage(MessageType.DAMAGED, m_launcher, dmgData);
                    //    }

                    //    m_attackTimer = 0.0f;
                    //}
                }
            }
        }
    }

    public override void FireProjectile(GameObject launcher, GameObject target, 
        int damage, float attackSpeed)
    {
        if (launcher)
        {
            _launcher = launcher;
            _target = target;
            _damage = damage;
            _attackSpeed = attackSpeed;
            _attackTimer = 0.0f;
        }
    }
}
