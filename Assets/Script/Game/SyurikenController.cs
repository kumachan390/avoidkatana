using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SyurikenController : MonoBehaviour
{
    [Header("�藠���̍U����")]
    [System.NonSerialized]
    public int syurikenAttack = 2;

    [Header("�藠���̗����鑬��")]
    [SerializeField]
    private float syurikenFallSpeed = 1;

    [Header("�藠���̗�����Œx")]
    [SerializeField]
    private float syuSpeedMin = 1;

    [Header("�藠���̗�����ő�")]
    [SerializeField]
    private float syuSpeedMax = 5;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Random.Range(A,B) A��B�͈̔͂̒��Œ��I���� /*�����鑬���������_���Ɍ��߂Ă���*/
        this.syurikenFallSpeed = Random.Range(syuSpeedMin, syuSpeedMax);
    }

    void FixedUpdate()
    {
        //x�����ɓ����͂�0�Ay�����ɓ����͂�syurikenfallspeed�̒l�̑����ŗ�����
        rb.velocity = new Vector2(0, -syurikenFallSpeed);

        //Z���𒆐S�ɉ�]����
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
