using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class IgnoreCollision : MonoBehaviour
{
    #region variables
    /// <summary>
    /// main character game object
    /// </summary>
    public GameObject ship1;
    /// <summary>
    /// array of astroid game objects
    /// </summary>
    public GameObject[] astroids2;
    /// <summary>
    /// bool for is colliding 
    /// </summary>
    public bool iscolliding;
    #endregion
    #region Start
    public void Start()
    {
        // Looping through array of astroids
        for (int i = 0; i < astroids2.Length; i++)
        {
            // sets the ships colliders to false
            ship1.GetComponent<PolygonCollider2D>().enabled = false;
            // sets asteroids box colliders to false
            astroids2[i].GetComponent<BoxCollider2D>().enabled = false;
            // sets  asteroids circle colliders to false
            astroids2[i].GetComponent<CircleCollider2D>().enabled = false;
            // is colliding to false
            iscolliding = false;

        }

        Debug.Log(iscolliding);
    }
    #endregion
    #region update
    public void Update()
    {
        //checks if isPlaying is true
        if (GameController.IsPlaying == true)
        {
            // starts collision coroutine
            StartCoroutine("turnonCollision");
           
           
        }
        // checks if isRestarting is true
        else if (GameController.IsRestarting == true)
        {
            // starts collision coroutine
            StartCoroutine("turnonCollision");

           
        }

    }
    #endregion
    #region turnoncollsions
    /// <summary>
    /// coroutine to turn of colliders after a certain amount of time
    /// </summary>
    /// <returns></returns>
    public IEnumerator turnonCollision()
    {
        yield return new WaitForSeconds(0.5f); // wait for 0.5 seconds
        for (int i = 0; i < astroids2.Length; i++) // loops through array
        {
            
            ship1.GetComponent<PolygonCollider2D>().enabled = true; // sets the ships colliders to true
            astroids2[i].GetComponent<BoxCollider2D>().enabled = true; // sets asteroids box colliders to true
            astroids2[i].GetComponent<CircleCollider2D>().enabled = true;  // sets  asteroids circle colliders to true
            iscolliding = true; // is colliding to true
        }

        yield return new WaitForSeconds(0.2f); // wait for 0.2 seconds
        StopCoroutine("turnonCollision"); // turn of collisions

    }
    #endregion
}
