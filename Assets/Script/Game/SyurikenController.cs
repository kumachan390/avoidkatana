using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenController : MonoBehaviour
{
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

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Random.Range(A,B) AとBの範囲の中で抽選する /*落ちる速さをランダムに決めている*/
        this.syurikenFallSpeed = Random.Range(syuSpeedMin, syuSpeedMax);
    }

    void FixedUpdate()
    {
        //x方向に働く力は0、y方向に働く力はsyurikenfallspeedの値の速さで落ちる
        rb.velocity = new Vector2(0, -syurikenFallSpeed);

        //Z軸を中心に回転する
        transform.Rotate(new Vector3(0, 0, -15));

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
