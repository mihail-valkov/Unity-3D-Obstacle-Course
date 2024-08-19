using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallColorChanger : MonoBehaviour
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
        material.color = changeToColor;
        if (colorCoroutine != null)
        {
            StopCoroutine(colorCoroutine); 
        }
        colorCoroutine = StartCoroutine(GameHelper.ChangeMateriaColorGradually(material, materialColor));
    }

}
