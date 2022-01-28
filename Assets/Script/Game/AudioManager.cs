using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*BGMの管理*/

    [Header("ゲームディレクターの取得")]
    [SerializeField]
    private GameObject AM_gd;

    //AudioSourceを取得するための箱
    public AudioSource audioSource;

    //BGMの音量を調整するためのやつ
    private float volume;
    
    //ここで使うゲームオーバーが出たかどうかの判定
    private bool AM_SAGO;

    //ここで使うゲームクリアが出たかどうかの判定
    private bool AM_SAGC;

    //ここで使うパーフェクトクリアが出たかどうかの判定
    private bool AM_SAPC;

    //一時停止
    private bool AM_F;

    void Start()
    {
        //自分にアタッチされているAudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AM_SAGO = AM_gd.GetComponent<GameDirector>().SAGO;
        AM_SAPC = AM_gd.GetComponent<GameDirector>().SAPC;
        AM_SAGC = AM_gd.GetComponent<GameDirector>().SAGC;

        AM_F = AM_gd.GetComponent<GameDirector>().freeze;

        //ゲームオーバーもゲームクリアも出ていない時BGMを流す
        if (AM_SAGO == false && AM_SAPC == false && AM_SAGC == false && AM_F == false)
        {
            audioSource.volume = 0.2f;
        }
        else //それ以外ならBGMの音量を0にする
        {
            audioSource.volume = 0;
        }
    }
}
