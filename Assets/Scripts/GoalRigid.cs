using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalRigid : MonoBehaviour
{
    private Rigidbody rigid;
    private bool drop;
    private Vector3 startPoint;
    private Quaternion startRotation;

    // Start is called before the first frame update
    void Awake()
    {
        rigid = gameObject.GetComponent<Rigidbody>();
        startPoint = transform.position;
        startRotation = transform.rotation;
    }

    public void Reset(){
        rigid.useGravity = false;
        rigid.isKinematic = true;
        transform.position = startPoint;
        transform.rotation = startRotation;
        
        drop = false;
    }

    public void Drop(){
        rigid.useGravity = true;
        rigid.isKinematic = false;

        drop = true;
    }
}
