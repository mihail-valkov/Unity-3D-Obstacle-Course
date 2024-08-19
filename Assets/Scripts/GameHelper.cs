using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameHelper : MonoBehaviour
{
    public static IEnumerator ChangeMateriaColorGradually(Material material, Color targetColor)
    {
        yield return new WaitForSeconds(0.2f);
        float elapsedTime = 0;
        while (elapsedTime < 1)
        {
            material.color = Color.Lerp(material.color, targetColor, elapsedTime);
            elapsedTime += Time.deltaTime;
            yield return null;
        }
    }
}
