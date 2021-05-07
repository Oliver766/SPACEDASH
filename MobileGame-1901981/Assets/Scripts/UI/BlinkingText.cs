using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class BlinkingText : MonoBehaviour
{
    #region variables
    /// <summary>
    /// reference to text
    /// </summary>
    public Text text;
    #endregion
    #region start
    // Start is called before the first frame update
    void Start()
    {
        // get text component
        text = GetComponent<Text>();

    }
    #endregion
    #region blink
    /// <summary>
    /// coroutine tomake text blink
    /// </summary>
    /// <returns></returns>
    public IEnumerator blink()
    {
        while(true)
        {
            switch(text.color.a.ToString())
            {
                case "0":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 1); // text colour  equals new colour
                    yield return new WaitForSeconds(0.05f); // wait 0.5 seconds
                    break;
                case "1":
                    text.color = new Color(text.color.r, text.color.g, text.color.b, 0); // text colour  equals new colour
                    yield return new WaitForSeconds(0.5f); // wait 0.5 seconds
                    yield return new WaitForSeconds(0.5f) ;// wait 0.5 seconds
                    break;
            }
        }
    }
    #endregion
    #region start blinking
    /// <summary>
    /// function to start blinking
    /// </summary>
    public void startsBlinking()
    {
        StopCoroutine("Blink");
        StartCoroutine("Blink");
    }
    #endregion
    #region stop blinking
    /// <summary>
    /// function to stop blinking
    /// </summary>
    public void stopBlinking()
    {
        StopCoroutine("Blinking");
    }
    #endregion

}
