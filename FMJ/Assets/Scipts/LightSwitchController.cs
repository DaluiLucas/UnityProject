using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class LightSwitchController : MonoBehaviour
{
    [SerializeField] private bool LightON;
    [SerializeField] private UnityEvent LightOnEvent;
    [SerializeField] private UnityEvent LightOffEvent;

    public void Interact()
    {
        if(!LightON)
        {
            LightON = true;
            LightOnEvent.Invoke();
        }
        else
        {
            LightON = false;
            LightOffEvent.Invoke();
        }
    }
}
