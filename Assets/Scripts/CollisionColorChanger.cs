using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollisionColorChanger : MonoBehaviour
{
    [SerializeField] Color changeToColor = Color.red;

    Material material;
    Color materialColor;
    private Coroutine colorCoroutine;

    void Start()
    {
        material = GetComponent<Renderer>().material;
        materialColor = material.color;
    }

    void OnCollisionEnter(Collision other)
    {
        //return if not colliding with player
        if (other.gameObject.tag != "Player")
        {
            return;
        }

        material.color = changeToColor;
        if (colorCoroutine != null)
        {
            StopCoroutine(colorCoroutine); 
        }
        colorCoroutine = StartCoroutine(GameHelper.ChangeMateriaColorGradually(material, materialColor));
    }

}
