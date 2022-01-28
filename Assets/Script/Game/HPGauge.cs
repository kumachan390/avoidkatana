using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HPGauge : MonoBehaviour
{
    /*プレイヤーの体力をプレイヤーから受け取り表示*/
    /*解決!*/

    [Header("プレイヤーの取得")]
    public GameObject HPG_pc;

    //HPゲージのスライダーを取得(GameObjectだと.valueが使えなかった)
    [Header("体力ゲージになるスライダーの取得")]
    public Slider hpGauge;

    //プレイヤーの現在のHPを参照するための箱
    [Header("プレイヤーの現在のHP")]
    public int HPG_PNHP;

    //プレイヤーの最大HPを参照するための箱
    [Header("プレイヤーの最大HP")]
    public int HPG_PMHP;

    void Start()
    {
        //ゲーム開始時にプレイヤーの最大HPを取得する
        HPG_PMHP = HPG_pc.GetComponent<PlayerController>().P_MaxHP;

        //HPゲージと取得したプレイヤーのHPを参照する
        hpGauge.maxValue = HPG_PMHP;
    }

    void Update()
    {
        //プレイヤーの現在のHPをマイフレーム取得する
        HPG_PNHP = HPG_pc.GetComponent<PlayerController>().P_NowHP;

        //HPゲージのvalueを現在のHPの値を参照して動かす
        hpGauge.value = HPG_PNHP;
    }
}
