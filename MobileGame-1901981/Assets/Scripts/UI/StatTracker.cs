using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StatTracker : MonoBehaviour
{
    #region variables
    /// <summary>
    /// reference to text
    /// </summary>
    public Text score;
    #endregion
    #region update
    // Update is called once per frame
    void Update()
    {
        // update score text with score from game controller
        score.text = GameController.Score.ToString();

    }
    #endregion
}
