using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RagdollContoller : MonoBehaviour
{

    private List<Vector3> childPosition; //List of vector 3's
    private List<Quaternion> childRotation; //list of object rotations

    private Animator anim; //animator component

    // Start is called before the first frame update
    void Start()
    {
        childPosition = new List<Vector3>();
        childRotation = new List<Quaternion>();
        anim = GetComponent<Animator>();

        RagdollOn(false);
    }

    //turn on ragdoll
    public void RagdollOn(bool ragdoll)
    {
        Rigidbody[] bodies = GetComponentsInChildren<Rigidbody>();
        foreach(var rb in bodies)
        {
            rb.isKinematic = !ragdoll; 
        }
        anim.enabled = !ragdoll;
    }

    //get original positions of bones in model
    void GetTPose()
    {
        Transform[] children = GetComponentsInChildren<Transform>();
        foreach(var trans in children)
        {
            childPosition.Add(trans.localPosition);
            childRotation.Add(trans.localRotation);
        }
    }
}
