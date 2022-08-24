using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class flip : MonoBehaviour
{
    SpriteRenderer sprite;
    bool faceRight = true;

    public GameObject bulletpref;
    GameObject bullet;
    float speed = 6;
    // Start is called before the first frame update
    void Start()
    {
        sprite = GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        FlipPlayer();
        shooting();

        if (transform.parent.position.y < -10)
        {
            transform.parent.position = new Vector3(-2, -1, 0);
        }
    }

    void FlipPlayer()
    {
        if (Input.GetKeyDown(KeyCode.D) && faceRight == false)
        {
            sprite.flipX = false;
            faceRight = true;
        }
        else if (Input.GetKeyDown(KeyCode.A) && faceRight == true)
        {
            sprite.flipX = true;
            faceRight = false;
        }
    }

    void shooting()
    {
        if (Input.GetMouseButtonDown(0) && faceRight)
        {
            bullet = Instantiate(bulletpref, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0);
            Destroy(bullet, 2);
        }
        else if (Input.GetMouseButtonDown(0) && !faceRight)
        {
            bullet = Instantiate(bulletpref, transform.position, transform.rotation);
            bullet.GetComponent<Rigidbody2D>().velocity = new Vector2(-speed, 0);
            Destroy(bullet, 2);
        }
    }

}
