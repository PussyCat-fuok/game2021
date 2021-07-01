using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimisig_UI : MonoBehaviour
{
    public Texture texture;
    public Texture texture2;

    bool texSwitch;

    // Start is called before the first frame update
    void Start()
    {
        texSwitch = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (texSwitch)
        {
            after2GimmickUI();
        }
        else if (!texSwitch)
        {
            before2GimmickUI();
        }
    }

    public void after2GimmickUI()
    {

        GetComponent<Renderer>().material.mainTexture = texture2;
        GetComponent<Renderer>().material.color = Color.white;
        texSwitch = true;

        Debug.Log("�V�O�i��UI�o�Ă��");
    }

    public void before2GimmickUI()
    {

        GetComponent<Renderer>().material.mainTexture = texture;
        GetComponent<Renderer>().material.color = Color.white;
        texSwitch = false;

        Debug.Log("�V�O�i��UI�o�ĂȂ���");
    }
}
