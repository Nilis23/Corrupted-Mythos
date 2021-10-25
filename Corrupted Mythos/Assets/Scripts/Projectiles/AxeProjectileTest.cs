using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectileTest : MonoBehaviour
{
    [Tooltip("The damage dealt when an enemy is hit")]
    [SerializeField]
    int damage;
    [Tooltip("The lifetime of the projectile if it does not hit anything.")]
    [SerializeField]
    float lifetime;


    [Space]
    [SerializeField]
    float xSpeed;
    [SerializeField]
    float launchAngle;
    [SerializeField]
    float timeToPeak;
    [SerializeField]
    float rotSpeed;

    float a;
    float dir = 0;
    float t = 0;

    float xOriginal;
    float yOriginal;

    /*
    // Start is called before the first frame update
    void Start()
    {
        a = (xSpeed * Mathf.Tan(angle) ) / timeToPeak;

        if(this.transform.localScale.x > 0)
        {
            dir = 1;
        }
        else
        {
            dir = -1;
        }
    }

    // Update is called once per frame
    void Update()
    {
        lifetime -= Time.deltaTime;
        if(lifetime <= 0)
        {
            Destroy(this.gameObject);
        }

        t += Time.deltaTime;
        float nY = (this.transform.position.y) + ((timeToPeak - t) * a);
        transform.Translate(new Vector2(Time.deltaTime * xSpeed * dir, nY));
    }
    */

    void Start()
    {
        xOriginal = transform.position.x;
        yOriginal = transform.position.y;

        if (this.transform.localScale.x > 0)
        {
            dir = 1;
            transform.Rotate(new Vector3(0, 0, 180));
        }
        else
        {
            dir = -1;
        }
    }
    void FixedUpdate()
    {
        t += Time.deltaTime;

        float newX = xSpeed * t * dir;  //x where xOriginal is 0
        transform.position = new Vector2(xOriginal + (newX), (-1 * Mathf.Tan(launchAngle * Mathf.Deg2Rad) * (newX * newX)) / (2 * timeToPeak) + (xSpeed * Mathf.Tan(launchAngle * Mathf.Deg2Rad) * (newX * dir)) + yOriginal);
        transform.Rotate(new Vector3(0, 0, Time.deltaTime * (dir * -1) * rotSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if(collision.gameObject.tag == "enemy")
            {
                Debug.Log("Enemy hit");
                collision.gameObject.GetComponent<EnemyHealth>().minusHealth(damage);
                FindObjectOfType<AudioManager>().PlaySound("swing");
            }
            else if (collision.name == "ForestFrontGrass")
            {
                FindObjectOfType<AudioManager>().StopSound("axeThrow");
                Destroy(this.gameObject);
            }
        }
    }

}
