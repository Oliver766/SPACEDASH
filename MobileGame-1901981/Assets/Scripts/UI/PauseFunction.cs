using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using System.ComponentModel;
public class PauseFunction : MonoBehaviour
{
   
    #region Variables
    /// <summary>
    /// gets player reference
    /// </summary>
    public GameObject player;
    /// <summary>
    /// bool is pause reference
    /// </summary>
    public bool isPause;
    /// <summary>
    /// hud reference
    /// </summary>
    public GameObject HUD;
    /// <summary>
    /// joystick reference
    /// </summary>
    public GameObject joystick;

    #endregion


    #region OnClickPause
    /// <summary>
    /// Pause Function 
    /// </summary>
    public void OnclickPause()
    {
        
        if (gameObject.activeInHierarchy == false) // pause menu starts as not active in scene
        {
            //GameController.Stop();
            gameObject.SetActive(true); //  pause menu is then active in scene
            Time.timeScale = 0; // time scale equalls 0
            Cursor.lockState = CursorLockMode.None; // cursor lockmode is disabled and user is able to use the cursor.
            HUD.SetActive(false); // set active
            player.SetActive(false); // set active
            joystick.SetActive(false);// set active
            isPause = true; // set to true

        }
    }
    #endregion

    #region OnOffClickPause
    /// <summary>
    /// function for un pauseing game
    /// </summary>
    public void OnOffClickPause()
    {

        if (gameObject.activeInHierarchy == true)
        {
            gameObject.SetActive(false); // if pause function is not used then menu remains inactive
            Time.timeScale = 1; // time scale still equals 1
            Cursor.visible = true; // cursor is still visible
            Cursor.lockState = CursorLockMode.None;  // cursor lockmode is disabled and user is able to use the cursor.
            isPause = false;
            HUD.SetActive(true);
            player.SetActive(true);
            joystick.SetActive(true);
        }
    }
    #endregion
  
    #region MainMenu
    /// <summary>
    ///  function to go back to main menu
    /// </summary>
    public void MainMenu()
    {
        GameController.MainMenu(); //  calls gamecontroller function
    }
    #endregion
}
