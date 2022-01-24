using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Swoosh : MonoBehaviour
{
    float life = 0.5f;
    [SerializeField]
    float speed;
    [SerializeField]
    int damage;

    // Start is called before the first frame update
    void Start()
    {
        GameObject Player = GameObject.FindGameObjectWithTag("Player");
        transform.position = Player.transform.position;
        if(Player.transform.localScale.x < 0)
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(-1 * speed, 0f);
        }
        else
        {
            gameObject.GetComponent<Rigidbody2D>().velocity = new Vector2(speed, 0f);
        }
    }

    // Update is called once per frame
    void Update()
    {
        life -= Time.deltaTime;
        if(life <= 0)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "enemy")
        {
            collision.gameObject.GetComponent<EnemyHealth>().minusHealth(damage);
            //Destroy(gameObject);
        }
    }
}
