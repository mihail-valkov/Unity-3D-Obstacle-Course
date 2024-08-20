using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float speed = 5f;

    // Update is called once per frame
    void Update()
    {
        //apply spin around the y-axis based on time and speed
        transform.Rotate(Vector3.up, Time.deltaTime * speed);
    }
}
