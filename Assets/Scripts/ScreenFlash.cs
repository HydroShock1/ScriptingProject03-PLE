using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


[RequireComponent(typeof(Image))]
public class ScreenFlash : MonoBehaviour
{
    Image _image = null;
    Coroutine _currentFlashRoutine = null;

    private void Awake()
    {
        _image = GetComponent<Image>();
    }

    public void StartFlash(float secondsForOneFlash, float maxOpacity, Color newColor)
    {
        _image.color = newColor;


        maxOpacity = Mathf.Clamp(maxOpacity, 0, 1);

        if (_currentFlashRoutine != null)
            StopCoroutine(_currentFlashRoutine);
        _currentFlashRoutine = StartCoroutine(Flash(secondsForOneFlash, maxOpacity));
    }

    IEnumerator Flash(float secondsForOneFlash, float maxOpacity)
    {
        float flashInDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashInDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(0, maxOpacity, t / flashInDuration);
            _image.color = colorThisFrame;

            yield return null;
        }

        float flashOutDuration = secondsForOneFlash / 2;
        for (float t = 0; t <= flashOutDuration; t += Time.deltaTime)
        {
            Color colorThisFrame = _image.color;
            colorThisFrame.a = Mathf.Lerp(maxOpacity, 0, t / flashOutDuration);
            _image.color = colorThisFrame;

            yield return null;
        }
    }
}
