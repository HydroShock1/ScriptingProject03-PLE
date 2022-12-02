using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraShake : MonoBehaviour
{
    [Header("Camera Shake")]
    [Tooltip("Drag your main camera here")]
    public Transform camera;
    [SerializeField]
    [Tooltip("Duration of the shaking")]
    [Range(0, 100)]
    public float _Duration = 1;
    [SerializeField]
    [Tooltip("Strength of the shaking")]
    [Range(0, 100)]
    public float _Strength = 1;
    [Tooltip("You can click here to make the shake happen manually or see when the shake is active")]
    public bool shouldShake = false;

    [Header("Character Objects")]
    [Tooltip("Drag your object in question here")]
    public GameObject _Object;


    Vector3 startPosition;
    float initialDuration;

    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = _Duration;
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            StartShaking();
        }

        if (!_Object.active)
        {
            TheShake();
        }
    }

    void TheShake()
    {
        if (shouldShake)
        {
            if (_Duration > 0)
            {
                camera.localPosition = startPosition + Random.insideUnitSphere * _Strength;
                _Duration -= Time.deltaTime;
            }
            else
            {
                shouldShake = false;
                _Duration = initialDuration;
                camera.localPosition = startPosition;
            }
        }
    }

    public void StartShaking()
    {
        _Object.gameObject.SetActive(false);
        shouldShake = true;
    }
}
