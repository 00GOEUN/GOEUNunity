using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    private void Start()
    {
        StartCoroutine("MyCoroutine");
    }

    IEnumerator MyCoroutine()
    {
        Debug.Log("1");
        yield return new WaitForSeconds(1.0f); // �̰����� 1�ʸ� ��ٷȴٰ� ���ķ� �Ѿ

        Debug.Log("2");
        yield return new WaitForSeconds(1.0f);

        Debug.Log("3");
        yield return new WaitForSeconds(1.0f);

        Debug.Log("4");
    }
}
