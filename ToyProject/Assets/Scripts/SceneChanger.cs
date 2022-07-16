using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using GooglePlayGames;
using GooglePlayGames.BasicApi;

public class SceneChanger : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        //구성 및 초기화
        //PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        //디버깅에 권장됨
        PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform 활성화
        PlayGamesPlatform.Activate();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void OnClickLogin()
    {
        if (PlayGamesPlatform.Instance.IsAuthenticated() == false)
        { 
            Social.localUser.Authenticate((bool isSuccess, string errorMsz) =>
           {
               Debug.Log("login attemp" + isSuccess + errorMsz);
               //to do
               SceneManager.LoadScene("Scenes/Lobby"); 
           });
        } 
    }

    public void OnClickLogout()
    {
       // ((PlayGamesPlatform)Social.Active). ();
    }

    public void OnClickGameStart()
    {
        SceneManager.LoadScene("Scenes/MainGame");     
    }
}
