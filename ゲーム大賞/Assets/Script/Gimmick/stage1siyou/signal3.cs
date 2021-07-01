using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class signal3 : MonoBehaviour
{
    public GameObject who;
    GameObject havescript1;//�ʂ�sc����֐����Ă�
    GameObject havescript2;
    public GameObject sigUI;
    public AudioClip BGM_Gim;

    bool touch = false;

    GameObject HanC;
    Hantei_C SignalBox;
    public float seconds;//�������N�[���^�C��

    // Start is called before the first frame update
    void Start()
    {
        HanC = GameObject.Find("Hantei_Roll");
        SignalBox = HanC.GetComponent<Hantei_C>();
        havescript1 = GameObject.Find("redAN");
        havescript2 = GameObject.Find("greenAN");
        havescript1.GetComponent<RedAn>().AnotherColorChange();//�ԃI��
        havescript2.GetComponent<GreenAn>().AnotherNoColorChange2P();//�΃I�t
    }

    // Update is called once per frame
    void Update()
    {
        if (touch)
        {
            seconds += Time.deltaTime;
            ChangeSignal();
        }
    }

    void OnTriggerStay2D(Collider2D col)
    {
        touch = true;
        if (col.gameObject.name == "human_1")
        {
            sigUI.GetComponent<gimisig_UI>().after2GimmickUI();
        }
        Debug.Log("Roll�̃V�O�i���͈͓̔����Ă�");
    }

    void OnTriggerExit2D(Collider2D col)
    {
        sigUI.GetComponent<gimisig_UI>().before2GimmickUI();
        touch = false;
    }

    void ChangeSignal()
    {
        if (who.gameObject.activeInHierarchy)
        {

            //Debug.Log("�l���̈�ɓ����Ă�");
            if (Input.GetKey(KeyCode.K))
            {
                if (seconds >= 0.25)
                {
                    SignalBox.changeFlag();

                    if (SignalBox.getFlag())
                    {

                        havescript2.GetComponent<GreenAn>().AnotherColorChange2P();//�΃I��
                        havescript1.GetComponent<RedAn>().AnotherNoColorChange();//�ԃI�t
                        SE.instance.PlaySE(BGM_Gim);
                        seconds = 0;

                    }


                    else if (!SignalBox.getFlag())
                    {
                        havescript1.GetComponent<RedAn>().AnotherColorChange();//�ԃI��
                        havescript2.GetComponent<GreenAn>().AnotherNoColorChange2P();//�΃I�t
                        SE.instance.PlaySE(BGM_Gim);
                        seconds = 0;
                    }
                }
            }

        }
    }
}