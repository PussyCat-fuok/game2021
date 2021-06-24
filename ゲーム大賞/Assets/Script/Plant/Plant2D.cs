using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Plant2D : MonoBehaviour
{
    [SerializeField] GameObject Seed;//��΂���

    //�ړ��Ɏg����
    private float power = 40.0f;
    private float lowPower = 1.0f;

    public GameObject Player;//�v���C���[
    public GameObject child;//plant�̎q�I�u�W�F�N�g��ݒ�

    private Rigidbody2D Prb2D;//�v���C���[�̃��L�b�h�{�f�B������
    private Vector2 Pvec = new Vector2(0, 0);//�ړ��̃x�N�g��
    private Vector2 PvecData = new Vector2(0, 0);//�ړ��x�N�g���ۑ��p

    private Vector2 movePosition;//�ړI�n
    private Vector2 playerPosition;//���ݒn
    private Vector2 addPower;//�K�v�ȗ́i�v�Z�p�j
    private float angle = 0;//�c�^�L�΂��̊p�x
 

    private int flag = 0;//�P�[�X�p

    private Animator animator;

    public AudioClip plantingSE;
    public AudioClip growupSE;
    public AudioClip moveSE;

    // Start is called before the first frame update
    void Start()
    {
        Prb2D = Player.GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        //�L�[���͔���
        if (Input.GetKey(KeyCode.W))
        {
            Pvec.y = 1.0f;
        }
        else
        {
            Pvec.y = 0.0f;
        }

        if (Input.GetKey(KeyCode.A))
        {
            Pvec.x = -1.0f;
        }
        else if (Input.GetKey(KeyCode.D))
        {
            Pvec.x = 1.0f;
        }
        else
        {
            Pvec.x = 0.0f;
        }

        if (Input.GetKeyDown(KeyCode.Space)&&flag==0)
        {
            if (Pvec.x != 0.0f || Pvec.y != 0.0f)
            {
                flag = 1;
                PvecData = Pvec;
            }
        }

        if (Input.GetKeyDown(KeyCode.K))
        {
            animator.SetBool("isPlanting", true);
            
            this.GetComponent<Planting>().Plant(Pvec.x, Pvec.y, Seed, Player.transform);//���΂�
            SE.instance.PlaySE(plantingSE);
        }
        else
        {
            animator.SetBool("isPlanting", false);
        }

        switch (flag)
        {
            case 0:
                break;

            case 1:
                
                //�p�x�ݒ�
                if (PvecData.x == 1.0f)
                {
                    angle = 90f;
                    if (PvecData.y == 1.0f)
                    {
                        angle = 45f;
                    }
                }
                else if (PvecData.x == -1.0f)
                {
                    angle = -90f;
                    if (PvecData.y == 1.0f)
                    {
                        angle = -45f;
                    }
                }

                //�c�^�L�΂�
                child.GetComponent<tuta>().Growup(angle);
                SE.instance.PlaySE(growupSE);

                if (child.GetComponent<tuta>().GetScale()> 0.25f)//�c�^���E
                {
                    flag = 2;
                }
                else if (child.GetComponent<tuta>().GetFlag() == 1)//�c�^�����߂�
                {
                    flag = 4;
                }
                else if (child.GetComponent<tuta>().GetFlag() == 2)//�c�^���I�u�W�F�N�g�ɂԂ���߂�
                {
                    flag = 2;
                }
                break;

            case 2:
                //�c�^�߂�
                child.GetComponent<tuta>().Growdown(angle);


                if(child.GetComponent<tuta>().GetScale() <= 0.003f)//�c�^���ʂ�
                {
                    flag = 3;
                }
                break;

            case 3:
                angle = 0.0f;//���ʂ�
                flag = 0;
                child.GetComponent<tuta>().GrowReset();
                break;

            case 4:
                //Plant�ړ�����
                playerPosition = Player.transform.position;
                movePosition = new Vector2(Player.transform.position.x + PvecData.x, Player.transform.position.y + PvecData.y);
                addPower.x = movePosition.x - playerPosition.x;
                addPower.y = movePosition.y - playerPosition.y;
                addPower = addPower.normalized;
                Prb2D.velocity = addPower * power;//���x�����߂�

                if (Vector2.Distance(playerPosition, movePosition) < 1.0)
                {
                    Prb2D.velocity = Prb2D.velocity * lowPower;//���x�����߂�
                }
                SE.instance.PlaySE(moveSE);
                flag = 2;
                break;
            default:
                break;
        }
    }
}
