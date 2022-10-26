using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class TouchButton : XRBaseInteractable
{
    public int buttonValue;
    public Material buttonPressedMaterial;

    private MeshRenderer renderer;
    private Material buttonOriginalMaterial;

    void Start()
    {
        renderer = GetComponent<MeshRenderer>();
        buttonOriginalMaterial = renderer.material;
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);
        renderer.material = buttonPressedMaterial;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);
        renderer.material = buttonOriginalMaterial;
    }
}
