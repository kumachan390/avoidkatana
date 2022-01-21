using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /*刀の攻撃力、速さ、プレイヤーに当たった時の判定*/

    [Header("タイマーの取得")]
    public GameObject tm;

    [Header("刀の攻撃力")]
    [System.NonSerialized]
    public int katanaAttack = 1;

    [Header("刀の落ちる速さ")]
    [SerializeField]
    private float fallSpeed = 1;

    [Header("刀の落ちる最遅")]
    [SerializeField]
    private float fallSpeedMin = 1;

    [Header("刀の落ちる最速")]
    [SerializeField]
    private float fallSpeedMax = 5;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Random.Range(A,B) AとBの範囲の中で抽選する /*落ちる速さをランダムに決めている*/
        this.fallSpeed = Random.Range(fallSpeedMin,fallSpeedMax);
    }

    void FixedUpdate()
    {
        //x方向に働く力は0、y方向に働く力はfallspeedの値の速さで落ちる
        rb.velocity = new Vector2(0,-fallSpeed);

        //y座標が-6を過ぎたら矢を消す
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    //OnCollisionEnter2D(Collision2D other) 当たったコリジョンをotherに格納
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
