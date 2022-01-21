using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*���E�̈ړ��A�̗́A���ɓ�����������SE*/

    [Header("���������������̌��ʉ�")]
    public AudioClip HitKatana;

    //���̃v���n�u���擾����
    public GameObject KP;

    //�Q�[���f�B���N�^�[�̎擾
    public GameObject gd;

    //
    public GameObject tm;

    //�����Ŏg���Q�[���I�[�o�[��ʂ��o�����ǂ����̔���
    private bool PC_SAGO;

    //
    private bool PC_SAPC;

    //�����Ŏg���Q�[���N���A��ʂ��o�����ǂ����̔���
    private bool PC_SAGC;

    [Header("���ʉ��̉��ʒ���")]
    public float volume;

    private int PC_KA;

    [Header("�v���C���[�̍ő��HP")]
    public int P_MaxHP = 10;

    //[NonSerialized]Unity��ɏo�������Ȃ�public
    [Header("�v���C���[�̌��݂�HP")]
    public int P_NowHP;

    [Header("���b����������")]
    [SerializeField]
    private float moveSpeed = 1.0f;

    [Header("��ʍ��[��X���W")]
    [SerializeField]
    private float screenLeft;

    [Header("��ʉE�[��X���W")]
    [SerializeField]
    private float screenRight;

    //�����Ŏg���������Ԃ��I��������ǂ����̊� /*true�Ȃ琧�����Ԃ�0�Afalse�Ȃ琧�����Ԃ͎c���Ă�*/
    private bool PC_TE;

    private float Horizontal;

    Rigidbody2D rb;

    /*Rigidbody2D�̒��ɂ���Constraints��Freeze�ł��̓������S���ł���*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //���������ď�����
        PC_TE = false;
    }

    void Update()
    {
        //�Q�[���I�[�o�[��ʂ��o�����ǂ���
        PC_SAGO = gd.GetComponent<GameDirector>().SAGO;

        //�p�[�t�F�N�g�N���A��ʂ��o�����ǂ���
        PC_SAPC = gd.GetComponent<GameDirector>().SAPC;

        //�Q�[���N���A��ʂ��o�����ǂ���
        PC_SAGC = gd.GetComponent<GameDirector>().SAGC;

        //���̍U���͂��擾
        PC_KA = KP.GetComponent<EnemyController>().katanaAttack;

        //�������Ԃ��I��������ǂ����𔻒肷��
        PC_TE = tm.GetComponent<Timer>().TE;

        //������������-1�A�E����������1�A�����ĂȂ��Ƃ���0
        Horizontal = Input.GetAxis("Horizontal_P");

        //�Q�[���I�[�o�[��ʂ��o�Ă��Ȃ��ăQ�[���N���A��ʂ��o�Ă��Ȃ��Ƃ��ɓ����� /*�ǂ�������ł��\������Ă����瓮���Ȃ��Ȃ�*/
        if (PC_SAGO == false && PC_SAGC == false)
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
            //�ړ��ʂ͓��������Ɖ��ړ��̕������|�������
            float MovePower = moveSpeed * Horizontal;

            //X�̈ړ��ʂ�movepower�AY�͍��̍��W�̂܂�(����͓����Ȃ�)
            rb.velocity = new Vector2(MovePower,0);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //�������Ԃ��c���Ă��ē��ɓ���������
        if (other.gameObject.tag == "katana" && PC_TE == false)
        {
            Debug.Log("���Ă��I");

            //�v���C���[�̗̑͂����炷
            P_NowHP -= PC_KA;
            
            //Vector3�̌��̓��C���J�����̂�����Ɖ��̈ʒu
            AudioSource.PlayClipAtPoint(HitKatana,new Vector2(0,-4));
        }
    }
}
