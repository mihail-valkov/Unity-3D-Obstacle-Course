using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float moveSpeed = 10f;
    private bool isColliding;
    private Coroutine colorCoroutine;
    private Coroutine stopCollidingCoroutine;
    Material playerMaterial;
    Color materialColor;

    // Start is called before the first frame update
    void Start()
    {
        //get player material
        playerMaterial = GetComponent<Renderer>().material;
        materialColor = playerMaterial.color;
    }

    // Update is called once per frame
    void Update()
    {
        Move();
    }

    private void Move()
    {
        if (isColliding)
            return;
        //move player x and z values according to input, y remains unchanged
        float xValue = Input.GetAxis("Horizontal") * Time.deltaTime * moveSpeed;
        float zValue = Input.GetAxis("Vertical") * Time.deltaTime * moveSpeed;
        float yValue = 0;
        transform.Translate(new Vector3(xValue, yValue, zValue));
    }

    //stop moving on collision in the diretion of the wall, only opposite direction is allowed
    private void OnCollisionEnter(Collision collision)
    {
        isColliding = true;

        List<ContactPoint> contactPoints = new List<ContactPoint>();
        collision.GetContacts(contactPoints);

        
        foreach (ContactPoint contact in contactPoints)
        {
            if (contact.normal == Vector3.forward || 
                contact.normal == Vector3.back || 
                contact.normal == Vector3.left || 
                contact.normal == Vector3.right)
            {
                transform.Translate(contact.normal / 25);
                //change player material color to red
                playerMaterial.color = Color.red;
            }
        }

        if (stopCollidingCoroutine != null)
        {
            StopCoroutine(stopCollidingCoroutine);
            stopCollidingCoroutine = null;
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        //Stop colliding but after a delay to avoid collision detection issues
        stopCollidingCoroutine = StartCoroutine(StopColliding());
    }

    IEnumerator StopColliding()
    {
        yield return new WaitForSeconds(0.35f);
        isColliding = false;
        //change player material color to previuos but gradually for 1 sedond
        if (colorCoroutine != null)
        {
            StopCoroutine(colorCoroutine);
        }
        colorCoroutine = StartCoroutine(GameHelper.ChangeMateriaColorGradually(playerMaterial, materialColor));
    }

}
