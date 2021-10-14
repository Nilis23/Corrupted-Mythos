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
    float maxHeight;
    [SerializeField]
    float timeToPeak;
    [SerializeField]
    float rotSpeed;

    float dir = 0;
    float t = 0;

    float tOffset;
    float yOriginal;

    void Start()
    {
        yOriginal = transform.position.y;
        tOffset = -2 - Mathf.Sqrt(Mathf.Pow(2, 2) - 4*(-1)*( -1 * Mathf.Pow(timeToPeak, 2) + maxHeight)) / (2 * -1);
        timeToPeak += Mathf.Abs(tOffset);
        Debug.Log(tOffset.ToString());
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
        t += Time.fixedDeltaTime;

        float newY = (-1 * Mathf.Pow(t - timeToPeak, 2)) + maxHeight + yOriginal;
        float newX = xSpeed * Time.fixedDeltaTime * dir;

        transform.position = new Vector2(transform.position.x + newX, newY);
        transform.Rotate(new Vector3(0, 0, Time.fixedDeltaTime * (dir * -1) * rotSpeed));
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag != "Player")
        {
            if(collision.gameObject.tag == "enemy")
            {
                Debug.Log("Enemy hit");
                collision.gameObject.GetComponent<EnemyHealth>().minusHealth(damage);
            }
            Destroy(this.gameObject);
        }
    }

}
