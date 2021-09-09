using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class ButtonQuickSlot : MonoBehaviour, IPointerDownHandler, IPointerUpHandler
{
    // 버튼 누르는지 확인
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

    // 버튼을 누를때
    public void OnPointerDown(PointerEventData eventData)
    {
        ButtonDown = true;
        StartCoroutine("ButtonUpdate");
        //Count = 0;
        //Debug.Log("Down");
    }

    // 버튼에서 손을 땔때
    public void OnPointerUp(PointerEventData eventData)
    {
        if (!PopupCheck)
            Debug.Log("Skill");

        ButtonDown = false;
        PopupCheck = false;

        //Debug.Log("Skill");


    }

    // 버튼 클릭
    // public void Skill_1()
    // {
    //     Debug.Log(Skill);
    // }
    //
}
