using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimmickMana : MonoBehaviour
{
    public GameObject Call_Sign;
    public GameObject Who;//�l
    public GameObject Signal;

    // Start is called before the first frame update
    void Start()
    {
        Signal = GameObject.Find("signal");//�M�����擾
    }

    // Update is called once per frame
    void Update()
    {

    }

    //�����ő����Z�߂����̂ł���
    void Script_Commander()
    {
        
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        
    }

    void OnCollisionStay2D(Collision2D col)
    {
        
    }

    void OnCollisionExit2D(Collision2D col)
    {

    }
}
