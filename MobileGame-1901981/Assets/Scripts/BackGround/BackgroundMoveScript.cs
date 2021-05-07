using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BackgroundMoveScript : MonoBehaviour {

	#region variables
	/// <summary>
	/// Background scroll speed can be set in Inspector with slider
	/// </summary>
	[Range(1f, 20f)]
	public float scrollSpeed = 1f;
	/// <summary>
	/// Scroll offset value to smoothly repeat backgrounds movement
	/// </summary>
	public float scrollOffset;
	/// <summary>
	/// Start position of background movement
	/// </summary>
	Vector2 startPos;
	/// <summary>
	/// // Backgrounds new position
	/// </summary>
	float newPos;
    #endregion
    #region start
    void Start () {
		// Getting backgrounds start position
		startPos = transform.position;
	}
    #endregion
    #region update
    // Update is called once per frame
    void Update () {
		// Calculating new backgrounds position repeating it depending on scrollOffset
		newPos = Mathf.Repeat (Time.time * - scrollSpeed, scrollOffset);

		// Setting new position
		transform.position = startPos + Vector2.right * newPos;
	}
    #endregion
}
