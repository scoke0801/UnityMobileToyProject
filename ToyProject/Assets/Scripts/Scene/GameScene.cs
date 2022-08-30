using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Cinemachine;

public class GameScene : BaseScene
{
    private float _gameTime = 300.0f;
    private float _spawnTime = 1.0f;
    UIGameControl _uiGameControl;

    private CinemachineVirtualCamera _vcam;
    private GameObject _player;
    public GameObject Player { get { return _player; } }

    private Spawner _spawner;
    private int _spawnedCount = 0;

    bool _isGamePaused;
    public bool IsGamePaused { get { return _isGamePaused; }}

    protected override bool Init()
    {
        Debug.Log("GameScene < Init Begin");
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.Game;
        _isGamePaused = false;

        InitPlayer();
        InitUI();

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
        GameObject prefab = Managers.Prefab.GetPrefab(PrefabTypeName.Projectile);
        Managers.Pool.CreatePool(prefab, 50);

        _spawner = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(PrefabTypeName.Spawner), this.transform).GetComponent<Spawner>();
        _spawner.transform.position = Vector3.zero;

        GameObject budy = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(PrefabTypeName.Budy), this.transform);
        budy.GetComponent<TargetFollow>().target = _player;
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
        }

        int min = (int)(_gameTime / 60.0f);
        int sec = (int)(_gameTime - min * 60.0f);
         
        _uiGameControl.UpdateGameTime(min.ToString() + " : " + sec.ToString()); 
    }

    private void SpawnMonster()
    {
        if (_spawner == null) { return; }
        if (_spawnedCount > Define.STAGE_WAVE_COUNT) { return; }
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
        _spawnedCount += spawnCount;

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

        int nRemainMonsterCount = _spawner.GetMonsterCount();
        Debug.Log($"remain :{nRemainMonsterCount}, spawnedCount :{_spawnedCount}");
        _uiGameControl.UpdateWaveCount("Wave : " + nRemainMonsterCount.ToString()); 

        if( nRemainMonsterCount == 0 && _spawnedCount >= Define.STAGE_WAVE_COUNT )
        {
            _isGamePaused = true;
            Managers.UI.HidePopupUI<UIGameControl>();
            Managers.UI.ShowPopupUI<UIEffectSelect>();
        }
    }
    public void RefreshPlayerHeartText(Player gameObject)
    {
        //_uiGameControl.UpdateWaveCount("Wave : " + _spawner.GetMonsterCount().ToString());
    }
    public void RefreshPlayerAmmoText(int ammo)
    { 
        _uiGameControl.UpdateAmmoText(ammo);
    }
}