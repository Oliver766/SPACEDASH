using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Movement : MonoBehaviour
{
    #region Variables
    /// <summary>
    /// transform of player
    /// </summary>
    public Transform player;
    /// <summary>
    /// speed of joystick
    /// </summary>
    public float speed = -15.0f;
    /// <summary>
    /// bullet prefab used for shooting
    /// </summary>
    public GameObject bulletPrefab;
    /// <summary>
    /// inner circle for joystick
    /// </summary>
    public Transform circle;
    /// <summary>
    /// outercircle for joystick
    /// </summary>
    public Transform outerCircle;
    /// <summary>
    /// starting point of player
    /// </summary>
    private Vector2 startingPoint;
    /// <summary>
    /// left touch
    /// </summary>
    private int leftTouch = 99;
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
    /// movement script reference
    /// </summary>
    public Movement movement;
    /// <summary>
    /// pause reference
    /// </summary>
    public PauseFunction pause;
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

    #region HealthUp
    /// <summary>
    /// regen method
    /// </summary>
    /// <param name="increase"></param>
    public void HealthUp(float increase)
    {
        if (health + increase <= maxHealth)
        {
            health += increase; // increases health
        }
        {
            health = maxHealth; // health equals health max
        }
    }
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
    #region Update
    // Update is called once per frame
    void Update()
    {
        // checks if health is less than or equal to 0 and if hit bool equals true
        if (health <= 0 && destroy.hit == true && pause.isPause == false)
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
        // i is set to 0
        int i = 0;
        // checks is i is less than
        while (i < Input.touchCount)
        {
            // varable t is equal to get touch input
            Touch t = Input.GetTouch(i);
            // gets position of touch
            Vector2 touchPos = getTouchPosition(t.position); // * -1 for perspective cameras
            // checks is t.phase equals touch phase.began
            if (t.phase == TouchPhase.Began)
            {
                // checks is touch position is equal to screen width
                if (t.position.x > Screen.width / 2)
                {
                    
                    shootBullet();


                }
                else
                {
                    // left touch  =  t.fingerID
                    leftTouch = t.fingerId;
                    // startingPoint  = touch position
                    startingPoint = touchPos;
                    
                   
                }


            }
            // checks is touch phase has moved
            else if (t.phase == TouchPhase.Moved && leftTouch == t.fingerId)
            {
                // sets offset of touch position - starting point
                Vector2 offset = touchPos - startingPoint;
                // sets direction of touch
                Vector2 direction = Vector2.ClampMagnitude(offset, 1.0f);
                //move character
                moveCharacter(direction);
                // allows player to move joy stick
                circle.transform.position = new Vector2(outerCircle.transform.position.x + direction.x, outerCircle.transform.position.y + direction.y);

            }
            // checks if touchphase has ended
            else if (t.phase == TouchPhase.Ended && leftTouch == t.fingerId)
            {
                // left touch equals 99
                leftTouch = 99;
                // allows player to move joy stick
                circle.transform.position = new Vector2(outerCircle.transform.position.x, outerCircle.transform.position.y);

            }
            ++i;
        }

    }
    #endregion
    #region GetTouchPosition
    /// <summary>
    /// gets touch position in relation to camera
    /// </summary>
    /// <param name="touchPosition"></param>
    /// <returns></returns>
    Vector2 getTouchPosition(Vector2 touchPosition)
    {
        return GetComponent<Camera>().ScreenToWorldPoint(new Vector3(touchPosition.x, touchPosition.y, transform.position.z)); // return touch position
    }
    #endregion
    #region MoveCharacter
    /// <summary>
    /// moves character
    /// </summary>
    /// <param name="direction"></param>
    void moveCharacter(Vector2 direction)
    {
        player.Translate(direction * speed * Time.deltaTime); // move player
        isShooting = false; // shooting is set to false
        health = health + 0.1f; // health equals health plus 3
        Debug.Log(isShooting);
        if (health >=100) // if health is greater than or equal to 0
        {
            health = health + 0; // stops health bar going any higher
        }
      
    }
    #endregion
    #region ShootBullet
    /// <summary>
    /// checks if health is greater than 0 then allows player to shoot
    /// </summary>
   public void shootBullet()
    {
        if(health > 0) // if health is greater than 0
        {
            GameObject b = Instantiate(bulletPrefab) as GameObject; // instatiate bullet opbject
            b.transform.position = player.transform.position; //  posiyion of bullet is poistion of player
            SoundManager.playSound("shoot1"); // play sound
            isShooting = true; // is shooting equals to true
            health = health - 3; // playwr looses health
        }
        
    }
    #endregion

}
