using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    /*刀を生み出す場所、速さの設定*/

    [Header("ゲームディレクターの取得")]
    public GameObject gd;

    [Header("タイマーの取得")]
    public GameObject tm;

    [Header("刀のプレハブ入れ")]
    public GameObject katanaprefab;

    //刀のスポーン場所の値ケース
    private float SpawnP;

    [Header("スポーン範囲の半径")]
    [SerializeField]
    float SpawnMax = 5f;

    [Header("出現間隔(開始後の刀の出現頻度)")]
    public float repeatkatana = 0.5f;

    [Header("出現間隔(30秒後の刀の出現頻度)")]
    public float FTMrepeatkatana = 0.3f;

    [Header("出現間隔(50秒後の刀の出現頻度)")]
    public float Lastrepeatkatana = 0.2f;

    [Header("刀の出現タイミングを管理するタイマー")]
    public float TaimingTimer;

    [Header("経過時間")]
    public float elapsedTime;

    //タイマーの持っている制限時間の残り
    private float EG_CT;

    //ゲームクリア画面かゲームオーバー画面が出ているなら刀を降らせないためのbool値
    private bool EG_SAGO;
    private bool EG_SAGC;
    private bool EG_SAPC;

    void Start()
    {
        /*二度と書かない*/
        ////第二引数は初回の呼び出しまでの秒数、第三引数は次回までの秒数
        //InvokeRepeating("GenArrow", NO1, repeatkatana);
    }

    private void Update()
    {
        EG_SAGO = gd.GetComponent<GameDirector>().SAGO;
        EG_SAPC = gd.GetComponent<GameDirector>().SAPC;
        EG_SAGC = gd.GetComponent<GameDirector>().SAGC;

        //出現タイミングを管理するタイマーを計測する
        TaimingTimer += Time.deltaTime;

        //経過時間を計測する
        elapsedTime += Time.deltaTime;

        //ゲームオーバーとパーフェクトクリアとゲームクリアの画面が出ていない時に生み出す
        if (EG_SAGO == false && EG_SAPC == false && EG_SAGC == false)
        {
            //timeの値がrepeatkatanaを超えたときkatanaを生み出す
            if (elapsedTime > repeatkatana)
            {
                //Random.Range(A,B) AとBの範囲の中で抽選する /*刀のスポーン位置を決めている*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,生成位置,回転角)(new Vector2(X方向は最初の値から-9から9の中のランダムな場所、Y方向は6,回転はしないので値は入れない))
                Instantiate(katanaprefab, new Vector2(SpawnP, 6), transform.rotation);

                //ここで計測した時間を0にする
                elapsedTime = 0f;
            }

            //30秒経ったら
            if (TaimingTimer > 30)
            {
                //刀の出現間隔が早くなる
                repeatkatana = FTMrepeatkatana;
            }

            //50秒経ったら
            if (TaimingTimer > 50)
            {
                //刀の出現間隔が早くなる
                repeatkatana = Lastrepeatkatana;
            }
        }
    }
}
