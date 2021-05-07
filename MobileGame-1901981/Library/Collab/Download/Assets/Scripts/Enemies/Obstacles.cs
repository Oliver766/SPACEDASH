using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Obstacles : MonoBehaviour
{
    public int damage;
    public float speed;

    void Update()
    {
        transform.Translate(Vector2.down * speed * Time.deltaTime);
    }

    public void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.CompareTag("Player"))
        {
            collision.GetComponent<Movement>().health -= damage;
            Debug.Log(collision.GetComponent<Movement>().health);
            Destroy(gameObject);
        }

    }
}
