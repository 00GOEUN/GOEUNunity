using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))] //컴퍼넌트에 리지드바디 없어도 강제로 꼽아넣는거

public class Why : MonoBehaviour
{
    [SerializeField] private float Force;
    //private Vector3 TargetPoint;
    //[SerializeField] private GameObject TargetPoint;

    private Rigidbody Rigid;

    // public GameObject Target;

    // 생성자 비슷
    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        //TargetPoint = GameObject.Find("TagetPoint");

    } //Rigidbodey = 물리엔진

    // 이니셜라이즈 비슷
    void Start()
    {
        Rigid.useGravity = false; //스크립트로 컴퍼넌트 받아와서 하는고
        //TargetPoint.transform.position = this.transform.position;


         Force = 2000.0f;

        //** 힘을 가하여 이동시킴.
        Rigid.useGravity = false;

        // 직진
        Rigid.AddForce(Vector3.forward * Force);
        // 내가 바라보는 방향으로
        //Rigid.AddForce(Vector3.Trasnsforward * Force);

        // forward : 앞 방향
        // Force : 속도
        //** Update 함수는 프레임마다 호출 되기 때문에 AddForce 함수를 Update함수에서 호출하게되면
        //** 매 프레임 마다 힘을 가하게 되므로 속도가 가중됨.
    }
    // 부딪침 확인
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collision Other)
    {
        Debug.Log("OnTriggerEnter");
    }

}
