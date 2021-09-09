using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarContriller : MonoBehaviour
{
    //// ** ���� �浹����
    //[SerializeField] private GameObject FrontCollider;
    //
    //// ** ���� �浹����
    //[SerializeField] private GameObject RightCollider;
    //
    //// ** ���� �浹����
    //[SerializeField] private GameObject LeftCollider;

    private Ray[] rays = new Ray[3];


    private void Awake()
    {
        for (int i = 0; i<3; ++i)
        {
            rays[i] = new Ray();
        }

        //FrontCollider = GameObject.Find("FrontCollider");
        //RightCollider = GameObject.Find("RightCollider");
        //LeftCollider = GameObject.Find("LeftCollider");
    }

    private void Start()
    {
        
    }

    IEnumerator GetDirection()
    {
        while(true)
        {
            for (int i = 0; i < 3; ++i)
                rays[i].origin = transform.position;

            // ���� ����
            rays[0].direction = transform.forward;
            // ����
            rays[1].direction = transform.forward - transform.right;
            // ����
            rays[2].direction = transform.forward + transform.right;

            for (int i = 0; i < 3; ++i)
                Debug.DrawRay(rays[i].origin, rays[i].direction * 5.0f, Color.white);
        }
    }


    private void Update()
   {
        for (int i = 0; i < 3; ++i)
            rays[i].origin = transform.position;

        // ���� ����
        rays[0].direction = transform.forward;
        // ����
        rays[1].direction = transform.forward - transform.right;
        // ����
        rays[2].direction = transform.forward + transform.right;

        for (int i = 0; i < 3; ++i)
            Debug.DrawRay(rays[i].origin, rays[i].direction * 5.0f, Color.white);

    }

    private void OnDrawGizmos()
    {
        for(int i = 0; i < 3; ++i)
            rays[i].origin = transform.position;

        // ���� ����
        rays[0].direction = transform.forward;
        // ����
        rays[1].direction = transform.forward - transform.right;
        // ����
        rays[2].direction = transform.forward + transform.right;

        for (int i = 0; i <3;  ++i)
            Debug.DrawRay(rays[i].origin, rays[i].direction * 5.0f, Color.white);
    }
}
