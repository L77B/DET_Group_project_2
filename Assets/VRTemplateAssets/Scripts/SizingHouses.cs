using UnityEngine;
using UnityEngine.InputSystem;

public class SizingHouses : MonoBehaviour
{
    [Header("Input Actions")]
    public InputActionProperty leftHandPosition;
    public InputActionProperty rightHandPosition;

    [Header("Optional Activation")]
    public InputActionProperty leftPinch;
    public InputActionProperty rightPinch;

    private bool scalingActive = false;
    private float initialDistance;
    private Vector3 initialScale;

    void Update()
    {
        Vector3 leftPos = leftHandPosition.action.ReadValue<Vector3>();
        Vector3 rightPos = rightHandPosition.action.ReadValue<Vector3>();

        float currentDistance = Vector3.Distance(leftPos, rightPos);

        bool pinch = true; // always active unless you want pinch activation

        if (leftPinch != null && rightPinch != null)
        {
            pinch = leftPinch.action.IsPressed() && rightPinch.action.IsPressed();
        }

        if (pinch)
        {
            if (!scalingActive)
            {
                initialDistance = currentDistance;
                initialScale = transform.localScale;
                scalingActive = true;
            }

            float scaleFactor = currentDistance / initialDistance;
            transform.localScale = initialScale * scaleFactor;
        }
        else
        {
            scalingActive = false;
        }
    }
}
