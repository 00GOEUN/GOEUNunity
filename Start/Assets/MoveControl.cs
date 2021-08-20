using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Rigidbody))] //���۳�Ʈ�� ������ٵ� ��� ������ �žƳִ°�
public class MoveControl : MonoBehaviour
{
    [SerializeField] private float Speed;
    // [SerializeField] private float Force;
    private bool Move;
    private Vector3 TargetPoint;
    private Vector3 Step;

    private Rigidbody Rigid;

    // ������ ���
    void Awake()
    {
        Rigid = GetComponent<Rigidbody>();
    } //Rigidbodey = ��������

    // �̴ϼȶ����� ���
    void Start()
    {
        Rigid.useGravity = false; //��ũ��Ʈ�� ���۳�Ʈ �޾ƿͼ� �ϴ°�
        TargetPoint = this.transform.position;
        Step = new Vector3(0.0f, 0.0f);
        Speed = 15.0f;
       
        
        // Force = 2000.0f;

        //** ���� ���Ͽ� �̵���Ŵ.
        //Rigid.AddForce(Vector3.forward * Force);

        //** Update �Լ��� �����Ӹ��� ȣ�� �Ǳ� ������ AddForce �Լ��� Update�Լ����� ȣ���ϰԵǸ�
        //** �� ������ ���� ���� ���ϰ� �ǹǷ� �ӵ��� ���ߵ�.
    }

    // void Update()
    void FixedUpdate()
    {
        // this.transform.Translate
        // (vPosition * Time.deltaTime * Speed );
        // vPosition = Vector3.right

        //**���� ������Ʈ �������� �̵�. (����)
        //transform.Translate(Vector3.forward * Time.deltaTime * Speed);

        //** ���� ��ǥ �������� �̵� (����)
        //transform.Translate(Vector3.forward * Time.deltaTime, Space.World);

        //**��ü�� ���� �������� �̵�. (����)
        //transform.Translate(0, 0, Time.deltaTime);// Translate(x, y, z)

        //**��ü�� ���� �������� �̵�. (����)
        // transform.Translate(0, 0, Time.deltaTime, Space.World); //Translate(x, y, z, Space);

        //** ī�޶� �������� ��ü�� �������� �̵�.
        //transform.Translate(Vector3.forward * Time.deltaTime, Camera.main.transform);




        //** Ű �Է¿� ���� �̵����.
        /*
        float fHor = Input.GetAxis("Horizontal"); // �¿�
        float fVer = Input.GetAxis("Vertical"); // �� �Ʒ�

        transform.Translate(
            fHor * Time.deltaTime * Speed,
            0.0f,
            fVer * Time.deltaTime * Speed);// �յڷ� �����ϰŴϱ� z���� �־���
         */


        // ���콺 �Է� ���
        /*
        if(Input.GetMouseButtonDown(0))
        {
            Debug.Log("�� Ŭ��");
        }

        if(Input.GetMouseButtonDown(1))
        {
            Debug.Log("�� Ŭ��");
        }

        if(Input.GetMouseButtonDown(2))
        {
            Debug.Log("�� Ŭ��");
        }
         */
        
         if(Input.GetMouseButton(1))
        {

             if(this.transform.position.x > TargetPoint.x - 0.5f &&
                this.transform.position.x < TargetPoint.x + 0.5f && 
                this.transform.position.z > TargetPoint.z - 0.5f && 
                this.transform.position.z < TargetPoint.z + 0.5f) 
            {
                Move = false;

            }
            else
            {

                Move = true;

                Step = TargetPoint - this.transform.position;
                Step.Normalize();

                
            }

             if(Move == true)
            {
                this.transform.LookAt(Step);
                this.transform.position += Step;

                if (this.transform.position.x > TargetPoint.x - 0.5f &&
                this.transform.position.x < TargetPoint.x + 0.5f &&
                this.transform.position.z > TargetPoint.z - 0.5f &&
                this.transform.position.z < TargetPoint.z + 0.5f)
                {
                    Move = false;
                }

            }


            /*
            // ������ = ���콺 �����ͷ� ����
            // ȭ�鿡 �ִ� ���콺 ��ġ�κ��� Ray�� ���������� ������ �����
            Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);


            // Ray�� Ÿ�ٰ� �浹���� �� ��ȯ ���� �����ϴ� ��
            RaycastHit hit;

            // �޾ƿ��⸸ �Ҷ� out
            // �Է¸� �Ҷ� in
            // Infinity : ����
            // if(Physics.Raycast(Ray ���� ��ġ�� ����, �浹�� ������ ����, Mathf.Infity : ������))
            if(Physics.Raycast(ray, out hit, Mathf.Infinity)) // ray�� ��ġ�� �������κ��� RayPoint�� ���������� �߻��ϰ� �浹�� �Ͼ�� Hit�� ������ ������ 
            {
                if (hit.transform.tag == "Ground")
                {
                    // ray�� ��ġ������ hit�� ��ġ���� ���� �׸�
                    Debug.DrawLine(ray.origin, hit.point);
                    Debug.Log(hit.point);

                    //transform.position = new Vector3(hit.point.x, 1.0f, hit.point.z);
                    TargetPoint = hit.point;
             */
                

                /*
                //Vector3 Temp = ray.origin - hit.point;
                //Vector3.Normalize(Temp);
                Debug.DrawLine(ray.origin, Vector3.Normalize(Temp)*Mathf.Infinity);

                Temp.x *= 100;
                Temp.y *= 100;
                Temp.z *= 100;

                Debug.DrawLine(ray.origin, Temp, Color.green);

                
                // �浹�� ��ġ�� ���
                Debug.Log(hit.point);
                }
            }
                */
        }



    }
}