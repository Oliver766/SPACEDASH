using System.Collections;
using System.Collections.Generic;
using System.ComponentModel;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    #region variables
    /// <summary>
    /// controls game object
    /// </summary>
    public GameObject panel;
    /// <summary>
    /// mainmenu animator
    /// </summary>
    public Animator mainMenu;
    /// <summary>
    /// controls menu animator
    /// </summary>
    public Animator ControlsMenu;
    /// <summary>
    /// game controller reference
    /// </summary>
    private GameController controller;
    /// <summary>
    /// credits game objecy
    /// </summary>
    public GameObject credits;
    /// <summary>
    /// credits animation
    /// </summary>
    public Animator creditsanim;
    /// <summary>
    /// game object menu
    /// </summary>
    public GameObject menu;
    #endregion
    #region start
    public void start()
    {
        // get game controller
        controller = GetComponent<GameController>(); 
        credits.SetActive(false); //sets credits to false
        panel.SetActive(false); //sets controls to false
    }
    #endregion
    #region controls
    /// <summary>
    /// controlls function
    /// </summary>
    public void controlls()
    {
        panel.SetActive(true); // set active
        StartCoroutine(ControllsAnimation()); // start corountine
    }
    #endregion#
    #region creditsmenu
    /// <summary>
    /// credits menu function
    /// </summary>
    public void creditsmenu()
    {
        credits.SetActive(true); // set active
        StartCoroutine(creditsanimdown()); // start corountine
    }
    #endregion
    #region back
    /// <summary>
    /// back function for controls menu
    /// </summary>
    public void back()
    {
        StartCoroutine(controllsAnimUp()); // start corountine
    }
    #endregion
    #region backcredits
    /// <summary>
    /// back function for credits function
    /// </summary>
    public void backCredits()
    {
        StartCoroutine(creditsanimUp()); // start corountine
    }
    #endregion
    #region control anim
    /// <summary>
    /// coroutine to run menu animation  and controlls aniamtion
    /// </summary>
    /// <returns></returns>
    public IEnumerator ControllsAnimation()
    {
        mainMenu.Play("MainMenuUp"); // play animation
        yield return new WaitForSeconds(0.2f); // wait for 0.2 seconds
        menu.SetActive(false); // set active to false
        ControlsMenu.Play("Controls"); // play animation
        StopCoroutine(ControllsAnimation()); // stop coroutine
    }
    #endregion
    #region creditsanim1
    /// <summary>
    /// coroutine to play menu animation and credits function
    /// </summary>
    /// <returns></returns>
    public IEnumerator creditsanimdown()
    {
        mainMenu.Play("MainMenuUp"); // play animation
        yield return new WaitForSeconds(0.2f);// wait for 0.2 seconds
        menu.SetActive(false); // set active to false
        creditsanim.Play("CreditsDown"); // play animation
        StopCoroutine(creditsanimdown());// stop coroutine
    }
    #endregion
    #region controllsanim2
    /// <summary>
    ///  coroutine to run menu animation  and controlls aniamtion
    /// </summary>
    /// <returns></returns>
    public IEnumerator controllsAnimUp()
    {
        menu.SetActive(true); // set active
        mainMenu.Play("mainmenuDown"); // play animation
        yield return new WaitForSeconds(0.2f); // wait 0.2 seconds
        ControlsMenu.Play("ControlsUP"); // play animation
        yield return new WaitForSeconds(0.4f); // wait 0.4 seconds
        credits.SetActive(false); // set active to false
        StopCoroutine(controllsAnimUp()); //  stop coroutine
       
    }
    #endregion
    #region creditsanim2
    /// <summary>
    /// coroutine to play menu animation and credits function
    /// </summary>
    /// <returns></returns>
    public IEnumerator creditsanimUp()
    {
        menu.SetActive(true); // set active
        mainMenu.Play("mainmenuDown"); // play animation
        yield return new WaitForSeconds(0.2f); // wait 2 seconds
        creditsanim.Play("creditsup"); // play aniamtion
        yield return new WaitForSeconds(0.4f); // wait 0.4 seconds
        panel.SetActive(false); // set active to false
        StopCoroutine(creditsanimUp()); // stop coroutine


    }
    #endregion
}
