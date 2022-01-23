using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Difficulty : MonoBehaviour
{
    /*難易度の選択*/

    [Header("選んでる難易度のカーソル")]
    public GameObject chooseBack;

    //easyを選んだ時のbool
    [System.NonSerialized]
    public bool ChooseEasy;

    //Normalを選んだ時のbool
    [System.NonSerialized]
    public bool ChooseNormal;

    //Hardを選んだ時のbool
    [System.NonSerialized]
    public bool ChooseHard;


    void Start()
    {
        //始まったら旗を下げる
        ChooseEasy = false;
        ChooseNormal = false;
        ChooseHard = false;
    }

    
    void Update()
    {
        //chhoseBackのY座標が190(easyの場所)で、旗が下がっているなら旗を揚げる
        if(chooseBack.transform.position.y == 190 && ChooseEasy == false)
        {
            ChooseEasy = true;
        }

        //chhoseBackのY座標が0(Normalの場所)で、旗が下がっているなら旗を揚げる
        if (chooseBack.transform.position.y == 0 && ChooseNormal == false)
        {
            ChooseNormal = true;
        }

        //chhoseBackのY座標が-190(Hardの場所)で、旗が下がっているなら旗を揚げる
        if (chooseBack.transform.position.y == -190 && ChooseHard == false)
        {
            ChooseHard = true;
        }
        /*easy (x,190)*/
        /*normal(x,0)*/
        /*hard(x,-190)*/
    }
}
