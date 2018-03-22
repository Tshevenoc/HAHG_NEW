using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pick_Up : MonoBehaviour {
    public SteamVR_TrackedController left, right;
    private bool isGrabbed;
    private SteamVR_TrackedController grabbingCont = null;
    private FixedJoint holdJoint = null;
    private Vector3 oldPos;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

        bool newgrab = false;

        if (left.gripped && (transform.position - left.transform.position).sqrMagnitude < transform.localScale.sqrMagnitude / 4)
        {

            if (grabbingCont != left)
            {
                newgrab = true;
            }

            grabbingCont = left;

            if (!isGrabbed)
                SteamVR_Controller.Input((int)grabbingCont.controllerIndex).TriggerHapticPulse(2000);

            isGrabbed = true;
        }
        else if (right.gripped && (transform.position - right.transform.position).sqrMagnitude < transform.localScale.sqrMagnitude / 4)
        {

            if (grabbingCont != right)
            {
                newgrab = true;
            }

            grabbingCont = right;

            if (!isGrabbed)
                SteamVR_Controller.Input((int)grabbingCont.controllerIndex).TriggerHapticPulse(2000);

            isGrabbed = true;
        }
        else
        {
            isGrabbed = false;
        }

        if (newgrab)
        {
            Debug.Log("New Grab");
            holdJoint = gameObject.AddComponent<FixedJoint>();
            holdJoint.connectedBody = grabbingCont.GetComponent<Rigidbody>();
            holdJoint.breakForce = 400;
        }

        if (!isGrabbed && grabbingCont != null)
        {
            Debug.Log("End Grab");
            GetComponent<Rigidbody>().velocity += (transform.position - oldPos) / (Time.fixedDeltaTime * GetComponent<Rigidbody>().mass);


            if (holdJoint != null)
                Destroy(holdJoint);

            holdJoint = null;
            grabbingCont = null;
        }

        oldPos = transform.position;
    }
}
