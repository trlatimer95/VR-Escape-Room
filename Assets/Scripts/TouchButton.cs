using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public int buttonValue;
    public Material buttonPressedMaterial;
    
    private NumberPad numPad;
    private MeshRenderer m_renderer;
    private Material buttonOriginalMaterial;

    void Start()
    {
        m_renderer = GetComponent<MeshRenderer>();
        numPad = GetComponentInParent<NumberPad>();
        buttonOriginalMaterial = m_renderer.material;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        m_renderer.material = buttonPressedMaterial;

        if (buttonValue >= 0)
            numPad.AddInput(buttonValue);
        else
            numPad.ResetInput(); 
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        m_renderer.material = buttonOriginalMaterial;
    }
}
