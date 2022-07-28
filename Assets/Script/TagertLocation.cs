using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TagertLocation : MonoBehaviour
{
    [SerializeField] Transform weapon;
    [SerializeField] float range = 15f;
    [SerializeField] ParticleSystem projectitleParticles;
    Transform target;

    
    public void Update()
    {
        FindCloseObject();
        AimWeapon();
    }

    public void FindCloseObject()
    {
        Enemy[] enemies = FindObjectsOfType<Enemy>();
        Transform Closetarget = null;
        float maxDistance = Mathf.Infinity;

        foreach(Enemy enemy in enemies)
        {
            float targetDistance = Vector3.Distance(transform.position, enemy.transform.position);
            if(targetDistance < maxDistance)
            {
                Closetarget = enemy.transform;
                maxDistance = targetDistance;
            }
        }
        target = Closetarget;

    }

    public void AimWeapon()
    {
        float targetDistance = Vector3.Distance(transform.position, target.position);

        weapon.LookAt(target);
        if(targetDistance < range)
        {
            Attack(true);
        }
        else
        {
            Attack(false);
        }
    }

    void Attack(bool isActive)
    {
        var emissionMudule = projectitleParticles.emission;
        emissionMudule.enabled = isActive;
    }
}
