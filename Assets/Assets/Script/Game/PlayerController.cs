using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*左右の移動、体力、刀に当たった時のSE*/

    [Header("刀が当たった時の効果音")]
    public AudioClip HitKatana;

    //刀のプレハブを取得する
    public GameObject KP;

    //ゲームディレクターの取得
    public GameObject gd;

    //
    public GameObject tm;

    //ここで使うゲームオーバー画面が出たかどうかの判定
    private bool PC_SAGO;

    //
    private bool PC_SAPC;

    //ここで使うゲームクリア画面が出たかどうかの判定
    private bool PC_SAGC;

    [Header("効果音の音量調節")]
    public float volume;

    private int PC_KA;

    [Header("プレイヤーの最大のHP")]
    public int P_MaxHP = 10;

    //[NonSerialized]Unity上に出したくないpublic
    [Header("プレイヤーの現在のHP")]
    public int P_NowHP;

    [Header("毎秒動かす距離")]
    [SerializeField]
    private float moveSpeed = 1.0f;

    [Header("画面左端のX座標")]
    [SerializeField]
    private float screenLeft;

    [Header("画面右端のX座標")]
    [SerializeField]
    private float screenRight;

    //ここで使う制限時間が終わったかどうかの旗 /*trueなら制限時間は0、falseなら制限時間は残ってる*/
    private bool PC_TE;

    private float Horizontal;

    Rigidbody2D rb;

    /*Rigidbody2Dの中にあるConstraintsのFreezeでその動きを拘束できる*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //旗を下げて初期化
        PC_TE = false;
    }

    void Update()
    {
        //ゲームオーバー画面が出たかどうか
        PC_SAGO = gd.GetComponent<GameDirector>().SAGO;

        //パーフェクトクリア画面が出たかどうか
        PC_SAPC = gd.GetComponent<GameDirector>().SAPC;

        //ゲームクリア画面が出たかどうか
        PC_SAGC = gd.GetComponent<GameDirector>().SAGC;

        //刀の攻撃力を取得
        PC_KA = KP.GetComponent<EnemyController>().katanaAttack;

        //制限時間が終わったかどうかを判定する
        PC_TE = tm.GetComponent<Timer>().TE;

        //左を押したら-1、右を押したら1、押してないときは0
        Horizontal = Input.GetAxis("Horizontal_P");

        //ゲームオーバー画面が出ていなくてゲームクリア画面も出ていないときに動ける /*どっちか一つでも表示されていたら動けなくなる*/
        if (PC_SAGO == false && PC_SAGC == false)
        {
            Vector3 pos = rb.transform.position;

            //Mathf.Clamp(float1,float2,float3)で画面外に出さないように設定できる float1にはプレイヤーの座標X、float2には画面左端の座標X、float3には画面右端の座標X
            pos.x = Mathf.Clamp(pos.x, screenLeft, screenRight);
            rb.transform.position = pos;
        }
    }

    private void FixedUpdate()
    {
            Move();
    }

    private void Move()
    {
        //動き続けるバグ防止 /*入力もシャットアウト*/
        if (PC_SAGO == false && PC_SAPC == false && PC_SAGC == false)
        {
            //移動量は動く速さと横移動の方向を掛けたやつ
            float MovePower = moveSpeed * Horizontal;

            //Xの移動量はmovepower、Yは今の座標のまま(今回は動かない)
            rb.velocity = new Vector2(MovePower,0);
        }
        else
        {
            rb.velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        //制限時間が残っていて刀に当たったら
        if (other.gameObject.tag == "katana" && PC_TE == false)
        {
            Debug.Log("いてえ！");

            //プレイヤーの体力を減らす
            P_NowHP -= PC_KA;
            
            //Vector3の後ろはメインカメラのちょっと下の位置
            AudioSource.PlayClipAtPoint(HitKatana,new Vector2(0,-4));
        }
    }
}
