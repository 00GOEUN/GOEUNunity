using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{

    private void OnEnable()
    {
        // 초기화

        // 난수 함수 Random.Range( Min, Max)
        this.transform.position = new Vector3(Random.Range(-25, 25), 0.0f, Random.Range(-25, 25));

        // 하이라키 뷰에 추가된 EnemyList의 빈 게임 오브젝트를 부모로 셋팅 : 계층구조
        this.transform.parent = GameObject.Find("EnablsList").transform;
    }

    // 충돌 했을 때
    private void OnTriggerEnter(Collider other)
    {
        // t(시간) 후에 Obj(오브젝트) 삭제 : Destroy(Object Obj, [DefaultValue("0.0f")]float t) ; 
        // 오브젝트 삭제 : Destroy(this.GameObject);
        // 스크립트 삭제 : Destroy(this);
        // 이 스크립트를 사용하는 게임 오브젝트 삭제
        Destroy(this.gameObject);
    }

    //
    //private void OnCollisionEnter(Collision collision)
    //{
    //    // 이 스크립트를 사용하는 게임 오브젝트 삭제
    //    Destroy(this.gameObject);
    //}
}
