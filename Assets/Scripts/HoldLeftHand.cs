using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldLeftHand : MonoBehaviour
{
    private Transform leftHandHold;
    // Start is called before the first frame update
    void Start()
    {
        leftHandHold = GameObject.Find("LeftHandHandle").transform;

    }

    // Update is called once per frame
    void Update()
    {
        if (leftHandHold == null)
        {
            leftHandHold = GameObject.Find("LeftHandHandle").transform;
        }
        if (this.gameObject.name == "LeftHand")
        {
            transform.parent = leftHandHold.transform;
            transform.position = leftHandHold.position;
        }
        if (GameObject.Find("RightHand") != null && this.gameObject.name != "RightHand")
        {
            transform.position = GameObject.Find("LeftHand").transform.position;
            //transform.localRotation = rightHandHold.rotation;
        }
    }
}
