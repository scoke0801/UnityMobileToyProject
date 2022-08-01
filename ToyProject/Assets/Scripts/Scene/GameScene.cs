using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;

public class GameScene : Scene
{
    public TextMeshProUGUI remainTimeText;
    public TextMeshProUGUI remainMonsterText;
   
    
    private float gameTime = 300.0f;
    private float spawnTime = 1.0f;

    public Spawner spawner;

    Util util;

    public GameScene(GameObject playerObject, CamFollow camFollow ) : base( playerObject, camFollow )
    {
        // util = new Util(mainCamera, 10.0f, 10.0f); 
        spawner = GameObject.Find("Spawner").GetComponent<Spawner>();

        GameObject canvas = GameObject.Find("Canvas");
        remainTimeText = canvas.transform.Find("RemainTime").GetComponent<TextMeshProUGUI>(); 
        remainMonsterText = canvas.transform.Find("ReamainMonsterCount").GetComponent<TextMeshProUGUI>();

        gameTime = 15.0f;
        spawnTime = 0.0f;
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
        if (remainTimeText == null) { return; }

        gameTime -= Time.deltaTime;
        if (gameTime < 0) 
        {
            gameTime = 0.0f;
            SceneManager.LoadScene("Scenes/Lobby");
        }

        int min = (int)(gameTime / 60.0f);
        int sec = (int)(gameTime - min * 60.0f);
        remainTimeText.text = min.ToString() + " : " + sec.ToString(); 
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

        remainMonsterText.text = "Wave : " + spawner.GetMonsterCount().ToString();
    }

    public void RefreshWaveCount(GameObject gameObject)
    {
        spawner.RemoveObject(gameObject);
        remainMonsterText.text = "Wave : " + spawner.GetMonsterCount().ToString();
    }
}
