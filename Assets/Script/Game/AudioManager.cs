using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*BGM�̊Ǘ�*/

    [Header("�Q�[���f�B���N�^�[�̎擾")]
    [SerializeField]
    private GameObject AM_gd;

    //AudioSource���擾���邽�߂̔�
    public AudioSource audioSource;

    //BGM�̉��ʂ𒲐����邽�߂̂��
    private float volume;
    
    //�����Ŏg���Q�[���I�[�o�[���o�����ǂ����̔���
    private bool AM_SAGO;

    //�����Ŏg���Q�[���N���A���o�����ǂ����̔���
    private bool AM_SAGC;

    //�����Ŏg���p�[�t�F�N�g�N���A���o�����ǂ����̔���
    private bool AM_SAPC;

    //�ꎞ��~
    private bool AM_F;

    void Start()
    {
        //�����ɃA�^�b�`����Ă���AudioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AM_SAGO = AM_gd.GetComponent<GameDirector>().SAGO;
        AM_SAPC = AM_gd.GetComponent<GameDirector>().SAPC;
        AM_SAGC = AM_gd.GetComponent<GameDirector>().SAGC;

        AM_F = AM_gd.GetComponent<GameDirector>().freeze;

        //�Q�[���I�[�o�[���Q�[���N���A���o�Ă��Ȃ���BGM�𗬂�
        if (AM_SAGO == false && AM_SAPC == false && AM_SAGC == false && AM_F == false)
        {
            audioSource.volume = 0.2f;
        }
        else //����ȊO�Ȃ�BGM�̉��ʂ�0�ɂ���
        {
            audioSource.volume = 0;
        }
    }
}
