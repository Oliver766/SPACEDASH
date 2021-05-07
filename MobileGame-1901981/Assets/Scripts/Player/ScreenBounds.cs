using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScreenBounds : MonoBehaviour
{
    #region variables
    /// <summary>
    /// main camera reference
    /// </summary>
    public Camera MainCamera;
    /// <summary>
    /// screen bounds
    /// </summary>
    private Vector2 screenBounds;
    /// <summary>
    /// object width
    /// </summary>
    private float objectWidth;
    /// <summary>
    /// object height
    /// </summary>
    private float objectHeight;
    #endregion
    #region start
    // Use this for initialization
    void Start()
    {
        // ssets screen bounds
        screenBounds = MainCamera.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, MainCamera.transform.position.z));
        // sets object width
        objectWidth = transform.GetComponent<SpriteRenderer>().bounds.extents.x; //extents = size of width / 2
        // sets object height
        objectHeight = transform.GetComponent<SpriteRenderer>().bounds.extents.y; //extents = size of height / 2
    }
    #endregion
    #region lateupdate
    // Update is called once per frame
    void LateUpdate()
    {
        // update view position
        Vector3 viewPos = transform.position;
        // sets view pos.x
        viewPos.x = Mathf.Clamp(viewPos.x, screenBounds.x + objectWidth, screenBounds.x * -1 - objectWidth);
        // sets position.y
        viewPos.y = Mathf.Clamp(viewPos.y, screenBounds.y + objectHeight, screenBounds.y * -1 - objectHeight);
        // sets transform .position for view position
        transform.position = viewPos;
    }
    #endregion
}


