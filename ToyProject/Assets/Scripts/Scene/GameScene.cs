using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI; 
using TMPro;
using Cinemachine;

public class GameScene : BaseScene
{
    [SerializeField]
    MonsterSpawner _spawnerPrefab;
    
    private float _elapsedTime;
    public float ElapsedTime { get { return _elapsedTime; } }
    
    private float _gameTime = 90.0f;
    private float _spawnTime = 1.0f;
    UIGameControl _uiGameControl;

    private CinemachineVirtualCamera _vcam;
    private GameObject _player;
    public GameObject Player { get { return _player; } }

    private MonsterSpawner _spawner;
    private int _spawnedCount = 0;
     
    protected override bool Init()
    {
        DebugWrapper.Log("GameScene < Init Begin");
        if (base.Init() == false)
        {
            return false;
        }

        SceneType = Define.Scene.GameScene; 

        InitPlayer();
        InitUI();
         
        InitCamera();
        InitObjects();

        _elapsedTime = _gameTime = 90.0f;
        StartCoroutine(TimeEndCheck());

        DebugWrapper.Log("GameScene < Init End");
        return true;
    }

    private void InitUI()
    {
        _uiGameControl = Managers.UI.PushPopupUI<UIGameControl>(); 
         
        Managers.UI.PushPopupUI<UIEffectSelect>();
        Managers.UI.HidePopupUI<UIEffectSelect>();

        Managers.UI.PushPopupUI<UIGameResult>();
        Managers.UI.HidePopupUI<UIGameResult>();
    }

    private void InitPlayer()
    {
        _player = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(Define.PrefabTypeName.PLAYER), this.transform);
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
        GameObject prefab = Managers.Prefab.GetPrefab(Define.PrefabTypeName.PROJECTILE);
        Managers.Pool.CreatePool(prefab, Define.PROJECTILE_POOL_COUNT);

        for (int i = 0; i < Define.HIT_PARTICLE_COUNT; ++i)
        {
            GameObject hitParticle = Managers.Prefab.GetPrefab(Define.PrefabTypeName.PARTICLE_HIT_1 + i);
            Managers.Pool.CreatePool(hitParticle, Define.HIT_PARTICLE_POOL_COUNT); 
        }
        
        _spawner = Instantiate(_spawnerPrefab);
        _spawner.transform.position = Vector3.zero;

        GameObject budy = Managers.Resource.Instantiate(Managers.Prefab.GetPrefab(Define.PrefabTypeName.BUDY), this.transform);
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

        _uiGameControl.UpdateGameTime($"{min.ToString()} : {sec.ToString()}"); 
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

        // �����ϰ� ������ ������ �ð��� ����
        float nextSpawnTime = Random.Range(0.5f, 1.5f);
        int spawnCount = Random.Range(1, 5);
        _spawnedCount += spawnCount;

        _spawnTime = nextSpawnTime;

        for (int i = 0; i < spawnCount; ++i)
        {
            Toy.Pooled<Monster> pooledMonster = _spawner.Spawn();
            pooledMonster.Object.OnDyingAnimationDone += _ =>
            {
                if(this != null)
                    RefreshWaveCount(pooledMonster);
            };
        }

        _uiGameControl.UpdateWaveCount(_spawner.SpawnedCount);
    }

    private void RefreshWaveCount(Toy.Pooled<Monster> pooledMonster)
    {
        pooledMonster.Release();

        int nRemainMonsterCount = _spawner.SpawnedCount; 
        _uiGameControl.UpdateWaveCount(nRemainMonsterCount); 

        if( nRemainMonsterCount == 0 && _spawnedCount >= Define.STAGE_WAVE_COUNT )
        {
            Managers.Game.GamePause(true);
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
    public void ShowGameResult()
    {
        // �ҿ�ð��� Init�Լ����� �������� ���� �ð����� �ʱ�ȭ,
        // �Լ��� ȣ��Ǿ��� ��, _gameTime�� 0���� ū ���̶�� ����� ��.
        _elapsedTime -= _gameTime;

        Managers.UI.HidePopupUI<UIGameControl>();
        Managers.UI.HidePopupUI<UIEffectSelect>();
        Managers.UI.ShowPopupUI<UIGameResult>(); 
    }

    private IEnumerator TimeEndCheck()
    {
        yield return new WaitForSeconds(_gameTime);

        if (Managers.Game.IsGamePaused) { yield break; }

        int nRemainMonsterCount = _spawner.SpawnedCount; 
        _uiGameControl.UpdateWaveCount(nRemainMonsterCount);

        Managers.Game.GamePause(true);  

        ShowGameResult();   
    }
}