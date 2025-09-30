using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoldRightHand : MonoBehaviour
{
    private Transform rightHandHold;
    // Start is called before the first frame update
    void Start()
    {
        rightHandHold = GameObject.Find("RightHandHandle").transform;
        
    }

    // Update is called once per frame
    void Update()
    {
        if (rightHandHold == null)
        {
            rightHandHold = GameObject.Find("RightHandHandle").transform;
        }
        if (this.gameObject.name == "RightHand")
        {
            transform.parent = rightHandHold.transform;
            transform.position = rightHandHold.position;
            transform.rotation = Quaternion.identity;
        }
        if(GameObject.Find("RightHand")!=null&&this.gameObject.name!="RightHand")
        {
            transform.position = GameObject.Find("RightHand").transform.position;
            //transform.localRotation = rightHandHold.rotation;
        }
    }
}
