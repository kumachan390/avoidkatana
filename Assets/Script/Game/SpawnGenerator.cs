using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnGenerator : MonoBehaviour
{
    /*刀を生み出す場所、速さの設定*/

    [Header("ゲームディレクターの取得")]
    public GameObject SG_gd;

    [Header("タイマーの取得")]
    public GameObject SG_tm;

    //[Header("chooseBackの取得")] 
    //public GameObject cb;

    [Header("刀のプレハブ入れ")]
    public GameObject katanaprefab;

    [Header("手裏剣のプレハブ入れ")]
    public GameObject syurikenprefab;

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

    [Header("出現間隔(開始後の手裏剣の出現頻度)")]
    public float repeatsyuriken = 1f;

    [Header("出現間隔(30秒後の手裏剣の出現頻度)")]
    public float FTMrepeatsyuriken = 0.8f;

    [Header("出現間隔(50秒後の手裏剣の出現頻度)")]
    public float Lastrepeatsyuriken = 0.5f;

    [Header("刀の出現タイミングを管理するタイマー")]
    public float TaimingTimer;

    [Header("刀の経過時間")]
    public float katanaTime;

    [Header("手裏剣の経過時間")]
    public float syurikenTime;

    //タイマーの持っている制限時間の残り
    private float EG_CT;

    //一時停止bool
    private bool EG_F;

    //ゲームクリア画面かゲームオーバー画面かパーフェクト画面が出ているなら刀を降らせないためのbool値
    private bool EG_SAGO;
    private bool EG_SAGC;
    private bool EG_SAPC;

    ////easyを選んだ時のbool
    //private bool CBC_CE;
    ////Normalを選んだ時のbool
    //private bool CBC_CN;
    ////Hardを選んだ時のbool
    //private bool CBC_CH;

    void Start()
    {
        /*二度と書かない*/
        ////第二引数は初回の呼び出しまでの秒数、第三引数は次回までの秒数
        //InvokeRepeating("GenArrow", NO1, repeatkatana);
    }

    private void Update()
    {
        ////スタンバイシーンで選んだ難易度によって難易度を変える
        //CBC_CE = cb.GetComponent<Difficulty>().ChooseEasy;
        //CBC_CN = cb.GetComponent<Difficulty>().ChooseNormal;
        //CBC_CH = cb.GetComponent<Difficulty>().ChooseHard;

        EG_SAGO = SG_gd.GetComponent<GameDirector>().SAGO;
        EG_SAPC = SG_gd.GetComponent<GameDirector>().SAPC;
        EG_SAGC = SG_gd.GetComponent<GameDirector>().SAGC;

        EG_F = SG_gd.GetComponent<GameDirector>().freeze;

        //ゲームオーバーとパーフェクトクリアとゲームクリアと一時停止の画面が出ていない時に生み出す
        if (EG_SAGO == false && EG_SAPC == false && EG_SAGC == false && EG_F == false)
        {
            //出現タイミングを管理するタイマーを計測する
            TaimingTimer += Time.deltaTime;

            //刀の経過時間を計測する
            katanaTime += Time.deltaTime;

            //手裏剣の経過時間を計測する
            syurikenTime += Time.deltaTime;

            //timeの値がrepeatkatanaを超えたとき刀を生み出す
            if (katanaTime > repeatkatana)
            {
                //Random.Range(A,B) AとBの範囲の中で抽選する /*刀のスポーン位置を決めている*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,生成位置,回転角)(new Vector2(X方向は最初の値から-9から9の中のランダムな場所、Y方向は6,回転はしないので値は入れない))
                GameObject kp = Instantiate(katanaprefab, new Vector2(SpawnP, 6), transform.rotation);

                //刀にpauseの判定を教える処理
                kp.GetComponent<KatanaController>().KC_gd = SG_gd;

                //ここで計測した時間を0にする
                katanaTime = 0f;
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

            if(syurikenTime > repeatsyuriken)
            {
                //Random.Range(A,B) AとBの範囲の中で抽選する /*刀のスポーン位置を決めている*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,生成位置,回転角)(new Vector2(X方向は最初の値から-9から9の中のランダムな場所、Y方向は6,回転はしないので値は入れない))
                GameObject sp = Instantiate(syurikenprefab, new Vector2(SpawnP, 6), transform.rotation);

                sp.GetComponent<SyurikenController>().SC_gd = SG_gd;

                //ここで計測した時間を0にする
                syurikenTime = 0f;
            }

            //30秒経ったら
            if (TaimingTimer > 30)
            {
                //刀の出現間隔が早くなる
                repeatsyuriken = FTMrepeatsyuriken;
            }

            //50秒経ったら
            if (TaimingTimer > 50)
            {
                //刀の出現間隔が早くなる
                repeatsyuriken = Lastrepeatsyuriken;
            }
        }
    }
}
