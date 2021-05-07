using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ShipDestroy : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// explosion prefab
    /// </summary>
    public GameObject explosion;
    /// <summary>
    /// reference to movement script
    /// </summary>
    public Movement movement;
    /// <summary>
    /// damage variable
    /// </summary>
    public int Damage;
    /// <summary>
    /// animator reference
    /// </summary>
    public Animator anim;
    /// <summary>
    /// bool for hitting 
    /// </summary>
    public bool hit;
    /// <summary>
    /// astroids reference
    /// </summary>
    private Astroids astroids;
    /// <summary>
    /// camera shake reference
    /// </summary>
    public CameraShaking camerShake;
    #endregion

    #region Update
    public void Update()
    {

        if (hit == true) // if hit equals true
        {
            hit = false; // hit equals false
            Debug.Log(hit);
        }

    }
    #endregion

    #region Start
    public void Start()
    {
        // gets asteroid components
        astroids = GetComponent<Astroids>();
    }
    #endregion

    #region ontriggerEnter
    /// <summary>
    /// checks which astroid has hit the player and how much damage they get
    /// </summary>
    /// <param name="collision"></param>
    public void OnTriggerEnter2D(Collider2D collision)
    {
        // checks if spaceship collides with small asteroids
        if(collision.gameObject.CompareTag("SmallAsteroids"))
        {
            Debug.Log("Hit");
            // instatiate explosion prefab
            GameObject e = Instantiate(explosion) as GameObject;
            // position on player
            e.transform.position = transform.position;
            // destroy collision object
            Destroy(collision.gameObject);
            hit = true;
            // starts camera shake  coroutine
            StartCoroutine(camerShake.Shake(.15f, .4f));
            // take damage
            movement.TakeDamage(10);
            Debug.Log(Damage);
            // destroy explosion
            Destroy(e.gameObject, 2);
            //play sound
            SoundManager.playSound("hit06");
           

        }

        // checks if spaceship collides with Medium asteroids
        else if (collision.gameObject.CompareTag("MediumAsteroids"))
        {
            Debug.Log("Hit");
            // instatiate explosion prefab
            GameObject e = Instantiate(explosion) as GameObject;
            // position on player
            e.transform.position = transform.position;
            // destroy collision object
            Destroy(collision.gameObject);
            hit = true;
            // starts camera shake  coroutine
            StartCoroutine(camerShake.Shake(.15f, .4f));
            // take damage
            movement.TakeDamage(15);
            Debug.Log(Damage);
            // destroy explosion
            Destroy(e.gameObject, 2);
            //play sound
            SoundManager.playSound("hit06");
            

        }
        // checks if spaceship collides with Huge asteroids
        else if (collision.gameObject.CompareTag("HugeAsteroids"))
        {
            Debug.Log("Hit");
            // instatiate explosion prefab
            GameObject e = Instantiate(explosion) as GameObject;
            // position on player
            e.transform.position = transform.position;
            // destroy collision object
            Destroy(collision.gameObject);
            hit = true;
            // starts camera shake  coroutine
            StartCoroutine(camerShake.Shake(.15f, .4f));
            // take damage
            movement.TakeDamage(30);
            Debug.Log(Damage);
            // destroy explosion
            Destroy(e.gameObject, 2);
            //play sound
            SoundManager.playSound("hit06");
           

        }

    }

    #endregion

}

