using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*���E�̈ړ��A�̗́A���ɓ�����������SE*/

    [Header("���������������̌��ʉ�")]
    public AudioClip HitKatana;

    [Header("�藠���������������̌��ʉ�")]
    public AudioClip HitSyuriken;

    //���̃v���n�u���擾����
    public GameObject kp;

    //�藠���̃v���n�u���擾����
    public GameObject sp;

    //�Q�[���f�B���N�^�[�̎擾
    public GameObject gd;

    [Header("�v���C���[�̍ő��HP")]
    public int P_MaxHP = 10;

    //[NonSerialized]Unity��ɏo�������Ȃ�public
    [Header("�v���C���[�̌��݂�HP")]
    public int P_NowHP;

    [Header("���b����������")]
    [SerializeField]
    private float moveSpeed;

    [Header("������蓮��������")]
    [SerializeField]
    private float sneakmoveSpeed;

    [Header("��ʍ��[��X���W")]
    [SerializeField]
    private float screenLeft = 0;

    [Header("��ʉE�[��X���W")]
    [SerializeField]
    private float screenRight = 0;

    //�����Ŏg���Q�[���I�[�o�[��ʂ��o�����ǂ����̔���
    private bool PC_SAGO;

    //�����Ŏg���p�[�t�F�N�g�N���A��ʂ��o�����ǂ����̔���
    private bool PC_SAPC;

    //�����Ŏg���Q�[���N���A��ʂ��o�����ǂ����̔���
    private bool PC_SAGC;

    //���̍U����
    private int PC_KA;

    //�藠���̍U����
    private int PC_SA;

    private float Horizontal;

    Rigidbody2D rb;

    /*Rigidbody2D�̒��ɂ���Constraints��Freeze�ł��̓������S���ł���*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //���̍U���͂��擾
        PC_KA = kp.GetComponent<KatanaController>().katanaAttack;

        //�藠���̍U���͂��擾
        PC_SA = sp.GetComponent<SyurikenController>().syurikenAttack;
    }

    void Update()
    {
        //�Q�[���I�[�o�[��ʂ��o�����ǂ���
        PC_SAGO = gd.GetComponent<GameDirector>().SAGO;

        //�p�[�t�F�N�g�N���A��ʂ��o�����ǂ���
        PC_SAPC = gd.GetComponent<GameDirector>().SAPC;

        //�Q�[���N���A��ʂ��o�����ǂ���
        PC_SAGC = gd.GetComponent<GameDirector>().SAGC;

        //������������-1�A�E����������1�A�����ĂȂ��Ƃ���0
        Horizontal = Input.GetAxis("Horizontal_P");

        //�Q�[���I�[�o�[��ʂ��o�Ă��Ȃ��ăQ�[���N���A��ʂ��o�Ă��Ȃ��Ƃ��ɓ����� /*�ǂ�������ł��\������Ă����瓮���Ȃ��Ȃ�*/
        if (PC_SAGO == false && PC_SAPC == false && PC_SAGC == false)
        {
            Vector3 pos = rb.transform.position;

            //Mathf.Clamp(float1,float2,float3)�ŉ�ʊO�ɏo���Ȃ��悤�ɐݒ�ł��� float1�ɂ̓v���C���[�̍��WX�Afloat2�ɂ͉�ʍ��[�̍��WX�Afloat3�ɂ͉�ʉE�[�̍��WX
            pos.x = Mathf.Clamp(pos.x, screenLeft, screenRight);
            rb.transform.position = pos;
        }
    }

    private void FixedUpdate()
    {
            Move();
    }

    private void Move()
    {
        //����������o�O�h�~ /*���͂��V���b�g�A�E�g*/
        if (PC_SAGO == false && PC_SAPC == false && PC_SAGC == false)
        {
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveSpeed = sneakmoveSpeed;
            }
            else
            {
                moveSpeed = 10;
            }

            //�ړ��ʂ͓��������Ɖ��ړ��̕������|�������
            float MovePower = moveSpeed * Horizontal;

            //X�̈ړ��ʂ�movepower�AY�͍��̍��W�̂܂�(����͓����Ȃ�)
            rb.velocity = new Vector2(MovePower,0);
        }
        else
        {
            //�Q�[���̌��ʂ��o����v���C���[�𓮂��Ȃ�����
            rb.velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PC_SAGO == false && PC_SAPC == false && PC_SAGC ==false)
        {
            //�������Ԃ��c���Ă��ē��ɓ���������
            if (other.gameObject.tag == "katana")
            {
                Debug.Log("���Ă��I");

                //�v���C���[�̗̑͂����炷
                P_NowHP -= PC_KA;

                //Vector3�̌��̓��C���J�����̂�����Ɖ��̈ʒu
                AudioSource.PlayClipAtPoint(HitKatana, new Vector2(0, 0));
            }

            if(other.gameObject.tag == "syuriken")
            {
                Debug.Log("�����Ă��I�I");

                P_NowHP -= PC_SA;

                AudioSource.PlayClipAtPoint(HitSyuriken, new Vector2(0, 0));
            }
        }
    }
}
