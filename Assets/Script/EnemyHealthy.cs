using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Enemy))]
public class EnemyHealthy : MonoBehaviour
{
    [SerializeField] int maxHitPoints = 5;
    [Tooltip("Adds amount to maxHitPoints when enemy dies")] // chú thích dưới các thuộc tính được kê khai 

    [SerializeField] int difficultyramp = 1;

    [SerializeField] int currenHitPoints = 0;

    Enemy enemy;
    void OnEnable()
    {
        currenHitPoints = maxHitPoints;
    }

    public void Start()
    {
        enemy = GetComponent<Enemy>();
    }

    private void OnParticleCollision(GameObject other)
    {
        ProcessHit();
    }

    public void ProcessHit()
    {
        currenHitPoints--;
        if(currenHitPoints <= 0)
        {
            gameObject.SetActive(false);
            maxHitPoints += difficultyramp;
            enemy.RewardGold();
        }
    }
    
}
