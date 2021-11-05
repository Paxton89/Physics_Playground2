using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FoVCamera : MonoBehaviour
{
    private Camera _cam;
    private Player _player;
    
    private void Start()
    {
        _cam  = Camera.main;
        _player = FindObjectOfType<Player>();
    }

    void FixedUpdate()
    {
        _cam.transform.position = new Vector3(_player.transform.position.x,_player.transform.position.y,0 );
    }

    public void ShakeScreen(float power, float length)
    {
        
    }
}
