using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

/*
#region prev
public class GameScene : Scene
{ 
    private float gameTime = 300.0f;
    private float spawnTime = 1.0f;

    public Spawner spawner;

    Util util;

    public GameScene(GameObject playerObject, CamFollow camFollow ) : base( playerObject, camFollow )
    {
        // util = new Util(mainCamera, 10.0f, 10.0f); 
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>(); 

        gameTime = 150.0f;
        spawnTime = 0.0f;
        Managers.UI.ShowPopupUI<UIGameControl>();
    }

    void Start()
    {
    }

    public override void Update()
    { 
        UpdateGameTime();
        SpawnMonster();
    }
    private void UpdateGameTime()
    { 
        gameTime -= Time.deltaTime;
        if (gameTime < 0) 
        {
            gameTime = 0.0f;
            SceneManager.LoadScene("Scenes/Lobby");
        }

        int min = (int)(gameTime / 60.0f);
        int sec = (int)(gameTime - min * 60.0f);
       // UIManager.instance.UpdateGameTime(min.ToString() + " : " + sec.ToString()); 
    }

    private void SpawnMonster()
    {
        if (spawner == null) { return; }

        if (gameTime <= 0.0f)
        {
            return;
        }

        spawnTime -= Time.deltaTime;
        if (spawnTime > 0.0f)
        {
            return;
        }

        // 랜덤하게 다음에 생성할 시간을 지정
        float nextSpawnTime = Random.Range(0.5f, 1.5f);
        int spawnCount = Random.Range(1, 5);

        spawnTime = nextSpawnTime;

        for (int i = 0; i < spawnCount; ++i)
        {
            spawner.Spawn();
        }
      //  UIManager.instance.UpdateRemainMonsterText("Wave : " + spawner.GetMonsterCount().ToString());
    }

    public void RefreshWaveCount(GameObject gameObject)
    {
        spawner.RemoveObject(gameObject);

      //  UIManager.instance.UpdateRemainMonsterText("Wave : " + spawner.GetMonsterCount().ToString()); 
    }
}
#endregion
*/
public class GameScene : BaseScene
{ 
    protected override bool Init()
    {
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.Game;
        Managers.UI.PushPopupUI<UIGameControl>(); 

        // 생성 후 안보이도록.
        Managers.UI.HidePopupUI<UIEffectSelect>(); 
        Managers.UI.ShowPopupUI<UIEffectSelect>();

        Debug.Log("GameScene < Init");

        //for (int i = 0; i < 10; i++)
          //  Managers.Resource.Instantiate("Goblin_Male");

        return true;
    }
}