using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;
using TMPro;


public class TouchButton : XRBaseInteractable
{
    [Header("Touchpad Data")]
    public NumberPad numberPad;

    private Color hoverColor = Color.red;

    private int buttonIndex;

   
    private void Start()
    {
        numberPad = GameObject.FindGameObjectWithTag("Number Pad").GetComponent<NumberPad>();
        
        buttonIndex = int.Parse(name);
    }
    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        KeyColorChange();
        Debug.Log(buttonIndex);
        numberPad.RecordEnteredNumbers(buttonIndex);
    }
    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        KeyColorChange();
        

    }
    private void KeyColorChange()
    {
        if (GetComponent<Collider>().gameObject.CompareTag("Number"))
        {
            if(gameObject.GetComponentInChildren<TextMeshProUGUI>().color != hoverColor)
            {
                gameObject.GetComponentInChildren<TextMeshProUGUI>().color = hoverColor;
            }
            else if (gameObject.GetComponentInChildren<TextMeshProUGUI>().color == hoverColor)
            {
                gameObject.GetComponentInChildren<TextMeshProUGUI>().color = Color.black;
            }
        }
        
        
    }

}
