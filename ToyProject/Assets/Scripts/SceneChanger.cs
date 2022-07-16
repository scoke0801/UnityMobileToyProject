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
        //���� �� �ʱ�ȭ
        //PlayGamesPlatform.InitializeInstance(new PlayGamesClientConfiguration.Builder().Build());
        //����뿡 �����
        PlayGamesPlatform.DebugLogEnabled = true;
        //PlayGamesPlatform Ȱ��ȭ
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
