using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonQuickSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // ��ư �������� Ȯ��
    private bool ButtonDown = false;
    private bool PopupCheck = false;

    private int Count = 0;
    //public string Skill;

    private void Start()
    {
        //Skill = "zzz";

        ButtonDown = false;
        PopupCheck = false;

        //Count = 0;
    }

    IEnumerator ButtonUpdate()
    {
        yield return new WaitForSeconds(0.5f);

        if (ButtonDown)
        {
            PopupCheck = true;
            StartCoroutine("PopupUpdate");
        }
    }

    IEnumerator PopupUpdate()
    {
        while (true)
        {
            if (PopupCheck)
            {
                //Debug.Log("PopupCheck" + Count++);
                yield return new WaitForSeconds(0.002f);
            }
            else
                break;
        }
    }

    // ��ư�� ������
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonDown = true;
        StartCoroutine("ButtonUpdate");
        //Count = 0;
        //Debug.Log("Down");
    }

    // ��ư���� ���� ����
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!PopupCheck)
            Debug.Log("Skill");

        ButtonDown = false;
        PopupCheck = false;

        //Debug.Log("Skill");


    }

    // ��ư Ŭ��
    // public void Skill_1()
    // {
    //     Debug.Log(Skill);
    // }
    //
}
