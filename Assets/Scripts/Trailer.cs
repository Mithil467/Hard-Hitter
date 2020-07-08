using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trailer : MonoBehaviour
{
    public float timeBtwSpawns;
    public float startTimeBtwSpawns;

    public GameObject trailer;

    void Update()
    {
        if(timeBtwSpawns <= 0)
        {
            Instantiate(trailer, transform.position, Quaternion.identity);
            timeBtwSpawns = startTimeBtwSpawns;
        }
        else
        {
            timeBtwSpawns -= Time.deltaTime;
        }

    }

    void OnCollisionEnter2D(Collision2D collision)
    {
        this.enabled = false;
    }
}
