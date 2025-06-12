using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.InputSystem;

public class GrabController : MonoBehaviour
{
    //Right
    [SerializeField]
    private Transform grabPoint;

    [SerializeField]
    private Transform rayPoint;
    [SerializeField]
    private float rayDistance;

    //Left
    [SerializeField]
    private Transform grabPoint2;

    [SerializeField]
    private Transform rayPoint2;
    [SerializeField]
    private float rayDistance2;

    private GameObject grabbedObject;
    private GameObject grabbedObject2;


    private int layerIndex;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        layerIndex = LayerMask.NameToLayer("Objects");
    }

    // Update is called once per frame
    void Update()
    {
        //Right
        RaycastHit2D hitInfo = Physics2D.Raycast(rayPoint.position, transform.right, rayDistance);

        if (hitInfo.collider != null && hitInfo.collider.gameObject.layer == layerIndex)
        {
            //Grab object
            if (Keyboard.current.spaceKey.wasPressedThisFrame && grabbedObject == null)
            {
                grabbedObject = hitInfo.collider.gameObject;
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabbedObject.transform.position = grabPoint.position;
                grabbedObject.transform.SetParent(transform);   
            }

            else if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                grabbedObject.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabbedObject.transform.SetParent(null);
                grabbedObject = null;
            }
        }

        Debug.DrawRay(rayPoint.position, transform.right *  rayDistance);

        //left
        RaycastHit2D hitInfo2 = Physics2D.Raycast(rayPoint2.position, -transform.right, rayDistance2);

        if (hitInfo2.collider != null && hitInfo2.collider.gameObject.layer == layerIndex)
        {
            //Grab object
            if (Keyboard.current.spaceKey.wasPressedThisFrame && grabbedObject2 == null)
            {
                grabbedObject2 = hitInfo2.collider.gameObject;
                grabbedObject2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Kinematic;
                grabbedObject2.transform.position = grabPoint2.position;
                grabbedObject2.transform.SetParent(transform);
            }

            else if (Keyboard.current.spaceKey.wasPressedThisFrame)
            {
                grabbedObject2.GetComponent<Rigidbody2D>().bodyType = RigidbodyType2D.Dynamic;
                grabbedObject2.transform.SetParent(null);
                grabbedObject2 = null;
            }
        }

        Debug.DrawRay(rayPoint2.position, -transform.right * rayDistance2);
    }
}
