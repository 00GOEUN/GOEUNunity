using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnEnable()
    {
        // �ʱ�ȭ

        // ���� �Լ� Random.Range( Min, Max)
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        // ���̶�Ű �信 �߰��� EnemyList�� �� ���� ������Ʈ�� �θ�� ���� : ��������
        this.transform.parent = GameObject.Find("EnablsList").transform;
    }

    // �浹 ���� ��
    private void OnTriggerEnter(Collider other)
    {
        // t(�ð�) �Ŀ� Obj(������Ʈ) ���� : Destroy(Object Obj, [DefaultValue("0.0f")]float t) ; 
        // ������Ʈ ���� : Destroy(this.GameObject);
        // ��ũ��Ʈ ���� : Destroy(this);
        // �� ��ũ��Ʈ�� ����ϴ� ���� ������Ʈ ����
        Destroy(this.gameObject);
    }

    //
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // �� ��ũ��Ʈ�� ����ϴ� ���� ������Ʈ ����
    //    Destroy(this.gameObject);
    //}
}
