using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public static Player instance = null;

    public GameObject human;
    public GameObject animal;
    public GameObject plant;

    //public float cool;

    public AudioClip deathSE;
    public AudioClip tennseiSE;

    [SerializeField] bool Hflag;
    [SerializeField] bool Aflag;
    [SerializeField] bool Pflag;

    private int DeathCount = 0;

    //private void Awake()
    //{
    //    if (instance == null)
    //    {
    //        instance = this;
    //        DontDestroyOnLoad(this.gameObject);
    //    }
    //    else
    //    {
    //        Destroy(this.gameObject);
    //    }
    //}

    // Start is called before the first frame update
    void Start()
    {
        if (Hflag)
        {
            Aflag = false;
            Pflag = false;
        }
        else if (Aflag)
        {
            Hflag = false;
            Pflag = false;

        }
        else// if (Pflag)
        {
            Hflag = false;
            Aflag = false;
        }
        //else
        //{
        //    Pflag = true;
        //    Hflag = false;
        //    Aflag = false;
        //}

        this.human.SetActive(Hflag);
        this.animal.SetActive(Aflag);
        this.plant.SetActive(Pflag);
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.O))
        {
            Debug.Log("��͎���");
            PlayerDeath();
        }

        //Q�L�[������
        if (Input.GetKeyDown(KeyCode.Q))
        {
            PlayerReincarnation();
        }

        CheckHuman();

        if(Hflag==false)
        {
            //Debug.Log("�U���[���h");
            //Debug.Break();
        }

        

        this.human.SetActive(Hflag);//�l����
        this.animal.SetActive(Aflag);//�����L��
        this.plant.SetActive(Pflag);//�A���L��
    }

    //�]������������������������������������������������������������������������������������������������
    void PlayerReincarnation()
    {
        Debug.Log("�����Ԃ���");

        SE.instance.PlaySE(tennseiSE);

        if (Hflag == true)
        {
            Hflag = false;
            Aflag = true;
        }
        else if (Aflag == true)
        {
            Aflag = false;
            Pflag = true;
        }
        else if (Pflag == true)
        {
            Pflag = false;
            Hflag = true;
        }

        DeathCount += 1;
    }
    //��������������������������������������������������������������������������������������������������

    //���񂾏�������������������������������������������������������������������������������������������
    void PlayerDeath()
    {
        Debug.Log("�]������");
        PlayerReincarnation();

        SE.instance.PlaySE(deathSE);
    }
    //��������������������������������������������������������������������������������������������������

    public int GetDeathCount()
    {
        return DeathCount;
    }

    public bool CheckHuman()
    {

        //Debug.Log(Hflag);
        //Debug.Log(Aflag);
        //Debug.Log(Pflag);
        if (Hflag)
        {
            //Debug.Log("�q�g�_���[");
            return true;
        }
        else if (Aflag)
        {
            //Debug.Log("�P���m�_���[");
            return false;
        }
        else
        {
            //Debug.Log("�A���ł�");
            return false;
        }
        //return false;
    }

}
