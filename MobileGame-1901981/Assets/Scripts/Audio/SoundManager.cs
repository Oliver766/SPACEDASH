using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    #region variables
    /// <summary>
    /// audio references
    /// </summary>
    public static AudioClip shootSound, astroidsDestroy, playerHit,playerDead;
    /// <summary>
    /// audio source reference
    /// </summary>
    static AudioSource audioScr;
    #endregion
    #region start
    // Start is called before the first frame update
    void Start()
    {
        // geets each sound from recources folder
        shootSound = Resources.Load<AudioClip>("shoot1");
        astroidsDestroy = Resources.Load<AudioClip>("hit01");
        playerHit = Resources.Load<AudioClip>("hit06");
        playerDead = Resources.Load<AudioClip>("hit12");
        audioScr = GetComponent<AudioSource>();
    }
    #endregion
    #region play sound
    /// <summary>
    /// gets sounds and makes them one interation of sound per interaction
    /// </summary>
    /// <param name="clip"></param>
    public static void playSound(string clip)
    {
        switch (clip)
        {
            case "shoot1":
                audioScr.PlayOneShot(shootSound); // play sound
                break;
            case "hit01":
                audioScr.PlayOneShot(astroidsDestroy);// play sound
                break;
            case "hit06":
                audioScr.PlayOneShot(playerHit);// play sound
                break;
            case "hit12":
                audioScr.PlayOneShot(playerDead);// play sound
                break;

        }
    }

    #endregion


}
