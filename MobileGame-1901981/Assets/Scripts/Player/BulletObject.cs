using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletObject : MonoBehaviour
{
    #region variables
    /// <summary>
    /// speed of opbject
    /// </summary>
    public float speed = 50.0f;
    /// <summary>
    /// gets rigidibosy references
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// get screen bound reference
    /// </summary>
    private Vector2 screenBounds;
    /// <summary>
    /// score reference for each asteroid
    /// </summary>
    [SerializeField] protected int worth = 0;
    /// <summary>
    /// explosion prefab
    /// </summary>
    public GameObject explosion;
    #endregion

    #region start
    // Use this for initialization
    void Start()
    {
        // gets reference for rigidbody
        rb = this.GetComponent<Rigidbody2D>();
        // sets velocity of bullet
        rb.velocity = new Vector2(speed, 0);
        // sets screen bounds
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
       
    }
    #endregion
    #region update
    // Update is called once per frame
    void Update()
    {
        // checks if bullet is outisde of screen
        if (transform.position.x > screenBounds.x * -2)
        {
            Destroy(this.gameObject);
        }

    }
    #endregion
    #region on trigger enter
    /// <summary>
    ///  bullet collides with each type of astroid and it explodes and player gets a point
    /// </summary>
    /// <param name="other"></param>
    public void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag ("SmallAsteroids"))
        {
            // instatiate explosion prefab
            GameObject e = Instantiate(explosion) as GameObject;
            // position on player
            e.transform.position = transform.position;
            // destroy collision object
            Destroy(other.gameObject);
            // destroys bullet object
            Destroy(this.gameObject);
            // add score
            GameController.Score++;
            // play sound
            SoundManager.playSound("hit01");
            // destroys explosion
            Destroy(e.gameObject, 5);

        }

        else if(other.gameObject.CompareTag("MediumAsteroids"))
        {
            // instatiate explosion prefab
            GameObject e = Instantiate(explosion) as GameObject;
            // position on player
            e.transform.position = transform.position;
            // destroy collision object
            Destroy(other.gameObject);
            // destroys bullet object
            Destroy(this.gameObject);
            // add score
            GameController.Score++;
            // play sound
            SoundManager.playSound("hit01");
            // destroys explosion
            Destroy(e.gameObject, 5);
        }

       else if(other.gameObject.CompareTag("HugeAsteroids"))
       {
            // instatiate explosion prefab
            GameObject e = Instantiate(explosion) as GameObject;
            // position on player
            e.transform.position = transform.position;
            // destroy collision object
            Destroy(other.gameObject);
            // destroys bullet object
            Destroy(this.gameObject);
            // add score
            GameController.Score++;
            // play sound
            SoundManager.playSound("hit01");
            // destroys explosion
            Destroy(e.gameObject, 5);

        }

    }
    #endregion
}

