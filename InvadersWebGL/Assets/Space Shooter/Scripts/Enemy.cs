using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Transform player;
    [SerializeField]
    private GameObject explosionPrefab;

    [SerializeField]
    private int healthPoints = 1;

    [Header("Shoot")]
    [SerializeField]
    private Transform shootEnemyPivot;
    [SerializeField]
    private GameObject shootEnemyPrefab;

    private float timeBtwShoots;
    public float startTimeBtwShoots;

    private void Start()
    {

        player = GameObject.FindGameObjectWithTag("Player").transform;
        timeBtwShoots = startTimeBtwShoots;
    }


    private void Update()
    {
        if (CompareTag("Enemy1"))
        {
            if (player == null)
            {
                return;
            }
            else if (timeBtwShoots <= 0)
            {
                Instantiate(shootEnemyPrefab, transform.position, Quaternion.identity);
                timeBtwShoots = startTimeBtwShoots;
            }

            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
        if (CompareTag("FinalEnemy"))
        {
            if (player == null)
            {
                return;
            }
            else if (timeBtwShoots <= 0)
            {
                Instantiate(shootEnemyPrefab, transform.position, Quaternion.identity);
                timeBtwShoots = startTimeBtwShoots;
            }

            else
            {
                timeBtwShoots -= Time.deltaTime;
            }
        }
    }




    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Shoot"))
        {
            healthPoints--;

            Destroy(other.gameObject);

            if (healthPoints <= 0)
            {
                if (CompareTag("FinalEnemy"))
                {
                    StatusFaseFinal.instance.RemoverInimigo();
                }
                Instantiate(explosionPrefab, transform.position, transform.rotation);
                FindObjectOfType<AudioManager>().Play("ExplosionEnemy");

                Destroy(gameObject);
                Score.instance.AddPoint();
            }


        }
    }
}
