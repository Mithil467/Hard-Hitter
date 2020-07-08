using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Enemy : MonoBehaviour
{
    public GameObject deathEffect;

    public float health = 4f;
    public static int EnemiesAlive = 0;
    private bool allDead = false;
    public int nextScene = 0;
    private float threeseconds = 5.0f;
    AudioSource audioNo;

    private void Start()
    {
        EnemiesAlive++;
        audioNo = Camera.main.GetComponent<AudioSource>();

    }

    public void Update()
    {
        if(allDead)
        {
            threeseconds -= 0.1f;
            if(threeseconds <=0)
            {
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.relativeVelocity.magnitude > health)
        {
            Die();
        }
    }

        public void Die()
        {
            Instantiate(deathEffect, transform.position, Quaternion.identity);
            EnemiesAlive--;
        Debug.Log(EnemiesAlive);
        audioNo.Play(0);
        if (EnemiesAlive <= 0)
        {
            allDead = true;
            gameObject.transform.localScale = new Vector3(0, 0, 0);
            gameObject.transform.position = new Vector3(100,100,100);
            //SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
        else
        {
            Destroy(gameObject);
        }
    }
 }