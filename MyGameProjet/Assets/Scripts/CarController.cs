using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    // 백터만 가지고 있을경우 충돌체 감지가 어려움
    // 정면
    [SerializeField] private GameObject FrontCollider;
    // 우측
    [SerializeField] private GameObject RightCollider;
    // 좌측
    [SerializeField] private GameObject LeftCollider;

    private void Awake()
    {
        FrontCollider = GameObject.Find("FrontCollider");
        RightCollider = GameObject.Find("RightCollider");
        LeftCollider = GameObject.Find("LeftCollider");
    }

    void Update()
    {
        // Vector3.forward
        Debug.DrawLine(FrontCollider.transform.position, FrontCollider.transform.forward * 1000.0f, Color.blue);

        

        //RaycastHit Hit;
        //  어디에 ,방향은, 얼만큼
        //if (Physics.Raycast(FrontCollider.transform.position, FrontCollider.transform.forward, 100.0f))
        //{
        //    Debug.DrawLine(FrontCollider.transform.position, FrontCollider.transform.forward, Color.blue);
        //}



    }
}
