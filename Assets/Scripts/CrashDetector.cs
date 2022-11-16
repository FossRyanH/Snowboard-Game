using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class CrashDetector : MonoBehaviour
{
    [SerializeField] private float coolDownTimer = 1.5f;
    [SerializeField] private ParticleSystem _deathEffect;
    [SerializeField] AudioClip crashSound;

    bool playerCrashed = false;

    private void Start()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Ground" && !playerCrashed)
        {
            playerCrashed = true;
            FindObjectOfType<PlayerController>().DisableControls();
            _deathEffect.Play();
            GetComponent<AudioSource>().PlayOneShot(crashSound);
            Invoke("LoadScene", coolDownTimer);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene(0);
    }
}
