using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KatanaController : MonoBehaviour
{
    /*���̍U���́A�����A�v���C���[�ɓ����������̔���*/

    //�Q�[���f�B���N�^�[�̎擾
    [System.NonSerialized]
    public GameObject KC_gd;

    [Header("���̍U����")]
    [System.NonSerialized]
    public int katanaAttack = 1;

    [Header("���̗����鑬��")]
    [SerializeField]
    private float katanaFallSpeed = 1;

    [Header("���̗�����Œx")]
    [SerializeField]
    private float fallSpeedMin = 1;

    [Header("���̗�����ő�")]
    [SerializeField]
    private float fallSpeedMax = 5;

    //�ꎞ��~�̎擾
    private bool KC_F;

    Rigidbody2D rb;

    void Start()
    {
        KC_F = false;

        rb = GetComponent<Rigidbody2D>();

        //Random.Range(A,B) A��B�͈̔͂̒��Œ��I���� /*�����鑬���������_���Ɍ��߂Ă���*/
        this.katanaFallSpeed = Random.Range(fallSpeedMin,fallSpeedMax);
    }

    void FixedUpdate()
    {
        KC_F = KC_gd.GetComponent<GameDirector>().freeze;

        //�ꎞ��~�����瓁�̓������~�߂�
        if(KC_F == false)
        {
            //x�����ɓ����͂�0�Ay�����ɓ����͂�fallspeed�̒l�̑����ŗ�����
            rb.velocity = new Vector2(0, -katanaFallSpeed);
        }
        else 
        {
            rb.velocity = new Vector2(0, 0);
        }

        //y���W��-6���߂�����������
        if(transform.position.y < -6)
        {
            Destroy(gameObject);
        }
    }

    //OnCollisionEnter2D(Collision2D other) ���������R���W������other�Ɋi�[
    private void OnTriggerEnter2D(Collider2D other)
    {
        if(other.gameObject.tag == "Player" || other.gameObject.tag == "Ground")
        {
            Destroy(gameObject);
        }
    }
}
