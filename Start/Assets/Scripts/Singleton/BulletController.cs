using System.Collections;
using System.Collections.Generic;
using UnityEngine;

// �̰� �־�� �浹����
[RequireComponent(typeof(Rigidbody))]
public class BulletController : MonoBehaviour
{

    private Rigidbody Rigid;

    //private void Awake()
    //{
    //    // ** ���� ������Ʈ�� �������� ���۳�Ʈ�� �޾ƿ�
    //    Rigid = GetComponent<Rigidbody>();
    //    
    //}
   //private void OnEnable()
   //{
   //    this.transform.parent = GameObject.Find("EnableList").transform;
   //
   //    // ���� �ڤ����� ��ġ
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
