using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SoundManager : MonoBehaviour
{
    [Header("Audio")]
    [SerializeField]
    [Tooltip("Put in Your Audio FX")]
    public AudioClip deathFX;
    public AudioSource audioSource;

    void Start()
    {

        audioSource = gameObject.GetComponent<AudioSource>();
    }

    void Update()
    {

        if (Input.GetKeyDown(KeyCode.Q))
        {
            audioSource.PlayOneShot(deathFX, 1);
        }

    }

}
