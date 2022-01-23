using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    /*��Փx�̑I��*/

    [Header("�I��ł��Փx�̃J�[�\��")]
    public GameObject chooseBack;

    //easy��I�񂾎���bool
    [System.NonSerialized]
    public bool ChooseEasy;

    //Normal��I�񂾎���bool
    [System.NonSerialized]
    public bool ChooseNormal;

    //Hard��I�񂾎���bool
    [System.NonSerialized]
    public bool ChooseHard;


    void Start()
    {
        //�n�܂��������������
        ChooseEasy = false;
        ChooseNormal = false;
        ChooseHard = false;
    }

    
    void Update()
    {
        //chhoseBack��Y���W��190(easy�̏ꏊ)�ŁA�����������Ă���Ȃ����g����
        if(chooseBack.transform.position.y == 190 && ChooseEasy == false)
        {
            ChooseEasy = true;
        }

        //chhoseBack��Y���W��0(Normal�̏ꏊ)�ŁA�����������Ă���Ȃ����g����
        if (chooseBack.transform.position.y == 0 && ChooseNormal == false)
        {
            ChooseNormal = true;
        }

        //chhoseBack��Y���W��-190(Hard�̏ꏊ)�ŁA�����������Ă���Ȃ����g����
        if (chooseBack.transform.position.y == -190 && ChooseHard == false)
        {
            ChooseHard = true;
        }
        /*easy (x,190)*/
        /*normal(x,0)*/
        /*hard(x,-190)*/
    }
}
