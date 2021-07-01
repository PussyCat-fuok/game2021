using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class box1 : MonoBehaviour
{
    public GameObject who;//�l��ǉ�
    //public GameObject mat;//�ǂ̃{�b�N�X(��)���w�肷�邩
    Rigidbody2D rb2d;
    public GameObject boxUI;//BoxUI��ǉ�
    public float XPosSeconds;//�����^�p:XPos�̃t���[�Y��x�点��B

    // Start is called before the first frame update
    void Start()
    {
        Rigidbody2D rd2d = GetComponent<Rigidbody2D>();

        this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX
            | RigidbodyConstraints2D.FreezeRotation;
    }

    // Update is called once per frame
    void Update()
    {
        //�����Ȃ�
        //this.OnCollisionStay2D();
    }

    public void OnCollisionStay2D(Collision2D col)
    {
        if (who.gameObject.activeInHierarchy)
        {
            if (col.gameObject.name == "Player")
            {
                boxUI.GetComponent<gimibox_UI>().afterGimmickUI();
                if (Input.GetKey(KeyCode.K))
                {
                    this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                }
            }
        }
        //�l�ȊO���G�ꂽ���A�����̂�Pos,Rot���~�߂܂���
        else
        {
            this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePosition
            | RigidbodyConstraints2D.FreezeRotation;

            boxUI.GetComponent<gimibox_UI>().beforeGimmickUI();
        }
    }

    public void OnCollisionExit2D(Collision2D col)
    {
        //�r����G��֎~�ł������܂���
        if (who.gameObject.activeInHierarchy)
        {
            //Debug.Log("�����炨����ɂȂ�ꂽ�̂ł���!");
            XPosSeconds += Time.deltaTime;

            if (XPosSeconds <= 0.9)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezeRotation;
                XPosSeconds++;
            }
            else if (XPosSeconds >= 1.0)
            {
                this.GetComponent<Rigidbody2D>().constraints = RigidbodyConstraints2D.FreezePositionX
                | RigidbodyConstraints2D.FreezeRotation;
                XPosSeconds = 0;
            }
        }

    }
}
