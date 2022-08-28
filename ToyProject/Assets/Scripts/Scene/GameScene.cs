using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using UnityEngine.SceneManagement;
using TMPro;
using Cinemachine;

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
    private float _gameTime = 300.0f;
    private float _spawnTime = 1.0f;
    UIGameControl _uiGameControl;

    private CinemachineVirtualCamera _vcam;
    private GameObject _player;
    public GameObject Player { get { return _player; } }

    private Spawner _spawner;
    protected override bool Init()
    {
        Debug.Log("GameScene < Init Begin");
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.Game;

        InitUI();
        InitPlayer();

        // 카메라 초기화는 플레이어 초기화 이후에 실행되어야 합니다!
        InitCamera();
        InitObjects();

        Debug.Log("GameScene < Init End");
        return true;
    }

    private void InitUI()
    {
        _uiGameControl = Managers.UI.PushPopupUI<UIGameControl>();

        // 생성 후 안보이도록. 
        Managers.UI.PushPopupUI<UIEffectSelect>();
        Managers.UI.HidePopupUI<UIEffectSelect>();
    }

    private void InitPlayer()
    {
        _player = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(PrefabTypeName.Player), this.transform);
        _player.transform.position = _sceneData.playerPos;

        Managers.Game.Player = _player;
    }

    private void InitCamera()
    {
        _vcam = FindObjectOfType<CinemachineVirtualCamera>();
        _vcam.m_Follow = _player.transform;
        _vcam.m_LookAt = _player.transform;
    }
    private void InitObjects()
    {
        _spawner = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(PrefabTypeName.Spawner), this.transform).GetComponent<Spawner>();
        _spawner.transform.position = Vector3.zero;
    }

    public void Update()
    {
        UpdateGameTime();
        SpawnMonster();
    }
    private void UpdateGameTime()
    {
        _gameTime -= Time.deltaTime;
        if (_gameTime < 0)
        {
            _gameTime = 0.0f;
            // SceneManager.LoadScene("Scenes/Lobby");
        }

        int min = (int)(_gameTime / 60.0f);
        int sec = (int)(_gameTime - min * 60.0f);
         
        _uiGameControl.UpdateGameTime(min.ToString() + " : " + sec.ToString()); 
    }

    private void SpawnMonster()
    {
        if (_spawner == null) { return; }

        if (_gameTime <= 0.0f)
        {
            return;
        }
        _spawnTime -= Time.deltaTime;
        if (_spawnTime > 0.0f)
        {
            return;
        }

        // 랜덤하게 다음에 생성할 시간을 지정
        float nextSpawnTime = Random.Range(0.5f, 1.5f);
        int spawnCount = Random.Range(1, 5);

        _spawnTime = nextSpawnTime;

        for (int i = 0; i < spawnCount; ++i)
        {
            _spawner.Spawn();
        }

        _uiGameControl.UpdateWaveCount("Wave : " + _spawner.GetMonsterCount().ToString()); 
    }

    public void RefreshWaveCount(GameObject gameObject)
    {
        _spawner.RemoveObject(gameObject);

        _uiGameControl.UpdateWaveCount("Wave : " + _spawner.GetMonsterCount().ToString()); 
    }
}