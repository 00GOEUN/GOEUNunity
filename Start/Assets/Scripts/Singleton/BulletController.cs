using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// 이게 있어야 충돌가능
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{

    private Rigidbody Rigid;

    //private void Awake()
    //{
    //    // ** 현재 오브젝트의 물리엔진 컴퍼넌트를 받아옴
    //    Rigid = GetComponent<Rigidbody>();
    //    
    //}
   //private void OnEnable()
   //{
   //    this.transform.parent = GameObject.Find("EnableList").transform;
   //
   //    // 현재 자ㅇ신의 위치
   //    //this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));
   //
   //}

    // Start is called before the first frame update
    void Start()
    {
        Rigid.useGravity = false;

        Collider Collobj = GetComponent<SphereCollider>();

        Collobj.isTrigger = true;

        Rigid.AddForce(this.transform.forward * 500.0f);
        
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Ground")
        {
            Destroy(this.gameObject);
        }

    }
}
