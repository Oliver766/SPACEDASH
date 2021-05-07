using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShaking : MonoBehaviour
{
    #region shake function
    /// <summary>
    ///  method for camera shaking. returns duration of camera shake and magniture of camera shake.
    /// </summary>
    /// <param name="duration"></param>
    /// <param name="magnitude"></param>
    /// <returns></returns>
    public IEnumerator Shake(float duration,float magnitude)
    {
        Vector3 originalPos = transform.localPosition; // gets local position
        float elapsed = 0.0f; // sets elapsed time

        while(elapsed < duration)
        {
            float x = Random.Range(-1f, 1f) * magnitude; // gets a random range and multiplies it by magnitude for y
            float y = Random.Range(-1f, 1f) * magnitude;  // gets a random range and multiplies it by magnitude for x

            transform.localPosition = new Vector3(x, y, originalPos.z); // sets local position

            elapsed += Time.deltaTime; // elapsed time is  equal to time .delta time

            yield return null;
        }
        transform.localPosition = originalPos; // local position is original position

    }
    #endregion
}
