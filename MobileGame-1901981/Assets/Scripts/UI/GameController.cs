using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.ComponentModel;
using UnityEngine.Events;
using UnityEngine.Advertisements;

public class GameController : MonoBehaviour
{
    [Description("Should the game start on load?")]
    [SerializeField] public bool startOnLoad = false;
    [Header("Events")]
    [Description("Called when the game begins.")]
    public UnityEvent GameBeginEvent;
    [Description("Called when the player loses.")]
    public UnityEvent GameOverEvent;
    [Description("Called when game will start tutoial")]
    public UnityEvent TutorialStart;
    [Description("Called when game will start tutoial")]
    public UnityEvent MainMenuSetActivefalse;
    [Description("Called when game will start tutoial")]
    public UnityEvent MainMenuSetActive;

    #region variables
    /// <summary>
    /// game controller instance
    /// </summary>
    private static GameController instance;
    /// <summary>
    /// pause menu reference
    /// </summary>
    public static GameObject pauseMenu;
    /// <summary>
    /// time reference
    /// </summary>
    public GameObject time;
    /// <summary>
    /// high score text reference
    /// </summary>
    public Text highScoreText;
    /// <summary>
    /// incoming text
    /// </summary>
    public  GameObject incomingText;
    /// <summary>
    /// shoot text reference
    /// </summary>
    public GameObject ShootText;
    /// <summary>
    /// movement reference
    /// </summary>
    public Movement movement;
    /// <summary>
    /// game id
    /// </summary>
   public string gameID = "4115411";
    /// <summary>
    /// test mode bool
    /// </summary>
   public bool testMode = true;
    /// <summary>
    /// add counter
    /// </summary>
    public static int adcounter = 0;
    /// <summary>
    /// adddisable bool
    /// </summary>
    public static bool  adDisable = false;
    /// <summary>
    /// add cooldown 
    /// </summary>
    public static int adCooldown = 0;
    /// <summary>
    /// animation reference
    /// </summary>
    public static Animator anim;
    /// <summary>
    /// mainmenu reference
    /// </summary>
    public Animator mainMenu;
    /// <summary>
    /// player animation reference
    /// </summary>
    public Animator playeranim;
    /// <summary>
    /// end screen reference
    /// </summary>
    public Animator endScreen;
    /// <summary>
    /// player game objecy reference
    /// </summary>
    public GameObject player;

    /// <summary>
    /// bool for is playing
    /// </summary>
    public static bool IsPlaying { get; private set; }
    /// <summary>
    /// bool for is restarting
    /// </summary>
    public static bool IsRestarting { get; private set; }
    /// <summary>
    /// bool for is mainmenu
    /// </summary>
    public static bool isMainMenu { get; private set; }
    /// <summary>
    /// coroutine for adds
    /// </summary>
    public static Coroutine add;
    /// <summary>
    /// score reference
    /// </summary>
    public static int Score { get; set; }
    /// <summary>
    /// highscore reference
    /// </summary>
    public static int highScore { get; set; }

    #endregion

    #region awake
    public void Awake()
    {
        // instance  is this script
        instance = this;
        //set saved highscore
        if(PlayerPrefs.HasKey("HighScore"))
        {
            highScore = PlayerPrefs.GetInt("HighScore", highScore); // set saved high scord
            highScoreText.text = highScore.ToString(); // write it out as text

        }

    }
    #endregion
    #region start
    public void Start()
    {
        // movement is disabled
        movement.GetComponent<Movement>().enabled = false;
        // text is set inactive
        incomingText.gameObject.SetActive(false);
        // text is set inactive
        ShootText.gameObject.SetActive(false);
        //play animation
        mainMenu.Play("mainmenuDown");
        // checks if these bools are true
        if (startOnLoad || IsPlaying)
        {
           
            // start function
            TutorialSection();
            Debug.Log(Score);
            Debug.Log(highScore);


        }
        // checks if these bools are true
        if (startOnLoad || IsRestarting)
        {
            // start function
            Begin();

        }

        if (startOnLoad || isMainMenu)
        {
            // invoke event
            instance.MainMenuSetActive.Invoke(); 
        }

    }
    #endregion
    #region menu set active
    /// <summary>
    /// coroutine for setting menu active to false
    /// </summary>
    /// <returns></returns>
    public IEnumerator MenuSetActive()
    {
        yield return new WaitForSeconds(0.5f); // wait 0.5 seconds
        instance.MainMenuSetActivefalse.Invoke(); // invoke event
        StopCoroutine("MenuSetActive"); // start coroutine

    }
    #endregion
    #region update
    public void Update()
    {
        UpdateHighScore();

    }
    #endregion

    #region add
    /// <summary>
    /// add function to be included every time there is a game over screen
    /// </summary>
    /// <returns></returns>
    public IEnumerator Add()
    {
        if (!adDisable)
        {
            if (adcounter  == 1) // if a counter is greater than 1
            {

                Debug.Log(adDisable);
                Advertisement.Initialize("4115411", true); // intialise adds
                while (!Advertisement.IsReady())
                    yield return null;
                Advertisement.Show(); // show adverts
                Debug.Log(adcounter);
                Debug.Log(adCooldown);
                adcounter = 0; // set to 0
             
                
            }
            else
            {
                adcounter++; // add to counter
                Debug.Log(adcounter);
            }
            adDisable = false;
            Debug.Log(adDisable);
            yield return new WaitForSeconds(0.2f);

        }

    }
    #endregion

