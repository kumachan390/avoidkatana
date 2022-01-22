using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
public class StandbyController : MonoBehaviour
{
    /*ゲームの説明をするシーンの遷移と効果音を鳴らす*/

    [Header("ロードする時のスライダー")]
    public Slider slider;

    //シーン移動するまでの時間をスライダーで出すためのやつ
    public float progressTime;

    [Header("スタートの効果音")]
    public AudioClip start;

    //効果音を1回だけ鳴らす旗 /*trueなら鳴った、falseなら鳴ってない*/
    [System.NonSerialized]
    public bool StartAudio;

    //今回だとZキーが押されたと感知するための旗 /*trueの時は押された、falseの時は押されてない*/
    [System.NonSerialized]
    public bool CTStart;

    private void Start()
    {
        //スライダーのvalueを取得する
        progressTime = slider.GetComponent<Slider>().value;

        //progressTimeを初期化する
        progressTime = 0.0f;

        //sliderの最大値を4にする
        slider.maxValue = 4.0f;

        //sliderの最初の値を0にする
        slider.value = 0f;

        //旗を下げて初期化
        StartAudio = false;
        CTStart = false;
    }

    private void Update()
    {
        //Zキーが押されて感知する旗が揚がっていないなら
        if(Input.GetKeyDown(KeyCode.Z) && CTStart == false)
        {
            CTStart = true;
        }

        if (CTStart == true)
        {
            //現実の時間と同じ速さでvalueとprogressTimeの値を進める
            slider.value += Time.deltaTime;
            progressTime += Time.deltaTime;

            if(StartAudio == false)
            {
                //効果音を鳴らす
                AudioSource.PlayClipAtPoint(start, new Vector2(0,0));

                StartAudio = true;
            }

            //4秒経ったらシーン移動
            if (progressTime >= 4.0f)
            {
                SceneManager.LoadScene("GameScene");
            }
        }
    }
}
