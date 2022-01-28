using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    /*���𐶂ݏo���ꏊ�A�����̐ݒ�*/

    [Header("�Q�[���f�B���N�^�[�̎擾")]
    public GameObject SG_gd;

    [Header("�^�C�}�[�̎擾")]
    public GameObject SG_tm;

    //[Header("chooseBack�̎擾")] 
    //public GameObject cb;

    [Header("���̃v���n�u����")]
    public GameObject katanaprefab;

    [Header("�藠���̃v���n�u����")]
    public GameObject syurikenprefab;

    //���̃X�|�[���ꏊ�̒l�P�[�X
    private float SpawnP;

    [Header("�X�|�[���͈͂̔��a")]
    [SerializeField]
    float SpawnMax = 5f;

    [Header("�o���Ԋu(�J�n��̓��̏o���p�x)")]
    public float repeatkatana = 0.5f;

    [Header("�o���Ԋu(30�b��̓��̏o���p�x)")]
    public float FTMrepeatkatana = 0.3f;

    [Header("�o���Ԋu(50�b��̓��̏o���p�x)")]
    public float Lastrepeatkatana = 0.2f;

    [Header("�o���Ԋu(�J�n��̎藠���̏o���p�x)")]
    public float repeatsyuriken = 1f;

    [Header("�o���Ԋu(30�b��̎藠���̏o���p�x)")]
    public float FTMrepeatsyuriken = 0.8f;

    [Header("�o���Ԋu(50�b��̎藠���̏o���p�x)")]
    public float Lastrepeatsyuriken = 0.5f;

    [Header("���̏o���^�C�~���O���Ǘ�����^�C�}�[")]
    public float TaimingTimer;

    [Header("���̌o�ߎ���")]
    public float katanaTime;

    [Header("�藠���̌o�ߎ���")]
    public float syurikenTime;

    //�^�C�}�[�̎����Ă��鐧�����Ԃ̎c��
    private float EG_CT;

    //�ꎞ��~bool
    private bool EG_F;

    //�Q�[���N���A��ʂ��Q�[���I�[�o�[��ʂ��p�[�t�F�N�g��ʂ��o�Ă���Ȃ瓁���~�点�Ȃ����߂�bool�l
    private bool EG_SAGO;
    private bool EG_SAGC;
    private bool EG_SAPC;

    ////easy��I�񂾎���bool
    //private bool CBC_CE;
    ////Normal��I�񂾎���bool
    //private bool CBC_CN;
    ////Hard��I�񂾎���bool
    //private bool CBC_CH;

    void Start()
    {
        /*��x�Ə����Ȃ�*/
        ////�������͏���̌Ăяo���܂ł̕b���A��O�����͎���܂ł̕b��
        //InvokeRepeating("GenArrow", NO1, repeatkatana);
    }

    private void Update()
    {
        ////�X�^���o�C�V�[���őI�񂾓�Փx�ɂ���ē�Փx��ς���
        //CBC_CE = cb.GetComponent<Difficulty>().ChooseEasy;
        //CBC_CN = cb.GetComponent<Difficulty>().ChooseNormal;
        //CBC_CH = cb.GetComponent<Difficulty>().ChooseHard;

        EG_SAGO = SG_gd.GetComponent<GameDirector>().SAGO;
        EG_SAPC = SG_gd.GetComponent<GameDirector>().SAPC;
        EG_SAGC = SG_gd.GetComponent<GameDirector>().SAGC;

        EG_F = SG_gd.GetComponent<GameDirector>().freeze;

        //�Q�[���I�[�o�[�ƃp�[�t�F�N�g�N���A�ƃQ�[���N���A�ƈꎞ��~�̉�ʂ��o�Ă��Ȃ����ɐ��ݏo��
        if (EG_SAGO == false && EG_SAPC == false && EG_SAGC == false && EG_F == false)
        {
            //�o���^�C�~���O���Ǘ�����^�C�}�[���v������
            TaimingTimer += Time.deltaTime;

            //���̌o�ߎ��Ԃ��v������
            katanaTime += Time.deltaTime;

            //�藠���̌o�ߎ��Ԃ��v������
            syurikenTime += Time.deltaTime;

            //time�̒l��repeatkatana�𒴂����Ƃ����𐶂ݏo��
            if (katanaTime > repeatkatana)
            {
                //Random.Range(A,B) A��B�͈̔͂̒��Œ��I���� /*���̃X�|�[���ʒu�����߂Ă���*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,�����ʒu,��]�p)(new Vector2(X�����͍ŏ��̒l����-9����9�̒��̃����_���ȏꏊ�AY������6,��]�͂��Ȃ��̂Œl�͓���Ȃ�))
                GameObject kp = Instantiate(katanaprefab, new Vector2(SpawnP, 6), transform.rotation);

                //����pause�̔���������鏈��
                kp.GetComponent<KatanaController>().KC_gd = SG_gd;

                //�����Ōv���������Ԃ�0�ɂ���
                katanaTime = 0f;
            }

            //30�b�o������
            if (TaimingTimer > 30)
            {
                //���̏o���Ԋu�������Ȃ�
                repeatkatana = FTMrepeatkatana;
            }

            //50�b�o������
            if (TaimingTimer > 50)
            {
                //���̏o���Ԋu�������Ȃ�
                repeatkatana = Lastrepeatkatana;
            }

            if(syurikenTime > repeatsyuriken)
            {
                //Random.Range(A,B) A��B�͈̔͂̒��Œ��I���� /*���̃X�|�[���ʒu�����߂Ă���*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,�����ʒu,��]�p)(new Vector2(X�����͍ŏ��̒l����-9����9�̒��̃����_���ȏꏊ�AY������6,��]�͂��Ȃ��̂Œl�͓���Ȃ�))
                GameObject sp = Instantiate(syurikenprefab, new Vector2(SpawnP, 6), transform.rotation);

                sp.GetComponent<SyurikenController>().SC_gd = SG_gd;

                //�����Ōv���������Ԃ�0�ɂ���
                syurikenTime = 0f;
            }

            //30�b�o������
            if (TaimingTimer > 30)
            {
                //���̏o���Ԋu�������Ȃ�
                repeatsyuriken = FTMrepeatsyuriken;
            }

            //50�b�o������
            if (TaimingTimer > 50)
            {
                //���̏o���Ԋu�������Ȃ�
                repeatsyuriken = Lastrepeatsyuriken;
            }
        }
    }
}
