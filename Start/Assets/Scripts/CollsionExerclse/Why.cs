using System.Collections;
using System.Collections.Generic;
using UnityEngine;


[RequireComponent(typeof(Rigidbody))] //���۳�Ʈ�� ������ٵ� ��� ������ �žƳִ°�

public class Why : MonoBehaviour
{
    [SerializeField] private float Force;
    //private Vector3 TargetPoint;
    //[SerializeField] private GameObject TargetPoint;

    private Rigidbody Rigid;

    // public GameObject Target;

    // ������ ���
    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
        //TargetPoint = GameObject.Find("TagetPoint");

    } //Rigidbodey = ��������

    // �̴ϼȶ����� ���
    void Start()
    {
        Rigid.useGravity = false; //��ũ��Ʈ�� ���۳�Ʈ �޾ƿͼ� �ϴ°�
        //TargetPoint.transform.position = this.transform.position;


         Force = 2000.0f;

        //** ���� ���Ͽ� �̵���Ŵ.
        Rigid.useGravity = false;

        // ����
        Rigid.AddForce(Vector3.forward * Force);
        // ���� �ٶ󺸴� ��������
        //Rigid.AddForce(Vector3.Trasnsforward * Force);

        // forward : �� ����
        // Force : �ӵ�
        //** Update �Լ��� �����Ӹ��� ȣ�� �Ǳ� ������ AddForce �Լ��� Update�Լ����� ȣ���ϰԵǸ�
        //** �� ������ ���� ���� ���ϰ� �ǹǷ� �ӵ��� ���ߵ�.
    }
    // �ε�ħ Ȯ��
    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("OnCollisionEnter");
    }

    private void OnTriggerEnter(Collision Other)
    {
        Debug.Log("OnTriggerEnter");
    }

}
