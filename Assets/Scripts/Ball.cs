using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Ball : MonoBehaviour
{
    public Rigidbody2D rb;
    public Rigidbody2D hook;

    AudioSource audioLaunch;

    public float releaseTime = 0.15f;
    public float maxDragDistance = 2f;
    private bool isPressed = false;

    public GameObject nextBall;
    public GameObject nextLife;
    
    void Start()
    {
        audioLaunch = GetComponent<AudioSource>();
    }

    void Update()
    { 
        if (isPressed)
        {
            Vector2 mousePos = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, 10));
            if (Vector2.Distance(mousePos, hook.position) > maxDragDistance)
                rb.position = hook.position + (mousePos - hook.position).normalized * maxDragDistance;
            else
                rb.position = mousePos;
        }

    }

    
    void OnMouseDown()
    {
        isPressed = true;
        rb.isKinematic = true;
    }

    void OnMouseUp()
    {
        isPressed = false;
        rb.isKinematic = false;
        audioLaunch.Play(0);
        StartCoroutine(Release());
    }

    IEnumerator Release()
    {
        yield return new WaitForSeconds(releaseTime);
        GetComponent<SpringJoint2D>().enabled = false;
        this.enabled = false;
        gameObject.GetComponent<Trailer>().enabled = true;

        yield return new WaitForSeconds(2f);

        if (nextBall != null)
        {
            nextBall.SetActive(true);
            if (nextLife != null)
                nextLife.SetActive(false);

        }
        else
        {
            yield return new WaitForSeconds(6f);
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }
    }

}
