using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Explosion : MonoBehaviour
{

    public float time;
    public float size;
    private void Start()
    {
        StartCoroutine(Timer());
    }

    private void FixedUpdate()
    {
        transform.localScale += new Vector3(1,1,0) * size * Time.deltaTime;
    }

    IEnumerator Timer()
    {
        yield return new WaitForSeconds(time);
        Destroy(gameObject);
    }
}
