using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timeToDrop = 3f;
    private float initialTime;
    private new Renderer renderer;

    private void Start()
    {
        initialTime = Time.time;
        renderer = GetComponent<Renderer>();
        renderer.enabled = false;
    }

    void Update()
    {
        if (Time.time - initialTime >= timeToDrop)
        {
            Drop();
        }
    }

    void Drop()
    {
        renderer.enabled = true;
        GetComponent<Rigidbody>().useGravity = true;
    }
}
