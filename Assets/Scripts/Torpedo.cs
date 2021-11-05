using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Torpedo : MonoBehaviour
{
    private Player _player;
    private Rigidbody2D _body;
    private Planet[] _planets;
    
    public Explosion explosionPreFab;
    public float impulsePower;
    private void Start()
    {
        _player = FindObjectOfType<Player>();
        _planets = FindObjectsOfType<Planet>();
        _body = GetComponent<Rigidbody2D>();
        Launch();
    }

    private void FixedUpdate()
    {
        ApplyForces();
    }

    private void Launch()
    {
        _body.AddForce(impulsePower* transform.up, ForceMode2D.Impulse);
    }
    private void ApplyForces()
    {
        foreach (var planet in _planets)
        {
            var dirToPlanet = (planet.transform.position - transform.position).normalized;
            var distanceToPlanet = (Vector2.Distance(transform.position, planet.transform.position));
            var ForceMagnitude = (_body.mass * planet.mass) / Mathf.Pow(distanceToPlanet, 2);
            var Force = dirToPlanet * ForceMagnitude;
            _body.AddForce(Force);
            Debug.DrawLine(transform.position, transform.position + Force, Color.magenta);
        }
    }
    
    IEnumerator Timer() // Unused
    {
        yield return new WaitForSeconds(0f);
        Debug.Log("BooM!");
        var newExplosion = Instantiate(explosionPreFab);
        newExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, 35);
        Destroy(gameObject);
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.tag == "Planet")
        {
            Debug.Log("Boom!");
            var newExplosion = Instantiate(explosionPreFab);
            newExplosion.transform.position = new Vector3(transform.position.x, transform.position.y, 35);
            Destroy(gameObject);
        }
    }
}
