using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    /*�Q�[���I�[�o�[�ƃQ�[���N���A�̊Ǘ�(����̏����Ńp�l���̕\��)*/

    /*�T�E���h�����Ȃ��Ă��J��Ԃ��邩��Ώ����K�v*/

    [Header("�v���C���[�̎擾")]
    public GameObject GD_pc;

    [Header("�^�C�}�[�̎擾")]
    public GameObject GD_Tm;

    [Header("�Q�[���I�[�o�[�̃p�l���̎擾")]
    public GameObject Gameover;

    [Header("�Q�[���N���A�̃p�l���̎擾")]
    public GameObject Gameclear;

    [Header("�p�[�t�F�N�g�N���A�����Ƃ��̃p�l���̎擾")]
    public GameObject Perfectclear;

    [Header("�|�[�Y��ʃp�l���̎擾")]
    public GameObject Pause;

    [Header("�Q�[���I�[�o�[�T�E���h�̎擾")]
    public AudioClip GO_Sound;

    [Header("�Q�[���N���A�T�E���h�̎擾")]
    public AudioClip GC_Sound;

    [Header("�p�[�t�F�N�g�N���A�T�E���h�̎擾")]
    public AudioClip PC_Sound;

    //���̃N���X�Ŏg�����߂Ƀv���C���[�R���g���[���[��HP���擾����
    private int GD_PNHP;

    //���̃N���X�Ŏg�����߂̃v���C���[�̍ő�HP���擾����
    private int GD_PMHP;

    //�������Ԃ��I��������I����ĂȂ����@true�Ȃ琧�����Ԃ������Afalse�Ȃ琧�����Ԃ͎c���Ă���
    private bool GD_TE;

    //�̗͂�0��0�ȏォ�@true�Ȃ玀�񂾁Afalse�Ȃ琶���Ă�
    [System.NonSerialized]
    public bool GOflag = false;

    //�Q�[���I�[�o�[��ʂ��o�Ă���Ƃ��@true�Ȃ�o�Ă�Afalse�Ȃ�o�ĂȂ�
    [System.NonSerialized]
    public bool SAGO;

    //�Q�[���N���A��ʂ��o�Ă���Ƃ��@true�Ȃ�o�Ă�Afalse�Ȃ�o�ĂȂ�
    [System.NonSerialized]
    public bool SAGC;

    //�p�[�t�F�N�g�N���A��ʂ��o�Ă���Ƃ��@true�Ȃ�o�Ă�Afalse�Ȃ�o�ĂȂ�
    [System.NonSerialized]
    public bool SAPC;

    //�ꎞ��~����bool�@true�Ȃ�ꎞ��~�Afalse�Ȃ�ꎞ��~�ł͂Ȃ�
    [System.NonSerialized]
    public bool freeze;

    //�Q�[���I�[�o�[����1�񂾂��炷���߂̊� /*true�Ȃ�����Afalse�Ȃ���ĂȂ�*/
    [System.NonSerialized]
    public bool GOAudio;

    //�Q�[���N���A��1�񂾂��炷���߂̊� /*true�Ȃ�����Afalse�Ȃ���ĂȂ�*/
    [System.NonSerialized]
    public bool GCAudio;

    [System.NonSerialized]
    public bool PCAudio;

    void Start()
    {
        //�ŏ��̓N���A��ʂ��Q�[���I�[�o�[��ʂ���\��
        Gameclear.SetActive(false);
        Gameover.SetActive(false);
        
        //�|�[�Y��ʂ̔�\��
        Pause.SetActive(false);

        /*bool���߂��Ȃ͕̂������Ă܂��B�ł��A��X���̕��@���o���Ă����̂ŋ����Ă�������*/
        //�ŏ��ɑS�����������邱�Ƃŏ����������
        GOflag = false;
        GD_TE = false;
        SAGO = false;
        SAGC = false;
        SAPC = false;
        freeze = false;
        GOAudio = false;
        GCAudio = false;
        PCAudio = false;

        //�v���C���[�̍ő�HP���擾
        GD_PMHP = GD_pc.GetComponent<PlayerController>().P_MaxHP;
    }

    void Update()
    {
        //�v���C���[�̌��݂�HP���擾
        GD_PNHP = GD_pc.GetComponent<PlayerController>().P_NowHP;

        //Timer�̒��̐������ԏI���̊����擾
        GD_TE = GD_Tm.GetComponent<Timer>().timeEnd;

        /*�v���C���[�̗̑͂������Ȃ�����Q�[���I�[�o�[��ʂ��o��*/
        /*�����I:)*/

        //�v���C���[�̗̑͂�0�ɂȂ�����t���O���グ��(����)
        if (GD_PNHP <= 0)
        {
            GOflag = true;
        }
        //�v���C���[�̗̑͂�0����Ȃ��Ȃ�t���O�͂��̂܂�(�����Ă�)
        else
        {
            GOflag = false;
        }

        //����Ő������Ԃ��c���Ă���Ƃ��R�R
        if(GOflag == true && GD_TE == false)
        {
            //�Q�[���I�[�o�[�ɂȂ����̂Ŋ���g����
            SAGO = true;
            GameOver();
        }
        //�̗͂������Ă��Ȃ��Đ������Ԃ��Ȃ��Ȃ����Ƃ��R�R
        else if (GD_PNHP == GD_PMHP && GD_TE == true)
        {
            //�p�[�t�F�N�g�N���A�Ȃ̂Ŋ���g����
            SAPC = true;
            PerfectClear();
        }
        //�����ĂĐ������Ԃ��Ȃ��Ȃ����Ƃ��R�R
        else if(GOflag == false && GD_TE == true)
        {
            //�Q�[���N���A�ɂȂ����̂Ŋ���g����
            SAGC = true;
            GameClear();
        }

        //P����������ꎞ��~�t���O��g����(�|�[�Y��ʂ������ɕ\�����悤�Ƃ������ǃQ�[�����~�܂��Ă��܂���)
        if (Input.GetKeyDown(KeyCode.P))
        {
            freeze = true;
        }

        //�|�[�Y��ʂ�\������
        if (freeze == true)
        {
            Pause.SetActive(true);
        }

        //�|�[�Y��ʂ��o�Ă��ăX�y�[�X�L�[�������ꂽ��Q�[���ĊJ
        if(Pause == true && Input.GetKeyDown(KeyCode.Space))
        {
            Pause.SetActive(false);
            freeze = false;
        }
        
        //�|�[�Y��ʂ��o�Ă��ăG�X�P�[�v�L�[�������ꂽ��^�C�g���ɖ߂�
        if(Pause == true && Input.GetKeyDown(KeyCode.Escape))
        {
            SceneManager.LoadScene("TitleScene");
            freeze = false;
        }

        //�Q�[���I�[�o�[��ʂ��o�Ă���Ƃ�E�������ƃ^�C�g���ɖ߂�
        if(SAGO == true)
        {
            if(GOAudio == false)
            {
                //�Q�[���I�[�o�[�����o��
                AudioSource.PlayClipAtPoint(GO_Sound, new Vector2(0, 0));
                Debug.Log("����");

                //���ʉ���1�񂾂��炵�Ċ���g���� /*����1��g�����炱���̏������ɂ͗���Ȃ��̂�1��̂�*/
                GOAudio = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("TitleScene");
                SAGO = false;
            }
        }

        //�p�[�t�F�N�g�N���A��ʂ��o�Ă���Ƃ�E�������ƃ^�C�g���ɖ߂�
        if (SAPC == true)
        {
            if (PCAudio == false)
            {
                //�p�[�t�F�N�g�N���A�����o��
                AudioSource.PlayClipAtPoint(PC_Sound, new Vector2(0, 0));

                //���ʉ���1�񂾂��炵�Ċ���g���� /*1��̂�*/
                PCAudio = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("TitleScene");
                SAPC = false;
            }
        }

        //�Q�[���N���A��ʂ��o�Ă���Ƃ�E�������ƃ^�C�g���ɖ߂�
        if (SAGC == true)
        {
            if(GCAudio == false)
            {
                //�Q�[���N���A�����o��
                AudioSource.PlayClipAtPoint(GC_Sound, new Vector2(0, 0));
                Debug.Log("����");

                //���ʉ���1�񂾂��炵�Ċ���g���� /*����1��g�����炱���̏������ɂ͗���Ȃ��̂�1��̂�*/
                GCAudio = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("TitleScene");
                SAGC = false;
            }
        }
    }

    void GameClear()
    {
        //�v���C���[�̗̑͂��c���Ă��Đ������Ԃ��c���Ă��Ȃ��Ȃ�Q�[���N���A��ʂ��o��
        Gameclear.SetActive(true);
    }

    void PerfectClear()
    {
        //�v���C���[�̗̑͂������Ă��Ȃ��Đ������Ԃ��c���Ă��Ȃ��Ȃ�p�[�t�F�N�g�N���A��ʂ��o��
        Perfectclear.SetActive(true);
    }

    void GameOver()
    {
        //�v���C���[�̗̑͂��[���ɂȂ��Đ������Ԃ��c���Ă���Ȃ�Q�[���I�[�o�[��ʂ��o��
        Gameover.SetActive(true);
    }
}
