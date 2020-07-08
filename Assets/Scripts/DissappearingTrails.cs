using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissappearingTrails : MonoBehaviour
{
    public float timeSpan = 3.0f;
    void Update()
    {
        timeSpan -= Time.deltaTime;
        if (timeSpan < 0)
            Destroy(gameObject);
    }
}
