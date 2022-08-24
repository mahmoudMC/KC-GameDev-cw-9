using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class enemyscript : MonoBehaviour
{
    Rigidbody2D rb;
    float speed = 0.5f;
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        StartCoroutine(Patrol());
    }

    void FixedUpdate()
    {
        rb.velocity = new Vector2(speed, 0);
        
        if (speed < 0)
        {
            GetComponent<SpriteRenderer>().flipX = false;
        }
        else
        {
            GetComponent<SpriteRenderer>().flipX = true;
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        Destroy(gameObject);
    }

    IEnumerator Patrol()
    {
        speed *= -1;
        yield return new WaitForSeconds(8);
        StartCoroutine(Patrol());
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.name == "Ninja")
        {
            SceneManager.LoadScene(0);
        }
    }

}
