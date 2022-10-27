using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class CardReader : XRSocketInteractor
{
    public float minSwipeDistance;
    public float allowableUprightRange;
    public GameObject lockToHide;
    public XRGrabInteractable doorHandleInteractable;

    private Transform keycardTransform;
    private Vector3 cardEntryPosition;
    private bool swipeIsValid;

    private void Update()
    {
        if (keycardTransform != null)
        {
            Vector3 keycardUp = keycardTransform.forward;
            float dot = Vector3.Dot(keycardUp, Vector3.up);
            
            if (dot < 1 - allowableUprightRange)
                swipeIsValid = false;
        }
    }

    protected override void OnHoverEntered(HoverEnterEventArgs args)
    {
        base.OnHoverEntered(args);

        keycardTransform = args.interactableObject.transform;
        cardEntryPosition = keycardTransform.position;
        swipeIsValid = true;
    }

    protected override void OnHoverExited(HoverExitEventArgs args)
    {
        base.OnHoverExited(args);

        Vector3 swipeLength = args.interactableObject.transform.position - cardEntryPosition;
        if (swipeIsValid && swipeLength.y < minSwipeDistance)
        {
            lockToHide.gameObject.SetActive(false);
            doorHandleInteractable.enabled = true;
        }

        keycardTransform = null;
    }

    // Prevent snapping
    public override bool CanSelect(IXRSelectInteractable interactable)
    {
        return false;
    }
}
