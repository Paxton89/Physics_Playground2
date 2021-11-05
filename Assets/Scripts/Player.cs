using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.PlayerLoop;

public class Player : MonoBehaviour
{
    private Planet[] _planets;
    private Rigidbody2D _body;
    private PlayerControllerManager _playerInput;
    private Vector2 _movementInput;
    private Vector2 _gravity;
    private float _rotation;
    private float _forwardMovement;
    private float _cachedBoostPower;
    private bool _bIsGrounded;
    private bool _bIsBoosting;
    
    public Torpedo torpedo;
    public GameObject leftFire;
    public GameObject rightFire;
    public float GravityBorder;
    public float rotationSpeed = 2;
    public float moveSpeed = 6;
    public float boostPower = 6;

    private void Awake()
    {
        _body = GetComponent<Rigidbody2D>();
        
        _playerInput = new PlayerControllerManager();
        _playerInput.Enable();
        _playerInput.Player.Forward.performed += context => OnForward(context.ReadValue<float>());
        _playerInput.Player.Forward.canceled += context => OnForward(context.ReadValue<float>());
        _playerInput.Player.Rotate.performed += context => OnRotate(context.ReadValue<float>());
        _playerInput.Player.Rotate.canceled += context => OnRotate(context.ReadValue<float>());
        _playerInput.Player.Boost.performed += context => OnBoost();
        _playerInput.Player.Boost.canceled += context => OnBoost();
        _playerInput.Player.FireTorpedo.performed += context => LaunchTorpedo();
        //_playerInput.Player.FireTorpedo.canceled += context => LaunchTorpedo();
    }

    void Start()
    {
        _planets = FindObjectsOfType<Planet>();
        _cachedBoostPower = boostPower;
    }

    private void Update()
    {
        DrawStuff();
        if (_forwardMovement > 0)
        {
            leftFire.SetActive(true);
            rightFire.SetActive(true);
            if (!_bIsBoosting) // Shrink boosterFlame
            {
                var currentLeft = leftFire.transform.lossyScale.y;
                leftFire.transform.localScale = new Vector3(1,Mathf.Lerp(currentLeft, 1, 6f * Time.deltaTime),1);

                var currentRight = rightFire.transform.lossyScale.y;
                rightFire.transform.localScale = new Vector3(1,Mathf.Lerp(currentRight, 1, 6f * Time.deltaTime),1);
            }
            else if (_bIsBoosting) //Grow boosterFlame
            {
                boostPower = _cachedBoostPower;
                
                var currentLeft = leftFire.transform.lossyScale.y;
                leftFire.transform.localScale = new Vector3(1,Mathf.Lerp(currentLeft, 4f, 4f * Time.deltaTime),1);

                var currentRight = rightFire.transform.lossyScale.y;
                rightFire.transform.localScale = new Vector3(1,Mathf.Lerp(currentRight, 4f, 4f * Time.deltaTime),1);

                Debug.Log("Boosting!");
            }
        }
        else
        {
            leftFire.SetActive(false);
            rightFire.SetActive(false);
            boostPower = 1;
        }
    }

    void FixedUpdate()
    {
        ApplyForces();
        transform.Rotate(new Vector3(0,0,_rotation * rotationSpeed));
        _body.AddForce(_forwardMovement * transform.up * moveSpeed * boostPower);
    }

    private void OnForward(float value)
    {
        _forwardMovement = value;
    }
    private void OnRotate(float value)
    {
        _rotation = value;
    }
    private void OnBoost()
    {
        _bIsBoosting = !_bIsBoosting;
    }
    private void ApplyForces()
    {
        foreach (var planet in _planets)
        {
            GravityBorder = planet.mass / 100;
            if (Vector2.Distance(transform.position, planet.transform.position) < GravityBorder)
            {
                var dirToPlanet = (planet.transform.position - transform.position).normalized;
                var distanceToPlanet = (Vector2.Distance(transform.position, planet.transform.position));
                var ForceMagnitude = (_body.mass * planet.mass) / Mathf.Pow(distanceToPlanet, 2);
                var Force = dirToPlanet * ForceMagnitude;
                _body.AddForce(Force);
                Debug.DrawLine(transform.position, transform.position + Force, Color.magenta);   
            }
            Debug.DrawLine(planet.transform.position,planet.transform.position + (planet.transform.position - transform.position).normalized *-GravityBorder);
        }
    }
    private void DrawStuff()
    {
        Debug.DrawLine(transform.position, transform.position + -(Vector3)_body.velocity, Color.yellow);
        Debug.DrawLine(transform.position, transform.position + transform.TransformVector(Vector2.up), Color.green);
        Debug.DrawLine(transform.position, transform.position + transform.TransformVector(Vector2.right), Color.red);
        
    }

    private void LaunchTorpedo()
    {
        Instantiate(torpedo, transform.position, transform.rotation);
    }
    private void OnTriggerStay2D(Collider2D other)
    {
        _bIsGrounded = true;
    }
}
