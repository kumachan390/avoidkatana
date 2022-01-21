using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    /*���𐶂ݏo���ꏊ�A�����̐ݒ�*/

    [Header("�Q�[���f�B���N�^�[�̎擾")]
    public GameObject gd;

    [Header("���̃v���n�u����")]
    public GameObject katanaprefab;

    //���̃X�|�[���ꏊ�̒l�P�[�X
    private float SpawnP;

    [Header("�X�|�[���͈͂̔��a")]
    [SerializeField]
    float SpawnMax = 5f;

    [Header("������ԍŏ��ɗ����Ă���b��(�����_����)")]
    public float NO1 = 1f;

    [Header("���������Ă���p�x(�����_����)")]
    public float repeatkatana = 0.5f;

    //�Q�[���N���A��ʂ��Q�[���I�[�o�[��ʂ��o�Ă���Ȃ瓁���~�点�Ȃ����߂�bool�l
    private bool EG_SAGO;
    private bool EG_SAGC;
    private bool EG_SAPC;

    //�^�C�}�[�ŃJ�E���g�����������Ԃ����[���锠
    private float time;

    void Start()
    {
                           /*��x�Ə����Ȃ�*/
        ////�������͏���̌Ăяo���܂ł̕b���A��O�����͎���܂ł̕b��
        //InvokeRepeating("GenArrow", NO1, repeatkatana);
    }

    private void Update()
    {
        EG_SAGO = gd.GetComponent<GameDirector>().SAGO;
        EG_SAPC = gd.GetComponent<GameDirector>().SAPC;
        EG_SAGC = gd.GetComponent<GameDirector>().SAGC;

        //���Ԃ��v������
        time += Time.deltaTime;

        //�Q�[���I�[�o�[�ƃQ�[���N���A�̉�ʂ��o�Ă��Ȃ����ɐ��ݏo��
        if (EG_SAGO == false && EG_SAPC == false && EG_SAGC == false)
        {
            //time�̒l��repeatkatana�𒴂����Ƃ�katana�𐶂ݏo��
            if (time > repeatkatana)
            {
                //Random.Range(A,B) A��B�͈̔͂̒��Œ��I���� /*���̃X�|�[���ʒu�����߂Ă���*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,�����ʒu,��]�p)(new Vector2(X�����͍ŏ��̒l����-9����9�̒��̃����_���ȏꏊ�AY������6,��]�͂��Ȃ��̂Œl�͓���Ȃ�))
                Instantiate(katanaprefab, new Vector2(SpawnP, 6), transform.rotation);

                //�����Ōv���������Ԃ�0�ɂ���
                time = 0f;
            }
        }
    }
}
