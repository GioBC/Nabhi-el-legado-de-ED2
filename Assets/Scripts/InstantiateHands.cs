using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.U2D.IK;

public class InstantiateHands : MonoBehaviour
{
    private Transform containerR;
    private Transform containerL;
    [SerializeField] private GameObject handL;
    [SerializeField] private GameObject handR;
    
    private GameObject handLI;
    private GameObject handRI;
    
    // Start is called before the first frame update
    void Start()
    {
        containerR = GameObject.Find("RightHandHandle").transform;
        handRI = (GameObject)Instantiate(handR, containerR.position, Quaternion.identity);
        handRI.name = "RightHand";

        containerL = GameObject.Find("LeftHandHandle").transform;
        handLI = (GameObject)Instantiate(handL, containerL.position, Quaternion.identity);
        handLI.name = "LeftHand";
    }
    
    // Update is called once per frame
    void Update()
    {
        if (containerR == null)
        {

            containerR = GameObject.Find("RightHandHandle").transform;
        }
        if (containerL == null)
        {
            containerL = GameObject.Find("LeftHandHandle").transform;
        }
        if (GameObject.Find("RightHand") == null)
        {
            handRI = (GameObject)Instantiate(handR, containerR.position, Quaternion.identity);
            handRI.name = "RightHand";
        }
        if (GameObject.Find("LeftHand") == null)
        {
            handLI = (GameObject)Instantiate(handL, containerL.position, Quaternion.identity);
            handLI.name = "LeftHand";
        }
        

    }
    
}
