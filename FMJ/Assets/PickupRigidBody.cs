using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickupRigidBody : MonoBehaviour
{

    private GameObject heldObj;
    public Transform holdParent;
    public float Force = 300;
    public float range = 10;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            if(heldObj == null)
            {
                if (Physics.Raycast(transform.position, transform.TransformDirection(Vector3.forward), out RaycastHit Hit, range))
                {
                    PickupObject(Hit.transform.gameObject);
                }

            }
            else
            {
                DropObj();
            }
        }

        if (heldObj != null)
        {
            MoveObject();
        }
    }

    void MoveObject()
    {
        if(Vector3.Distance(heldObj.transform.position, holdParent.position) > 0.1f )
        {
            Vector3 moveDirection = (holdParent.position - heldObj.transform.position);
            heldObj.GetComponent<Rigidbody>().AddForce(moveDirection * Force);
        }
    }

    void PickupObject(GameObject pickupObj)
    {
        if (pickupObj.GetComponent<Rigidbody>())
        {
            Rigidbody rigid = pickupObj.GetComponent<Rigidbody>();
            rigid.useGravity = false;
            rigid.drag = 10;

            rigid.transform.parent = holdParent;
            heldObj = pickupObj;
        }
    }

    void DropObj()
    {
        Rigidbody rigidHeld = heldObj.GetComponent<Rigidbody>();

        rigidHeld.useGravity = true;
        rigidHeld.drag = 1;
        heldObj.transform.parent = null;
        heldObj = null;
    }
}
