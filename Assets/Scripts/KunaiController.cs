using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KunaiController : MonoBehaviour
{
    float defaultVelocityX = 15;
    float currentVelocityX = 0;
    Rigidbody2D rb;
    GameObject gameManager;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        gameManager = GameObject.Find("GameManager");

        Destroy(gameObject, 5);

    }

    void Update()
    {
        rb.velocity = new Vector2(currentVelocityX, rb.velocity.y);
    }

    public void SetDirection(string direction) {
        if (direction == "left")
        {
            currentVelocityX = -defaultVelocityX;
            transform.rotation = Quaternion.Euler(0, 0, 90);
        } else {
            currentVelocityX = defaultVelocityX;
            transform.rotation = Quaternion.Euler(0, 0, -90);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Enemy")
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);

            gameManager.GetComponent<GameManagerController>().AddScore(10);
        }
    }

    private void Hello() {
        
    }
}
