using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StandbyController : MonoBehaviour
{
    /*�Q�[���̐���������V�[���̑J�ڂƌ��ʉ���炷*/

    [Header("���[�h���鎞�̃X���C�_�[")]
    public Slider slider;

    //�V�[���ړ�����܂ł̎��Ԃ��X���C�_�[�ŏo�����߂̂��
    public float progressTime;

    [Header("�X�^�[�g�̌��ʉ�")]
    public AudioClip start;

    //���ʉ���1�񂾂��炷�� /*true�Ȃ�����Afalse�Ȃ���ĂȂ�*/
    [System.NonSerialized]
    public bool StartAudio;

    //���񂾂�Z�L�[�������ꂽ�Ɗ��m���邽�߂̊� /*true�̎��͉����ꂽ�Afalse�̎��͉�����ĂȂ�*/
    [System.NonSerialized]
    public bool CTStart;

    private void Start()
    {
        //�X���C�_�[��value���擾����
        progressTime = slider.GetComponent<Slider>().value;

        //progressTime������������
        progressTime = 0.0f;

        //slider�̍ő�l��4�ɂ���
        slider.maxValue = 4.0f;

        //slider�̍ŏ��̒l��0�ɂ���
        slider.value = 0f;

        //���������ď�����
        StartAudio = false;
        CTStart = false;
    }

    private void Update()
    {
        //Z�L�[��������Ċ��m��������g�����Ă��Ȃ��Ȃ�
        if(Input.GetKeyDown(KeyCode.Z) && CTStart == false)
        {
            CTStart = true;
        }

        if (CTStart == true)
        {
            //�����̎��ԂƓ���������value��progressTime�̒l��i�߂�
            slider.value += Time.deltaTime;
            progressTime += Time.deltaTime;

            if(StartAudio == false)
            {
                //���ʉ���炷
                AudioSource.PlayClipAtPoint(start, new Vector2(0,0));

                StartAudio = true;
            }

            //4�b�o������V�[���ړ�
            if (progressTime >= 4.0f)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
