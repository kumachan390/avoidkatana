using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ChooseBackController : MonoBehaviour
{
    [Header("選んでる難易度のカーソル")]
    public GameObject chooseBack;

    //
    private int cbPosition;

    void Start()
    {
        DontDestroyOnLoad(this);
    }

    
    void Update()
    {
        Transform myTf = this.transform;

        if (SceneManager.GetActiveScene().name == "Stand-byscene")
        {

            if (chooseBack.transform.position.y == 190 && Input.GetKeyDown(KeyCode.DownArrow))
            {
                myTf.Translate(-756, 0, 0);
            }

            if (chooseBack.transform.position.y == 0 && Input.GetKeyDown(KeyCode.UpArrow))
            {
                myTf.Translate(-756, 190, 0);
            }

            if (chooseBack.transform.position.y == 0 && Input.GetKeyDown(KeyCode.DownArrow))
            {
                myTf.Translate(-756, -190, 0);
            }

            if (chooseBack.transform.position.y == -190 && Input.GetKeyDown(KeyCode.UpArrow))
            {
                myTf.Translate(-756, 0, 0);
            }
        }
    }
}
