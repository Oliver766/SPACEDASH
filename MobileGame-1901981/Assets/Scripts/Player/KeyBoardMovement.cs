using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class KeyBoardMovement : MonoBehaviour
{
    #region variables
    public Transform player;
    public float speed = 5.0f;
    public GameObject bulletPrefab;
    public Animator anim;
    /// <summary>
    /// game controller reference
    /// </summary>
    public GameController controller;
    /// <summary>
    /// player script reference
    /// </summary>
    public ShipDestroy destroy;
    /// <summary>
    /// health bar reference
    /// </summary>
    public Slider healthBar;
    /// <summary>
    /// max health
    /// </summary>
    public float maxHealth;
    /// <summary>
    /// health
    /// </summary>
    public float health;
    /// <summary>
    /// bool for is dead
    /// </summary>
    public bool death;
    /// <summary>
    /// smoothing lerping
    /// </summary>
    public float smoothing = 5;
    /// <summary>
    /// bool for is shooting
    /// </summary>
    public bool isShooting;
    /// <summary>
    /// damage
    /// </summary>
    public int Damage;
    /// <summary>
    /// health in value
    /// </summary>
    public int HealthIn;
    /// <summary>
    /// player
    /// </summary>
    public GameObject ship;
    /// <summary>
    /// keyboard reference
    /// </summary>
    public KeyBoardMovement movement;
    #endregion
    #region Awake
    /// <summary>
    /// awake function
    /// </summary>
    public void Awake()
    {

        health = maxHealth;
        healthBar.maxValue = maxHealth;
        healthBar.value = health;
    }
    #endregion

    #region Take Damage
    /// <summary>
    /// take damage method
    /// </summary>
    /// <param name="Damage"></param>
    public void TakeDamage(float Damage)
    {
        if (health - Damage >= 0)
        {
            health -= Damage;
        }
        else
        {
            health = 0;
            death = true;
        }

    }
    #endregion
    #region update
    // Update is called once per frame
    void Update()
    {

        // checks if health is less than or equal to 0 and if hit bool equals true
        if (health <= 0 && destroy.hit == true)
        {
            //game over function
            controller.GameOver();
            death = true;
            health = 0;
            Debug.Log("Dead");
            // movement is disabled
            movement.GetComponent<Movement>().enabled = false;
            // gravity scale is set to 2
            ship.GetComponent<Rigidbody2D>().gravityScale = 2;
            SoundManager.playSound("hit12");
            // coroutine is started
            StartCoroutine(Slowship());
        }
        // checks is value of health bar does not equal health
        if (healthBar.value != health)
        {
            // value is lerped
            healthBar.value = Mathf.Lerp(healthBar.value, health, smoothing * Time.deltaTime);
        }

        moveCharacter(new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")));
        if (Input.GetKeyDown("space"))
        {
            shootBullet();
        }
    }
    #endregion
    #region SlowShip
    /// <summary>
    /// slowship method
    /// </summary>
    /// <returns></returns>
    public IEnumerator Slowship()
    {
        yield return new WaitForSeconds(0.8f); // wait for 0.8 seconds
        ship.SetActive(false); // game object set to false
        StopCoroutine(Slowship()); // stop coroutine
    }
    #endregion
    #region move character
    /// <summary>
    /// movr characterfunction
    /// </summary>
    /// <param name="direction"></param>
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime); player.Translate(direction * speed * Time.deltaTime); // move player
    }
    #endregion
    #region ShootBullet
    /// <summary>
    /// checks if health is greater than 0 then allows player to shoot
    /// </summary>
    void shootBullet()
    {
        if (health > 0)  // if health is greater than 0
        {
            GameObject b = Instantiate(bulletPrefab) as GameObject; // instatiate bullet opbject
            b.transform.position = player.transform.position; //  posiyion of bullet is poistion of player
            SoundManager.playSound("shoot1"); // play sound
            isShooting = true; // is shooting equals to true
            health = health - 3; // playwr looses health

        }
        #endregion


    }
}

