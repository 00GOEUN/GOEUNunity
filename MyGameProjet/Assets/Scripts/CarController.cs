using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarController : MonoBehaviour
{

    // ���͸� ������ ������� �浹ü ������ �����
    // ����
    [SerializeField] private GameObject FrontCollider;
    // ����
    [SerializeField] private GameObject RightCollider;
    // ����
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
        //  ��� ,������, ��ŭ
        //if (Physics.Raycast(FrontCollider.transform.position, FrontCollider.transform.forward, 100.0f))
        //{
        //    Debug.DrawLine(FrontCollider.transform.position, FrontCollider.transform.forward, Color.blue);
        //}



    }
}
