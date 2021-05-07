using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody2D))]
public class Astroids : MonoBehaviour
{
    #region variables
    /// <summary>
    /// speed off astroids
    /// </summary>
    public float speed = 10.0f;
    /// <summary>
    /// gets rigidbody component
    /// </summary>
    private Rigidbody2D rb;
    /// <summary>
    /// gets a screen bound value
    /// </summary>
    private Vector2 screenBounds;
    /// <summary>
    /// rotation speed
    /// </summary>
    public Vector2 AngularSpeed;
    /// <summary>
    /// degree rotation per second
    /// </summary>
    public float degreesPerSec = 360f;
    /// <summary>
    /// damage of astroid
    /// </summary>
    public int Damage;
    #endregion



    #region Start
    // Use this for initialization
    void Start()
    {
        // gets rigidbody component
        rb = this.GetComponent<Rigidbody2D>();

        // sets veclocity of asteroid speed
        rb.velocity = new Vector2(-speed, 0);

    }
    #endregion

    #region Updated
    // Update is called once per frame
    void Update()
    {
        // sets screenbouds of asteroids
        screenBounds = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));

        // sets rotation amount
        float rotAmount = degreesPerSec * Time.deltaTime;
        // sets current rotation of asteroids
        float curRot = transform.localRotation.eulerAngles.z;
        // rotates asteroids with current roation and roation amount
        transform.localRotation = Quaternion.Euler(new Vector3(0, 0, curRot + rotAmount));

        // checks if asteroids are out of screen bounds
        if (transform.position.x < screenBounds.x * 2)
        {
            
            Destroy(this.gameObject);
        }

    }

    #endregion



}
