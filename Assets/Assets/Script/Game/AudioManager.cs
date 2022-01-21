using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AudioManager : MonoBehaviour
{
    /*BGMの管理*/

    [Header("ゲームディレクターの取得")]
    [SerializeField]
    private GameObject gd;

    //AudioSourceを取得するための箱
    private AudioSource audioSource;

    //BGMの音量を調整するためのやつ
    private float volume;
    
    //ここで使うゲームオーバーが出たかどうかの判定
    private bool AM_SAGO;

    //ここで使うゲームクリアが出たかどうかの判定
    private bool AM_SAGC;

    //ここで使うパーフェクトクリアが出たかどうかの判定
    private bool AM_SAPC;

    void Start()
    {
        //自分にアタッチされているAudioSourceを取得
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        AM_SAGO = gd.GetComponent<GameDirector>().SAGO;
        AM_SAPC = gd.GetComponent<GameDirector>().SAPC;
        AM_SAGC = gd.GetComponent<GameDirector>().SAGC;
        

        //ゲームオーバーもゲームクリアも出ていない時BGMを流す
        if(AM_SAGO == false && AM_SAPC == false && AM_SAGC == false)
        {
            audioSource.volume = 0.1f;
        }
        else //それ以外ならBGMの音量を0にする
        {
            audioSource.volume = 0f;
        }
    }
}
