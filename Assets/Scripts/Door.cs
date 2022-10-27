using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Door : XRBaseInteractable
{
    public Transform doorTransform;
    public Vector3 dragDirection;
    public float dragDistance;
    public int doorWeight = 20;

    private Vector3 startPosition;
    private Vector3 endPosition;
    private Vector3 worldDragDirection;

    void Start()
    {
        worldDragDirection = transform.TransformDirection(dragDirection).normalized;

        startPosition = doorTransform.position;
        endPosition = startPosition + worldDragDirection * dragDistance;
    }

    public override void ProcessInteractable(XRInteractionUpdateOrder.UpdatePhase updatePhase)
    {
        base.ProcessInteractable(updatePhase);

        if (isSelected)
        {
            var interactorTransform = firstInteractorSelecting.GetAttachTransform(this);
            Vector3 selfToInteractor = interactorTransform.position - transform.position;
            float dotForDrag = Vector3.Dot(selfToInteractor, dragDirection);

            Vector3.MoveTowards(doorTransform.position, endPosition * dotForDrag, dragDistance);
        }
    }
}
