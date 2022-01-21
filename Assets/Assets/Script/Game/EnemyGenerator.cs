using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyGenerator : MonoBehaviour
{
    /*刀を生み出す場所、速さの設定*/

    [Header("ゲームディレクターの取得")]
    public GameObject gd;

    [Header("刀のプレハブ入れ")]
    public GameObject katanaprefab;

    //刀のスポーン場所の値ケース
    private float SpawnP;

    [Header("スポーン範囲の半径")]
    [SerializeField]
    float SpawnMax = 5f;

    [Header("刀が一番最初に落ちてくる秒数(小数点も可)")]
    public float NO1 = 1f;

    [Header("刀が落ちてくる頻度(小数点も可)")]
    public float repeatkatana = 0.5f;

    //ゲームクリア画面かゲームオーバー画面が出ているなら刀を降らせないためのbool値
    private bool EG_SAGO;
    private bool EG_SAGC;
    private bool EG_SAPC;

    //タイマーでカウントした制限時間を収納する箱
    private float time;

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

        //時間を計測する
        time += Time.deltaTime;

        //ゲームオーバーとゲームクリアの画面が出ていない時に生み出す
        if (EG_SAGO == false && EG_SAPC == false && EG_SAGC == false)
        {
            //timeの値がrepeatkatanaを超えたときkatanaを生み出す
            if (time > repeatkatana)
            {
                //Random.Range(A,B) AとBの範囲の中で抽選する /*刀のスポーン位置を決めている*/
                this.SpawnP = Random.Range(-SpawnMax, SpawnMax);

                //(Instantiate,生成位置,回転角)(new Vector2(X方向は最初の値から-9から9の中のランダムな場所、Y方向は6,回転はしないので値は入れない))
                Instantiate(katanaprefab, new Vector2(SpawnP, 6), transform.rotation);

                //ここで計測した時間を0にする
                time = 0f;
            }
        }
    }
}
