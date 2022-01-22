using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    /*左右の移動、体力、刀に当たった時のSE*/

    [Header("刀が当たった時の効果音")]
    public AudioClip HitKatana;

    [Header("手裏剣が当たった時の効果音")]
    public AudioClip HitSyuriken;

    //刀のプレハブを取得する
    public GameObject kp;

    //手裏剣のプレハブを取得する
    public GameObject sp;

    //ゲームディレクターの取得
    public GameObject gd;

    [Header("プレイヤーの最大のHP")]
    public int P_MaxHP = 10;

    //[NonSerialized]Unity上に出したくないpublic
    [Header("プレイヤーの現在のHP")]
    public int P_NowHP;

    [Header("毎秒動かす距離")]
    [SerializeField]
    private float moveSpeed;

    [Header("ゆっくり動かす距離")]
    [SerializeField]
    private float sneakmoveSpeed;

    [Header("画面左端のX座標")]
    [SerializeField]
    private float screenLeft = 0;

    [Header("画面右端のX座標")]
    [SerializeField]
    private float screenRight = 0;

    //ここで使うゲームオーバー画面が出たかどうかの判定
    private bool PC_SAGO;

    //ここで使うパーフェクトクリア画面が出たかどうかの判定
    private bool PC_SAPC;

    //ここで使うゲームクリア画面が出たかどうかの判定
    private bool PC_SAGC;

    //刀の攻撃力
    private int PC_KA;

    //手裏剣の攻撃力
    private int PC_SA;

    private float Horizontal;

    Rigidbody2D rb;

    /*Rigidbody2Dの中にあるConstraintsのFreezeでその動きを拘束できる*/

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //刀の攻撃力を取得
        PC_KA = kp.GetComponent<KatanaController>().katanaAttack;

        //手裏剣の攻撃力を取得
        PC_SA = sp.GetComponent<SyurikenController>().syurikenAttack;
    }

    void Update()
    {
        //ゲームオーバー画面が出たかどうか
        PC_SAGO = gd.GetComponent<GameDirector>().SAGO;

        //パーフェクトクリア画面が出たかどうか
        PC_SAPC = gd.GetComponent<GameDirector>().SAPC;

        //ゲームクリア画面が出たかどうか
        PC_SAGC = gd.GetComponent<GameDirector>().SAGC;

        //左を押したら-1、右を押したら1、押してないときは0
        Horizontal = Input.GetAxis("Horizontal_P");

        //ゲームオーバー画面が出ていなくてゲームクリア画面も出ていないときに動ける /*どっちか一つでも表示されていたら動けなくなる*/
        if (PC_SAGO == false && PC_SAPC == false && PC_SAGC == false)
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
            if (Input.GetKey(KeyCode.LeftShift) || Input.GetKey(KeyCode.RightShift))
            {
                moveSpeed = sneakmoveSpeed;
            }
            else
            {
                moveSpeed = 10;
            }

            //移動量は動く速さと横移動の方向を掛けたやつ
            float MovePower = moveSpeed * Horizontal;

            //Xの移動量はmovepower、Yは今の座標のまま(今回は動かない)
            rb.velocity = new Vector2(MovePower,0);
        }
        else
        {
            //ゲームの結果が出たらプレイヤーを動けなくする
            rb.velocity = new Vector2(0,0);
        }
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (PC_SAGO == false && PC_SAPC == false && PC_SAGC ==false)
        {
            //制限時間が残っていて刀に当たったら
            if (other.gameObject.tag == "katana")
            {
                Debug.Log("いてえ！");

                //プレイヤーの体力を減らす
                P_NowHP -= PC_KA;

                //Vector3の後ろはメインカメラのちょっと下の位置
                AudioSource.PlayClipAtPoint(HitKatana, new Vector2(0, 0));
            }

            if(other.gameObject.tag == "syuriken")
            {
                Debug.Log("いってえ！！");

                P_NowHP -= PC_SA;

                AudioSource.PlayClipAtPoint(HitSyuriken, new Vector2(0, 0));
            }
        }
    }
}
