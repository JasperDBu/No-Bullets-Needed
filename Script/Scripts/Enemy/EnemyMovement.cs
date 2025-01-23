using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyMovement : MonoBehaviour
{
    public EnemyScriptableObject enemyData;
    Transform player;
    public EnemySpawner spawner;
    public float Health;

    void Start()
    {
        Health = 150;
        spawner = FindAnyObjectByType<EnemySpawner>();

        if (FindAnyObjectByType<PlayerMovement>().transform)
        {
            player = FindAnyObjectByType<PlayerMovement>().transform;
        }
    }

    private void Update()
    {
        Debug.Log(Health);
        if (player){
        transform.position = Vector2.MoveTowards(transform.position, player.transform.position, enemyData.MoveSpeed * Time.deltaTime); //Constantly move the enemy
            if (transform.position.x < player.transform.position.x)
            {
                transform.localScale = new Vector3(1, 1, 1);
            }
            else if (transform.position.x > player.transform.position.x)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
        }
        if (Health <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnCollisionStay2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Destroy(other.gameObject);
            player = null;
        }
        else if (other.gameObject.CompareTag("Bullet"))
        {
            Debug.Log("hit");
            Health -= 10;  
        }
    }
}