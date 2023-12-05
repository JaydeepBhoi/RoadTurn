using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelComplete : MonoBehaviour
{

    [SerializeField] private Button HomeButton;
    public static bool ispawnObj = false;



    void Start()
    {

        HomeButton.onClick.AddListener(HomeBtn);

     //   GameManager.instance.StateManage(GameState.MainScreen);
    }

    // Update is called once per frame
    void Update()
    {

    }

    public void HomeBtn()
    {
        LevelManager.targetLevelNumber++;
        LevelDataHandler.instance.levelManager.LoadLevelPrefab();
        ScreenManager.instance.ShowNextScreen(ScreenType.LevelProgress);
        GameManager.instance.StateManage(GameState.GamePlay);
        

    }

}