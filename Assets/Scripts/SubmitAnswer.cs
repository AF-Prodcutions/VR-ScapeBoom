using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;

public class SubmitAnswer : XRBaseInteractable
{

    [Header("Submit Data")]
    public NumberPad numberPad;
    //public Keycard keycard;

    private void Start()
    {
        numberPad = GameObject.FindGameObjectWithTag("Number Pad").GetComponent<NumberPad>();

    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        numberPad.ProduceCard(); 
    }
}
