using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShakeFlashFX : MonoBehaviour
{
    [Header("---Camera Shake---")]
    [Tooltip("Drag your main camera here")]
    public Transform camera;
    [SerializeField]
    [Tooltip("Duration of the shaking")]
    [Range(0, 50)]
    public float _Duration = 1;
    [SerializeField]
    [Tooltip("Strength of the shaking")]
    [Range(0, 100)]
    public float _Strength = 1;
    [Tooltip("You can click here to make the shake happen manually or see when the shake is active")]
    public bool shouldShake = false;


    [Header("---ScreenColorFlash---")]
    [SerializeField]
    [Tooltip("Drag the ScreenFlash Image from the UI here")]
    ScreenFlash _colorFlash = null;
    [SerializeField]
    [Tooltip("Set whatever color for the flash you want")]
    Color _screenColor = Color.red;
    [SerializeField]
    [Tooltip("Duration of the flash")]
    [Range(0, 50)]
    public float _FlashDuration = 1;
    [SerializeField]
    [Tooltip("Max Opacity of the Screen Flash")]
    [Range(0, 1)]
    public float _maxOpacity = 1;


    [Header("---Audio---")]
    [SerializeField]
    [Tooltip("Put in Your Audio FX")]
    public AudioClip deathFX;
    [SerializeField]
    [Tooltip("Put here the Main Camera")]
    public AudioSource audioSource;
    [SerializeField]
    [Tooltip("Change the volume")]
    [Range(0,50)]
    public float _Volume = 1;

    [Header("---Character Object---")]
    [Tooltip("Drag your Character in question here")]
    public GameObject _Object;




    Vector3 startPosition;
    float initialDuration;

    void Start()
    {
        camera = Camera.main.transform;
        startPosition = camera.localPosition;
        initialDuration = _Duration;
        audioSource = gameObject.GetComponent<AudioSource>();
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
        _colorFlash.StartFlash(_FlashDuration, _maxOpacity, _screenColor);
        audioSource.PlayOneShot(deathFX, _Volume);
    }
}
