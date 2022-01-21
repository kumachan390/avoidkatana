using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*BGM�̊Ǘ�*/

    [Header("�Q�[���f�B���N�^�[�̎擾")]
    [SerializeField]
    private GameObject gd;

    //AudioSource���擾���邽�߂̔�
    private AudioSource audioSource;

    //BGM�̉��ʂ𒲐����邽�߂̂��
    private float volume;
    
    //�����Ŏg���Q�[���I�[�o�[���o�����ǂ����̔���
    private bool AM_SAGO;

    //�����Ŏg���Q�[���N���A���o�����ǂ����̔���
    private bool AM_SAGC;

    //�����Ŏg���p�[�t�F�N�g�N���A���o�����ǂ����̔���
    private bool AM_SAPC;

    void Start()
    {
        //�����ɃA�^�b�`����Ă���AudioSource���擾
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AM_SAGO = gd.GetComponent<GameDirector>().SAGO;
        AM_SAPC = gd.GetComponent<GameDirector>().SAPC;
        AM_SAGC = gd.GetComponent<GameDirector>().SAGC;
        

        //�Q�[���I�[�o�[���Q�[���N���A���o�Ă��Ȃ���BGM�𗬂�
        if(AM_SAGO == false && AM_SAPC == false && AM_SAGC == false)
        {
            audioSource.volume = 0.1f;
        }
        else //����ȊO�Ȃ�BGM�̉��ʂ�0�ɂ���
        {
            audioSource.volume = 0f;
        }
    }
}
