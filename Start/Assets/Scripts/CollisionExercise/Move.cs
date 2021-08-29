using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))]
public class Move : MonoBehaviour
{
    private Rigidbody Rigid;

    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
    }

    void Start()
    {
        //Rigid.useGravity = false;
        Rigid.AddForce(this.transform.forward * 2000.0f);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collider other)
    {
        Debug.Log("OnTriggerEnter");
    }
}
