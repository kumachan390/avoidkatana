using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    /*�v���C���[�̗̑͂��v���C���[����󂯎��\��*/
    /*����!*/

    [Header("�v���C���[�̎擾")]
    public GameObject HPG_pc;

    //HP�Q�[�W�̃X���C�_�[���擾(GameObject����.value���g���Ȃ�����)
    [Header("�̗̓Q�[�W�ɂȂ�X���C�_�[�̎擾")]
    public Slider hpGauge;

    //�v���C���[�̌��݂�HP���Q�Ƃ��邽�߂̔�
    [Header("�v���C���[�̌��݂�HP")]
    public int HPG_PNHP;

    //�v���C���[�̍ő�HP���Q�Ƃ��邽�߂̔�
    [Header("�v���C���[�̍ő�HP")]
    public int HPG_PMHP;

    void Start()
    {
        //�Q�[���J�n���Ƀv���C���[�̍ő�HP���擾����
        HPG_PMHP = HPG_pc.GetComponent<PlayerController>().P_MaxHP;

        //HP�Q�[�W�Ǝ擾�����v���C���[��HP���Q�Ƃ���
        hpGauge.maxValue = HPG_PMHP;
    }

    void Update()
    {
        //�v���C���[�̌��݂�HP���}�C�t���[���擾����
        HPG_PNHP = HPG_pc.GetComponent<PlayerController>().P_NowHP;

        //HP�Q�[�W��value�����݂�HP�̒l���Q�Ƃ��ē�����
        hpGauge.value = HPG_PNHP;
    }
}
