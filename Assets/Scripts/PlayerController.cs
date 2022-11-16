using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float torqueAmount = 1f;
    [SerializeField] float boostSpeed = 30f;
    [SerializeField] float defaultSpeed = 15f;

    SurfaceEffector2D surfaceEffector2D;
    bool canMove = true;

    private Rigidbody2D _rb2d;

    // Start is called before the first frame update
    void Start()
    {
        _rb2d = GetComponent<Rigidbody2D>();
        surfaceEffector2D = FindObjectOfType<SurfaceEffector2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if(canMove)
        {
            RotatePlayer();
            RespondToBoost();
        }
    }

    void RotatePlayer()
    {
        if (Input.GetKey(KeyCode.A))
        {
            _rb2d.AddTorque(torqueAmount);
        }
        else if (Input.GetKey(KeyCode.D))
        {
            _rb2d.AddTorque(-torqueAmount);
        }
    }

    void RespondToBoost()
    {
        // If "W" pressed speed doubles
        if(Input.GetKey(KeyCode.W))
        {
            surfaceEffector2D.speed = boostSpeed;
        }
        else if(Input.GetKey(KeyCode.S))
        {
            surfaceEffector2D.speed = defaultSpeed / 2f;
        }
        else
        {
            surfaceEffector2D.speed = defaultSpeed;
        }
    }

    public void DisableControls()
    {
        canMove = false;
    }
}
