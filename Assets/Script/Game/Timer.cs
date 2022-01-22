using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour
{
    /*制限時間の処理*/
    /*ゲームオーバー画面、ゲームクリア画面が表示されたら時間を止める*/

    public GameObject GD;

    //ここで使うゲームオーバー画面が出たかどうかの判定
    private bool TM_SAGO;

    //
    private bool TM_SAPC;

    //ここで使うゲームクリア画面が出たかどうかの判定
    private bool TM_SAGC;

    [Header("テキストの取得")]
    [SerializeField]
    private Text timertext;

    [Header("制限時間")]
    [SerializeField]
    private float countMax = 0f;

    //現在の制限時間の残り
    [System.NonSerialized]
    public float countTime;

    //制限時間が終わったらtrue、制限時間が終わるまではfalse
    [System.NonSerialized]
    public bool timeEnd = false;

    private void Start()
    {
        timeEnd = false;

        //制限時間の残りを制限時間と同じ値にする(制限時間の初期化)
        countTime = countMax;
    }

    private void Update()
    {
        TM_SAGO = GD.GetComponent<GameDirector>().SAGO;
        TM_SAPC = GD.GetComponent<GameDirector>().SAPC;
        TM_SAGC = GD.GetComponent<GameDirector>().SAGC;

        //制限時間が終わったらフラグを上げる
        if (countTime <= 0)
        {
            timeEnd = true;
        }
    }

    void FixedUpdate()//時間に誤差が生まれないように
    {
        //ゲームオーバー画面が出ていなくてゲームクリア画面も出ていないときにタイマーの時間がカウントされる
        if (TM_SAGO == false && TM_SAPC == false && TM_SAGC == false)
        {
            //制限時間が0以上の時タイマーのカウントを減らし続ける
            if (countTime > 0)
            {
                countTime -= Time.deltaTime;
            }

            //小数点2以下まで表示する
            timertext.text = countTime.ToString("F2");
        }
        
    }
}
