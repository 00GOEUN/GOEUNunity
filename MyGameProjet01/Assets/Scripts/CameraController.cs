using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class CameraController : MonoBehaviour
{
    // ** ������ ��ǥ ��ü
    private GameObject Target;

    // ** �󸶸�ŭ�� ��ġ���� ������ ������ ����
    private Vector3 Offset;

    // ** ȭ�� Ȯ��/��� �Ÿ�
    private float ZoomDistance;

    // ** ����ī�޶� �޾ƿ�
    private Camera MainCamera;


    // ** ī�޶� ��鸱 �ð�
    private float ShakeTime;


    // ** [const]

    // ** ī�޶� �� �ּҰ�
    private const float Minimum = 40.0F;

    // ** ī�޶� �� �ִ밪
    private const float Maximum = 65.0F;


    private void Awake()
    {
        // ** ��ǥ�� ����
        Target = GameObject.Find("Player");
        
        // ** ���� ī�޶� �޾ƿ�
        MainCamera = Camera.main;
    }

    private void Start()
    {
        // ** ����ٴ� ��ġ�� �����Ѵ�.
        Offset = new Vector3(0.0f, 9f, -6.0f);

        // ** ���� ������Ʈ�� ��ǥ���� ���� �������� �ͼ�
        //this.transform.parent = Target.transform;

        // ** ī�޶��� ��ġ�� ���ʿ� �ѹ� ������ ��ҷ� ����
        this.transform.position = new Vector3(
            Offset.x + Target.transform.position.x,
            Offset.y + Target.transform.position.y,
            Offset.z + Target.transform.position.z);

        // ** ���ʿ� �ѹ� �÷��̾ �ٶ󺸰� ����.
        this.transform.rotation = Quaternion.LookRotation( 
            (Target.transform.position - this.transform.position).normalized );

        // ** �ʱ� �Ÿ��� 0 ���� ����
        ZoomDistance = 50.0f;

        // ** ī�޶� ��鸱 �ð�
        ShakeTime = 0.08f;
    }

    void Update()
    {
        // ** ���콺�� ��ũ�� ���� �޾ƿ�.
        float MouseScroll = Input.GetAxis("Mouse ScrollWheel") * -1;

        // ** ī�޶�� Ÿ�ٰ��� �Ÿ��� �޾ƿ�
        ZoomDistance += (MouseScroll * 15);

        // ** �Ÿ� �ּҰ� ����.
        if (ZoomDistance < Minimum)
            ZoomDistance = Minimum;

        // ** �Ÿ� �ִ밪 ����.
        if (ZoomDistance > Maximum)
            ZoomDistance = Maximum;

        // ** �������� �̵� : ī�޶�� Ÿ�ٰ��� �Ÿ��� ���� 
        MainCamera.fieldOfView = Mathf.Lerp(
            MainCamera.fieldOfView,
            ZoomDistance, Time.deltaTime);


        if (Input.GetKeyDown(KeyCode.X))
            StartCoroutine("ShakeCamera");


        FolloingCamera();
    }


    void FolloingCamera()
    {
        // ** ī�޶� ��ǥ�������� �̵��ϴ� �ð��� ����.
        // ** Vector3.Lerp(������, ������, �ð�)
        Vector3 SmoothFolloingPosition = Vector3.Lerp(
            this.transform.position, Target.transform.position + Offset, Time.deltaTime * 5.0f);

        // ** ������ ���õ� ��ġ�� ����.d
        this.transform.position = SmoothFolloingPosition;
    }


    IEnumerator ShakeCamera()
    {
        // ** �Լ��� ���۵Ǹ� ���� ó������ ī�޶� ��ǥ�� �޾ƿ�.
        Vector3 OldPosition = this.transform.position;

        while (true)
        {
            // ** 0.005f �� ���� ����
            yield return new WaitForSeconds(0.005f);

            // ** ī�޶� ��鸱 �ݰ� ����
            this.transform.position = this.transform.position +
                new Vector3(
                    Random.Range(-0.15f, 0.15f),
                    Random.Range(-0.15f, 0.15f), 
                    Random.Range(-0.15f, 0.15f));

            ShakeTime -= Time.deltaTime;

            if (ShakeTime < 0)
                break;
        }

        // ** �޾ƿ� ��ǥ��(������ �ִ� ��ġ��) �ǵ���.
        MainCamera.transform.position = OldPosition;

        // ** ī�޶� ��鸱 �ð�
        ShakeTime = 0.08f;
    }
}
