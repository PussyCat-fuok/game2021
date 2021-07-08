using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Beast2D : MonoBehaviour
{
    [SerializeField] Rigidbody2D rb;
    [SerializeField] float Speed;
    [SerializeField] float JSpeed;
    [SerializeField] float Glider;
    [SerializeField] float AirAdjustmentRate;
    [SerializeField] float GliderSpeedRate;
    [SerializeField] FloorCheck Floor;
    public AudioClip jumpSE;
    public AudioClip kakkuuSE;
    private float speed;
    //private float gravity;
    [SerializeField] private bool isFloor;

    private Animator anim = null;
    private GameObject child;


    //Start is called before the first frame update
    void Start()
    {
        anim = GetComponent<Animator>();
    }


    void Update()
    {
        //if (child.GetComponent<FloorCheck>().IsGround())
        //{
        //    isFloor = true;
        //    anim.SetBool("isJamp", false);
        //    anim.SetBool("isFry", false);
        //}
        //else
        //{
        //    isFloor = false;
        //}

        isFloor = Floor.IsGround();

        //�v���C���[���n�ʂƐڐG���Ă鎞=========================================================================
        if (isFloor)
        {
            anim.SetBool("isJamp", false);
            anim.SetBool("isFry", false);
            Vector3 scale = transform.localScale;

            //�ڐG������Ԃ�space�L�[�������ꂽ�Ƃ��W�����v--------------------------------
            if (Input.GetKeyDown("space"))
            {
                Vector2 force = new Vector3(0.0f, JSpeed);     // �͂�ݒ�
                rb.AddForce(force, (ForceMode2D)ForceMode.Impulse);// �͂�������
                SE.instance.PlaySE(jumpSE);
                //Debug.Log("����!");

                anim.SetBool("isJamp", true);
                isFloor = false;

            }



            if (Input.GetKey(KeyCode.D))
            {
                speed = 1;
                anim.SetBool("isRun", true);
                scale.x = 80;

            }
            else if (Input.GetKey(KeyCode.A))
            {
                speed = -1;
                anim.SetBool("isRun", true);
                scale.x = -80;

            }
            else
            {
                speed = 0.0f;
                anim.SetBool("isRun", false);
            }

            rb.velocity = new Vector2(Speed * speed, rb.velocity.y);
            transform.localScale = scale;
            //-----------------------------------------------------------------------------
        }
        //==========================================================================================================



        //�v���C���[���󒆂ɂ���Ƃ�================================================================================
        if (!isFloor)
        {
            Vector3 scale = transform.localScale;

            //----------------------------------------------------------------------------------

            //E�L�[�������Ă�Ԃ�������---------------------------------------------------------
            if (Input.GetKey(KeyCode.K))
            {
                SE.instance.PlaySE(kakkuuSE);
                anim.SetBool("isFry", true);

                // gravity = -1.0f;  //�l��������Ώd���Ȃ�
               // rb.velocity = new Vector2(rb.velocity.x, -Glider);

                //�󒆂ł̃v���C���[�ړ�-----------------------------------------------------------
                if (Input.GetKey(KeyCode.D))
                {
                    speed = 1;
                    scale.x = 80;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    speed = -1;
                    scale.x = -80;
                }
                else
                {
                    speed = 0.0f;
                }

                rb.velocity = new Vector3(Speed * speed * GliderSpeedRate, -Glider);
            }
            else
            {
                anim.SetBool("isFry", false);

                if (Input.GetKey(KeyCode.D))
                {
                    speed = 1;
                }
                else if (Input.GetKey(KeyCode.A))
                {
                    speed = -1;
                }
                else
                {
                    speed = 0.0f;
                }


                rb.velocity = new Vector3(rb.velocity.x + (speed*AirAdjustmentRate), rb.velocity.y);
              
            }


            transform.localScale = scale;

            //----------------------------------------------------------------------------------
        }
        //============================================================================================================
    }
}

