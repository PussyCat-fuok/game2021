using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class gimmickMana : MonoBehaviour
{
    public GameObject Call_Sign;
    public GameObject Who;//人
    public GameObject Signal;

    // Start is called before the first frame update
    void Start()
    {
        Signal = GameObject.Find("signal");//信号を取得
    }

    // Update is called once per frame
    void Update()
    {

    }

    //ここで操作を纏めたいのですわ
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
