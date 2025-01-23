using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour
{
    public EnemyScriptableObject enemyData;

    //Current Stats
    [HideInInspector]
    public float currentMoveSpeed;
    [HideInInspector]
    public float currentHealth;
    [HideInInspector]
    public float currentDamage;

    public float despawnDistance = 20f;
    Transform player;

    void Awake()
    {
        currentMoveSpeed = enemyData.MoveSpeed;
        currentHealth = 150f;
        currentDamage = enemyData.Damage;
    }

    [System.Obsolete]
    void Start()
    {
        if (FindObjectOfType<PlayerStats>().transform){
            player = FindObjectOfType<PlayerStats>().transform;
        }
    }

    void Update()
    {
        if (player){
        if (Vector2.Distance(transform.position, player.position) >= despawnDistance)
        {
            ReturnEnemy();
        }
            if (currentHealth <= 0)
            {
                Kill();
            }
        }
    }

    public void TakeDamage(float dmg)
    {

        currentHealth -= dmg;

        if (currentHealth <= 0f)
        {
            Kill();
        }
    }

    

    public void Kill()
    {
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D col) // does not detect anything
    {
        //Reference the script from the collided collider and deal damage using TakeDamage()
        if (col.gameObject.CompareTag("Player"))
        {
            PlayerStats player = col.gameObject.GetComponent<PlayerStats>();
            player.TakeDamage(currentHealth); //Make sure to use currentDamage instead of weaponData.damage in case any damage multipliers in the future
        }
        else if (col.gameObject.CompareTag("Bullet"))
        {
            Kill();
            //currentHealth -= col.gameObject.GetComponent<Bullet>().Damage;
        }
    }

    [System.Obsolete]
    private void OnDestroy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        es.OnEnemyKilled();
    }

    [System.Obsolete]
    void ReturnEnemy()
    {
        EnemySpawner es = FindObjectOfType<EnemySpawner>();
        transform.position = player.position + es.relativeSpawnPoints[Random.Range(0, es.relativeSpawnPoints.Count)].position;
    }
}
