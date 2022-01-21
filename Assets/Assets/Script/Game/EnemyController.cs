using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour
{
    /*���̍U���́A�����A�v���C���[�ɓ����������̔���*/

    [Header("�^�C�}�[�̎擾")]
    public GameObject tm;

    [Header("���̍U����")]
    [System.NonSerialized]
    public int katanaAttack = 1;

    [Header("���̗����鑬��")]
    [SerializeField]
    private float fallSpeed = 1;

    [Header("���̗�����Œx")]
    [SerializeField]
    private float fallSpeedMin = 1;

    [Header("���̗�����ő�")]
    [SerializeField]
    private float fallSpeedMax = 5;

    Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        //Random.Range(A,B) A��B�͈̔͂̒��Œ��I���� /*�����鑬���������_���Ɍ��߂Ă���*/
        this.fallSpeed = Random.Range(fallSpeedMin,fallSpeedMax);
    }

    void FixedUpdate()
    {
        //x�����ɓ����͂�0�Ay�����ɓ����͂�fallspeed�̒l�̑����ŗ�����
        rb.velocity = new Vector2(0,-fallSpeed);

        //y���W��-6���߂�����������
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    //OnCollisionEnter2D(Collision2D other) ���������R���W������other�Ɋi�[
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            Destroy(gameObject);
        }
    }
}
