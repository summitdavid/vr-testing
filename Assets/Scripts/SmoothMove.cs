using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class SmoothMove : MonoBehaviour {
    float speed = 0.05f;
    public GameObject skinedmesh;

	
	// Update is called once per frame
	void Update ()
    {
        bool trigger = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger) || Input.GetKeyDown(KeyCode.A);
        if(trigger){
            Instantiate(skinedmesh, transform.position + transform.forward * 5, transform.rotation);
        }
        bool touchpad = OVRInput.Get(OVRInput.Touch.PrimaryTouchpad);
        if (touchpad)
        {
            OVRInput.Controller activeController = OVRInput.GetActiveController();
            Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
            // data.AppendFormat("Orientation: ({0:F2}, {1:F2}, {2:F2}, {3:F2})\n", rot.x, rot.y, rot.z, rot.w);
            Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            // data.AppendFormat("PrimaryTouchpad: ({0:F2}, {1:F2})\n", primaryTouchpad.x, primaryTouchpad.y);
            if (primaryTouchpad.y > 0.5)
            {
                transform.position += speed * (rot * Vector3.forward);
            }
            else if (primaryTouchpad.y < -0.5)
            {
                transform.position -= speed * (rot * Vector3.forward);
            }
            if (primaryTouchpad.x > 0.5)
            {
                transform.position += speed * (rot * Vector3.right);
            }
            else if (primaryTouchpad.x < -0.5)
            {
                transform.position -= speed * (rot * Vector3.right);
            }
        }
    }
}
