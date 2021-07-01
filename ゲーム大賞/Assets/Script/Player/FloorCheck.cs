using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FloorCheck : MonoBehaviour
{
    private string graundTag = "Floor";
    private bool isGround = true;
    public bool isGroundEnter, isGroundStay, isGroundExit;


    public bool IsGround()
    {
        if (isGroundStay || isGroundEnter)
        {
            isGround = true;
        }
        else if (isGroundExit)
        {
            isGround = false;
        }
        isGroundStay = false;
        isGroundEnter = false;
        isGroundExit = false;

        return isGround;
    }

    void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == graundTag)
        {
            //Debug.Log("�n�ʂɓ�������");
            isGroundEnter = true;
        }
    }

    void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.gameObject.tag == graundTag)
        {
            //Debug.Log("�n�ʂɓ������Ă�");
            isGroundStay = true;
        }
    }

    void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.gameObject.tag == graundTag)
        {
            //Debug.Log("�n�ʂ��甲���o����");
            isGroundExit = true;
        }
    }
}
