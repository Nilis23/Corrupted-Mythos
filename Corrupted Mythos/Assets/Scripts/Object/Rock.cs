using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Rock : MonoBehaviour
{
    [SerializeField]
    float fallSpeed;

    float fallDist;
    float distFallen = 0;

    public void SetFallDist(float val)
    {
        fallDist = val;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x, transform.position.y - (fallSpeed * Time.deltaTime));
        distFallen += Time.deltaTime;

        transform.rotation = Quaternion.Euler(0, 0, transform.rotation.eulerAngles.z + (180 * Time.deltaTime));

        if(distFallen >= fallDist)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            collision.gameObject.GetComponent<PlayerHealth>().killPlayer();
        }
    }
}
