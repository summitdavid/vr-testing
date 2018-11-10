using UnityEngine;
using UnityEngine.UI;
using System.Collections;
using System.Collections.Generic;
using System.Text;

public class SmoothMove : MonoBehaviour {
    float speed = 0.1f;
	
	// Update is called once per frame
	void Update ()
    {
        bool trigger = OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger);
        if(trigger)
        {
            OVRInput.Controller activeController = OVRInput.GetActiveController();
            Quaternion rot = OVRInput.GetLocalControllerRotation(activeController);
            // data.AppendFormat("Orientation: ({0:F2}, {1:F2}, {2:F2}, {3:F2})\n", rot.x, rot.y, rot.z, rot.w);
            Vector2 primaryTouchpad = OVRInput.Get(OVRInput.Axis2D.PrimaryTouchpad);
            // data.AppendFormat("PrimaryTouchpad: ({0:F2}, {1:F2})\n", primaryTouchpad.x, primaryTouchpad.y);
            float y = primaryTouchpad.y;
            if (y > 0.5)
            {
                transform.position += speed * (rot * Vector3.forward);
            }
            else if (y > 0)
            {
                transform.position += speed * (rot * Vector3.forward) / 2;
            }
            else if (y > -0.5)
            {
                transform.position += speed * (rot * Vector3.forward) / 4;
            }
        }
    }
}
