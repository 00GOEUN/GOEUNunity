using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    //private void OnCollisionEnter(Collision collision)
    //{
    //    Destroy(this.gameObject);
    //}


    private void OnEnable()
    {
        // �ʱ�ȭ

        // ���� �Լ�
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        // ���̶���Ű �信 �߰��� EnemtList�� �� ���ӿ�����Ʈ�� �θ�� ���� : ��������
        this.transform.parent = GameObject.Find("EnablsList").transform;

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

