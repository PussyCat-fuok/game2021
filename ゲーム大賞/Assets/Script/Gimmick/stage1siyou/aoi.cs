using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class aoi : MonoBehaviour
{
    public Texture texture;
    public Texture texture2;
    GameObject HanB;
    Hantei_B WallBox_B;

    bool switchBox;
    // Start is called before the first frame update
    void Start()
    {
        HanB = GameObject.Find("Hantei_New"); //Unity�������I�u�W�F�N�g�̖��O����擾���ĕϐ��Ɋi�[����
        WallBox_B = HanB.GetComponent<Hantei_B>();
    }

    // Update is called once per frame
    void Update()
    {

        if (!WallBox_B.getFlag())
        {
            GetComponent<Renderer>().material.mainTexture = texture2;
            GetComponent<Renderer>().material.color = Color.white;
            GetComponent<BoxCollider2D>().enabled = true;

            //Debug.Log("�Ǐ����I��");
        }
        else if (WallBox_B.getFlag())
        {
            GetComponent<Renderer>().material.mainTexture = texture;
            GetComponent<Renderer>().material.color = Color.white;
            GetComponent<BoxCollider2D>().enabled = false;
            //Debug.Log("�Ǐ����I�t");
        }
    }
}
