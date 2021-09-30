using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AxeProjectile : MonoBehaviour
{
    [Tooltip("The damage dealt when an enemy is hit")]
    [SerializeField]
    int damage;
    [Tooltip("The total force applied to the axe after being created")]
    [SerializeField]
    float launchForce;
    [Tooltip("The lifetime of the projectile if it does not hit anything.")]
    [SerializeField]
    float lifetime;
    [Space]
    [Tooltip("Xmod cannot be greater than 1. It determines how much force is applied laterally vs vertically")]
    [Range(0.1f, 0.9f)]
    [SerializeField]
    float xMod;
    [Space] 
    [SerializeField]
    Rigidbody2D rb;


    // Start is called before the first frame update
    void Start()
    {
        float yMod = 1 - xMod;

        if(this.transform.localScale.x > 0)
        {
            Vector2 force = new Vector2(launchForce / xMod, launchForce / yMod);
            rb.AddForce(force);
        }
        else
        {
            Vector2 force = new Vector2((launchForce / xMod) * -1, launchForce / yMod);
            rb.AddForce(force);
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

        if (this.transform.localScale.x > 0)
        {
            var dir = rb.velocity;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis(angle, Vector3.forward);

            this.transform.rotation = q;
        }
        else
        {
            var dir = rb.velocity;
            var angle = Mathf.Atan2(dir.y * -1, dir.x * -1) * Mathf.Rad2Deg;
            var q = Quaternion.AngleAxis(angle, Vector3.forward);

            this.transform.rotation = q;
        }
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