    #region begin
    /// <summary>
    /// begin function when game starts
    /// </summary>
    public void Begin()
    {
        // Reset stats
        Score = 0; // score is 0
        Time.timeScale = 1;// game is running
        movement.GetComponent<Movement>().enabled = true; // enable movement
        IsRestarting = true; // set to true
        IsPlaying = true;// set to true
        instance.GameBeginEvent.Invoke(); // invoke event
        playeranim.Play("PlayerStart"); // play animation
        StartCoroutine(begin()); // start coroutine
   
    }
    #endregion
    #region game over
    /// <summary>
    /// game over function
    /// </summary>
    public void GameOver()
    {
        instance.GameOverEvent.Invoke(); // invoke event
        endScreen.SetBool("IsGameOver", true); // game over is set to true
        StartCoroutine(Add()); // start coroutine

    }
    #endregion
    #region tutorialsection
    /// <summary>
    /// tutorial function for start
    /// </summary>
    public void TutorialSection()
    {
        Score = 0; //  score set to 0
        IsPlaying = true; // set to true
        isMainMenu = false; // set to true
        Time.timeScale = 1;// game is running
        movement.GetComponent<Movement>().enabled = true; // movment enabled
        mainMenu.Play("MainMenuUp"); //play animation
        StartCoroutine("MenuSetActive"); //Start coroutine
        instance.TutorialStart.Invoke(); // invoke event
        playeranim.Play("PlayerStart"); // play animation
        StartCoroutine(TutorialSectionlevel()); // start coroutine
        Debug.Log(highScore);

    }
    #endregion

    #region restart
    /// <summary>
    /// restart function
    /// </summary>
    public void Restart()
    { 
        IsRestarting = true; // set to true
        IsPlaying = false; // set to false
        SceneManager.LoadScene("Game"); // load game
        Time.timeScale = 1;// game is running
        //StartCoroutine(Add()); // start coroutine
    }
    #endregion
    #region stop
    /// <summary>
    /// function to stop the game
    /// </summary>
    public static void Stop()
    {
        Time.timeScale = 0;  // stops game    
        IsRestarting = false; // set to false
       
    }
    #endregion
    #region begin
    /// <summary>
    /// coroutine to stop plater animation and allow player input
    /// </summary>
    /// <returns></returns>
    public IEnumerator begin()
    {
        yield return new WaitForSeconds(1f); // waits for 1 second
        player.GetComponent<Animator>().enabled = false; // disable animator on player
        StopCoroutine(begin()); // start coroutine
    }
    #endregion
    #region resume
    /// <summary>
    /// function to resume game
    /// </summary>
    public static void Resume()
    {
        Time.timeScale = 1; // game is running
        IsPlaying = true; // set to true
    }
    #endregion
    #region mainmenu
    /// <summary>
    /// function to load mainmenu
    /// </summary>
    public static void MainMenu()
    {
        
        IsRestarting = false; // set to false
        IsPlaying = false; // set to false
        isMainMenu = true; // set to true
        SceneManager.LoadScene("Game"); //load scene
        Time.timeScale = 1; // game is running
    }
    #endregion
    #region quit
    /// <summary>
    /// quit function
    /// </summary>
    public void OnApplicationQuit()
    {
        Application.Quit(); // quit game
    }
    #endregion
    #region tutorialsection
    /// <summary>
    /// coroutine for tutorial function
    /// </summary>
    /// <returns></returns>
    public IEnumerator TutorialSectionlevel()
    {
        Debug.Log(Time.timeScale);
        yield return new WaitForSeconds(2f); // wait for 2 seconds
        player.GetComponent<Animator>().enabled = false; // disable animator
        incomingText.gameObject.SetActive(true); // set active
        ShootText.gameObject.SetActive(true); // set active
        yield return new WaitForSeconds(2f); // wait for 2 seconds
        incomingText.SetActive(false); // set to not active
        ShootText.SetActive(false); // set to not active
        StopCoroutine(TutorialSectionlevel()); // stop coroutine

    }
    #endregion
    #region add score
    /// <summary>
    /// add score function
    /// </summary>
    public void AddScore()
    {
        Score++; // add score
        UpdateHighScore();
    }
    #endregion
    #region update high score
    /// <summary>
    /// update highscore function
    /// </summary>
    public void UpdateHighScore()
    {
        if(Score> highScore) // if score is greater than hight score
        {
            highScore = Score; // high score equals score
            PlayerPrefs.SetInt("HighScore", highScore); // save high score
            highScoreText.text = highScore.ToString(); // writes score to text
        }
    }
    #endregion
    /// <summary>
    /// clear hight score function
    /// </summary>
    #region cleasehightscore
    public void ClearHightScore()
    {
        PlayerPrefs.DeleteKey("HighScore"); // delete high score
        highScore = 0; // set to 0
        highScoreText.text = highScore.ToString(); // write high score to text
    }
    #endregion

}
