using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishLine : MonoBehaviour
{
    [SerializeField] private float coolDownTimer = 1.5f;
    [SerializeField] private ParticleSystem _finishParticle;
    
    private void OnTriggerEnter2D(Collider2D col)
    {
        if (col.tag == "Player")
        {
            _finishParticle.Play();
            Invoke("LoadScene", coolDownTimer);
        }
    }

    void LoadScene()
    {
        SceneManager.LoadScene("Level01");
    }
}
