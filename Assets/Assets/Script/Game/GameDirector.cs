using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameDirector : MonoBehaviour
{
    /*ゲームオーバーとゲームクリアの管理(特定の条件でパネルの表示)*/

    /*サウンドが一回なっても繰り返し鳴るから対処が必要*/

    [Header("プレイヤーの取得")]
    public GameObject pc;

    [Header("タイマーの取得")]
    public GameObject Tm;

    [Header("ゲームオーバーのパネルの取得")]
    public GameObject Gameover;

    [Header("ゲームクリアのパネルの取得")]
    public GameObject Gameclear;

    [Header("パーフェクトクリアしたときのパネルの取得")]
    public GameObject Perfectclear;

    [Header("ゲームオーバーサウンドの取得")]
    public AudioClip GO_Sound;

    [Header("ゲームクリアサウンドの取得")]
    public AudioClip GC_Sound;

    [Header("パーフェクトクリアサウンドの取得")]
    public AudioClip PC_Sound;

    //このクラスで使うためにプレイヤーコントローラーのHPを取得する
    private int GD_PNHP;

    //このクラスで使うためのプレイヤーの最大HPを取得する
    private int GD_PMHP;

    //制限時間が終わったか終わってないか　trueなら制限時間が無い、falseなら制限時間は残っている
    private bool GD_TE;

    //体力が0か0以上か　trueなら死んだ、falseなら生きてる
    [System.NonSerialized]
    public bool GOflag = false;

    //ゲームオーバー画面が出ているとき　trueなら出てる、falseなら出てない
    [System.NonSerialized]
    public bool SAGO;

    //ゲームクリア画面が出ているとき　trueなら出てる、falseなら出てない
    [System.NonSerialized]
    public bool SAGC;

    //パーフェクトクリア画面が出ているとき　trueなら出てる、falseなら出てない
    [System.NonSerialized]
    public bool SAPC;

    //ゲームオーバー音を1回だけ鳴らすための旗 /*trueなら鳴った、falseなら鳴ってない*/
    [System.NonSerialized]
    public bool GOAudio;

    //ゲームクリア音1回だけ鳴らすための旗 /*trueなら鳴った、falseなら鳴ってない*/
    [System.NonSerialized]
    public bool GCAudio;

    [System.NonSerialized]
    public bool PCAudio;

    void Start()
    {
        //最初はクリア画面もゲームオーバー画面も非表示
        Gameclear.SetActive(false);
        Gameover.SetActive(false);

        /*bool作り過ぎなのは分かってます。でも、後々他の方法を覚えていくので許してください*/
        //最初に全部旗を下げることで初期化される
        GOflag = false;
        GD_TE = false;
        SAGO = false;
        SAGC = false;
        SAPC = false;
        GOAudio = false;
        GCAudio = false;
        PCAudio = false;
    }

    void Update()
    {
        /*プレイヤーの体力が無くなったらゲームオーバー画面を出す*/
        /*解決！:)*/

        //プレイヤーの現在のHPを取得
        GD_PNHP =  pc.GetComponent<PlayerController>().P_NowHP;

        //プレイヤーの最大HPを取得
        GD_PMHP = pc.GetComponent<PlayerController>().P_MaxHP;

        //Timerの中の制限時間終了の旗を取得
        GD_TE = Tm.GetComponent<Timer>().TE;

        //プレイヤーの体力が0になったらフラグを上げる(死んだ)
        if (GD_PNHP <= 0)
        {
            GOflag = true;
        }
        //プレイヤーの体力が0じゃないならフラグはそのまま(生きてる)
        else
        {
            GOflag = false;
        }

        //死んで制限時間が残っているときココ
        if(GOflag == true && GD_TE == false)
        {
            //ゲームオーバーになったので旗を揚げる
            SAGO = true;
            GameOver();
        }
        //体力が減っていなくて制限時間がなくなったときココ
        else if (GD_PNHP == GD_PMHP && GD_TE == true)
        {
            //パーフェクトクリアなので旗を揚げる
            SAPC = true;
            PerfectClear();
        }
        //生きてて制限時間がなくなったときココ
        else if(GOflag == false && GD_TE == true)
        {
            //ゲームクリアになったので旗を揚げる
            SAGC = true;
            GameClear();
        }
        

        //ゲームオーバー画面が出ているときEを押すとタイトルに戻る
        if(SAGO == true)
        {
            if(GOAudio == false)
            {
                //ゲームオーバー音を出す
                AudioSource.PlayClipAtPoint(GO_Sound, new Vector2(0, 0));
                Debug.Log("鳴った");

                //効果音を1回だけ鳴らして旗を揚げる /*旗を1回揚げたらここの条件式には来れないので1回のみ*/
                GOAudio = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("TitleScene");
                SAGO = false;
            }
        }

        //パーフェクトクリア画面が出ているときEを押すとタイトルに戻る
        if (SAPC == true)
        {
            SAGC = false;

            if (PCAudio == false)
            {
                //パーフェクトクリア音を出す
                AudioSource.PlayClipAtPoint(PC_Sound, new Vector2(0, 0));

                //効果音を1回だけ鳴らして旗を揚げる /*1回のみ*/
                PCAudio = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("TitleScene");
                SAPC = false;
            }
        }

        //ゲームクリア画面が出ているときEを押すとタイトルに戻る
        if (SAGC == true)
        {
            if(GCAudio == false)
            {
                //ゲームクリア音を出す
                AudioSource.PlayClipAtPoint(GC_Sound, new Vector2(0, 0));
                Debug.Log("鳴った");

                //効果音を1回だけ鳴らして旗を揚げる /*旗を1回揚げたらここの条件式には来れないので1回のみ*/
                GCAudio = true;
            }

            if (Input.GetKeyDown(KeyCode.E))
            {
                SceneManager.LoadScene("TitleScene");
                SAGC = false;
            }
        }
    }

    void GameClear()
    {
        //プレイヤーの体力が残っていて制限時間が残っていないならゲームクリア画面を出す
        Gameclear.SetActive(true);
    }

    void PerfectClear()
    {
        //プレイヤーの体力が減っていなくて制限時間が残っていないならパーフェクトクリア画面を出す
        Perfectclear.SetActive(true);
    }

    void GameOver()
    {
        //プレイヤーの体力がゼロになって制限時間が残っているならゲームオーバー画面を出す
        Gameover.SetActive(true);
    }

    
}
