using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Reach : MonoBehaviour {

    Vector3 pivot = Vector3.zero;

    void Start()
    {
        pivot = transform.localPosition;
    }

    // Update is called once per frame
    void Update ()
    {
        bool touchpad = OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
        if (touchpad)
        {
            OVRInput.Controller activeController = OVRInput.GetActiveController();
            Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
            Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            transform.localPosition = pivot + (rot * Vector3.forward * primaryTouchpad.y);
        }
    }
}
