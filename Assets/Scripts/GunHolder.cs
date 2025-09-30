using MoreMountains.CorgiEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GunHolder : MonoBehaviour
{

    [SerializeField] private Transform holderGun;
    [SerializeField] private GameObject parentGun;
    public Transform gun;
    [SerializeField] private Transform spine1;
    [SerializeField] private Transform neck;
    [SerializeField] private Transform head;
    private Character GetCharacter;
    float t = -0.01f;
    public Quaternion rollRotation;


    protected virtual void Start()
    {
        Initialization();
    }

    protected virtual void Initialization()
    {
        
        GetCharacter = GetComponent<Character>();
    }

    void Update()
    {
        
        if (GetCharacter!= null)
        {
            gun = parentGun.transform.GetChild(0);
            if (GetCharacter.IsFacingRight)
            {
                Quaternion rotationToApplySpine1 = Quaternion.Slerp(Quaternion.identity, gun.rotation, 0.4f);
                Quaternion rotationToApplyNeck = Quaternion.Slerp(Quaternion.identity, gun.rotation, 0.2f);
                Quaternion rotationToApplyHead = Quaternion.Slerp(Quaternion.identity, gun.rotation, 0.1f);
                spine1.localRotation = rotationToApplySpine1;
                neck.localRotation = rotationToApplyNeck;
                head.localRotation = rotationToApplyHead;

            }
            else
            {
                Quaternion rotationToApply = Quaternion.Slerp(Quaternion.identity, Quaternion.Inverse(gun.rotation * rollRotation), 0.2f);
                spine1.localRotation = rotationToApply;
                neck.localRotation = rotationToApply;
                head.localRotation = rotationToApply;

            }
        }
        
    }
}
