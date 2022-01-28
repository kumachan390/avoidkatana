using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /*�������Ԃ̏���*/
    /*�Q�[���I�[�o�[��ʁA�Q�[���N���A��ʂ��\�����ꂽ�玞�Ԃ��~�߂�*/

    [Header("�Q�[���f�B�N�^�[�̎擾")]
    public GameObject TM_gd;

    [Header("�e�L�X�g�̎擾")]
    [SerializeField]
    private Text timertext;

    [Header("��������")]
    [SerializeField]
    private float countMax = 0f;

    //���݂̐������Ԃ̎c��
    [System.NonSerialized]
    public float countTime;

    //�������Ԃ��I�������true�A�������Ԃ��I���܂ł�false
    [System.NonSerialized]
    public bool timeEnd = false;

    //�ꎞ��~�̊Ǘ�bool
    private bool TM_F = false;

    //�����Ŏg���Q�[���I�[�o�[��ʂ��o�����ǂ����̔���
    private bool TM_SAGO;

    //�����Ŏg���p�[�t�F�N�g�N���A��ʂ��o�����ǂ����̔���
    private bool TM_SAPC;

    //�����Ŏg���Q�[���N���A��ʂ��o�����ǂ����̔���
    private bool TM_SAGC;

    private void Start()
    {
        TM_F = false;
        timeEnd = false;

        //�������Ԃ̎c��𐧌����ԂƓ����l�ɂ���(�������Ԃ̏�����)
        countTime = countMax;
    }

    private void Update()
    {
        TM_SAGO = TM_gd.GetComponent<GameDirector>().SAGO;
        TM_SAPC = TM_gd.GetComponent<GameDirector>().SAPC;
        TM_SAGC = TM_gd.GetComponent<GameDirector>().SAGC;

        TM_F = TM_gd.GetComponent<GameDirector>().freeze;

        //�������Ԃ��I�������t���O���グ��
        if (countTime <= 0)
        {
            timeEnd = true;
        }
    }

    void FixedUpdate()//���ԂɌ덷�����܂�Ȃ��悤��
    {
        //�Q�[���I�[�o�[��ʂ��o�Ă��Ȃ��ăQ�[���N���A��ʂ��o�Ă��Ȃ��Ƃ��Ƀ^�C�}�[�̎��Ԃ��J�E���g�����
        if (TM_SAGO == false && TM_SAPC == false && TM_SAGC == false && TM_F == false)
        {
            //�������Ԃ�0�ȏ�̎��^�C�}�[�̃J�E���g�����炵������
            if (countTime > 0)
            {
                countTime -= Time.deltaTime;
            }
            //�����_2�ȉ��܂ŕ\������
            timertext.text = countTime.ToString("F2");
        }
        
    }
}
