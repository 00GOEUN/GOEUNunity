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
        // 초기화

        // 난수 함수
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        // 하이라이키 뷰에 추가된 EnemtList의 빈 게임오브젝트를 부모로 셋팅 : 계층구조
        this.transform.parent = GameObject.Find("EnablsList").transform;

    }
    private void OnTriggerEnter(Collider other)
    {
        Destroy(this.gameObject);
    }
}

