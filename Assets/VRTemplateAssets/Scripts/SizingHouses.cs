using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.XR.Interaction.Toolkit;
using UnityEngine.XR.Interaction.Toolkit.Interactables;

public class TwoHandScale : MonoBehaviour
{
    [Header("Hand Tracking Actions")]
    public InputActionProperty leftPinchPos;
    public InputActionProperty rightPinchPos;

    [Header("Activation (Pinch)")]
    public InputActionProperty leftPinch;
    public InputActionProperty rightPinch;

    [Header("Grab Reference")]
    public XRGrabInteractable grabInteractable;

    private bool isGrabbed = false;
    private bool scaling = false;
    private float initialDistance;
    private Vector3 initialScale;

    void OnEnable()
    {
        grabInteractable.selectEntered.AddListener(OnGrab);
        grabInteractable.selectExited.AddListener(OnRelease);
    }

    void OnDisable()
    {
        grabInteractable.selectEntered.RemoveListener(OnGrab);
        grabInteractable.selectExited.RemoveListener(OnRelease);
    }

    private void OnGrab(SelectEnterEventArgs args)
    {
        isGrabbed = true;
    }

    private void OnRelease(SelectExitEventArgs args)
    {
        isGrabbed = false;
        scaling = false;
    }

    void Update()
    {
        // Only scale if THIS object is grabbed
        if (!isGrabbed)
        {
            scaling = false;
            return;
        }

        bool leftActive = leftPinch.action.IsPressed();
        bool rightActive = rightPinch.action.IsPressed();

        if (!leftActive || !rightActive)
        {
            scaling = false;
            return;
        }

        Vector3 leftPos = leftPinchPos.action.ReadValue<Vector3>();
        Vector3 rightPos = rightPinchPos.action.ReadValue<Vector3>();

        float currentDistance = Vector3.Distance(leftPos, rightPos);

        if (!scaling)
        {
            initialDistance = currentDistance;
            initialScale = transform.localScale;
            scaling = true;
        }

        float scaleFactor = currentDistance / initialDistance;
        transform.localScale = initialScale * scaleFactor;
    }
}
