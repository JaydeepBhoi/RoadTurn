using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class GameOver : MonoBehaviour
{

    [SerializeField] private Button ReplyaBtn;
    public static bool ispawnObj = false;



    void Start()
    {

        ReplyaBtn.onClick.AddListener(HomeBtn);


    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HomeBtn()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        ScreenManager.instance.ShowNextScreen(ScreenType.LevelProgress);

    }

}

