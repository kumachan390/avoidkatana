using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenController : MonoBehaviour
{
    //ゲームディレクターの取得
    [System.NonSerialized]
    public GameObject SC_gd;

    [Header("手裏剣の攻撃力")]
    [System.NonSerialized]
    public int syurikenAttack = 2;

    [Header("手裏剣の落ちる速さ")]
    [SerializeField]
    private float syurikenFallSpeed = 1;

    [Header("手裏剣の落ちる最遅")]
    [SerializeField]
    private float syuSpeedMin = 1;

    [Header("手裏剣の落ちる最速")]
    [SerializeField]
    private float syuSpeedMax = 5;

    //一時停止の旗
    private bool SC_F;

    Rigidbody2D rb;

    void Start()
    {
        SC_F = false;

        rb = GetComponent<Rigidbody2D>();

        //Random.Range(A,B) AとBの範囲の中で抽選する /*落ちる速さをランダムに決めている*/
        this.syurikenFallSpeed = Random.Range(syuSpeedMin, syuSpeedMax);
    }

    void FixedUpdate()
    {
        SC_F = SC_gd.GetComponent<GameDirector>().freeze;


        //一時停止したら手裏剣の動きを止める
        if (SC_F == false)
        {
            //x方向に働く力は0、y方向に働く力はsyurikenfallspeedの値の速さで落ちる
            rb.velocity = new Vector2(0, -syurikenFallSpeed);

            //Z軸を中心に回転する
            transform.Rotate(new Vector3(0, 0, -15));

        }
        else
        {
            rb.velocity = new Vector2(0, 0);
            transform.Rotate(new Vector3(0, 0, 0));
        }

        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.tag == "Player" || collision.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
