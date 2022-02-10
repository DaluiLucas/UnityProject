using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LightSwitchRaycast : MonoBehaviour
{
    [SerializeField] private int rayLength = 5;
    private LightSwitchController LightSwitch;

    private void Update()
    {
        
        Vector3 ForwardVector = transform.TransformDirection(Vector3.forward);
        if (Physics.Raycast(transform.position, ForwardVector, out RaycastHit hit, rayLength))
        {
            
            var raycastObj = hit.collider.gameObject.GetComponent<LightSwitchController>();
            if (raycastObj != null)
            {
                LightSwitch = raycastObj;
            }
            else
            {
                ClearInteraction();
            }
        }
        else
        {
            ClearInteraction();
        }

        if (LightSwitch != null)
        {
            if (Input.GetKeyDown(KeyCode.E))
            {
                LightSwitch.Interact();
            }
        }
    }

    private void ClearInteraction()
    {
        if(LightSwitch != null)
        {
            LightSwitch = null;
        }
    }
}
