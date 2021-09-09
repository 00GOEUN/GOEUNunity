using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public GameObject Prefabs;

    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Q))
        {
            GameObject Obj = Instantiate(Prefabs);
            Obj.transform.position = new Vector3(0.0f, 0.0f, 0.0f);
            Obj.AddComponent<Rigidbody>();

            Rigidbody Rigid = Obj.GetComponent<Rigidbody>();
            Rigid.useGravity = false;

            Rigid.AddForce(this.transform.forward * 2000.0f);
        }
    }
}
