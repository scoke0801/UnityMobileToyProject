using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public CamFollow cam;  
    [SerializeField] public GameObject playerObject;
    public Player player;
    public Camera mainCamera;

    [SerializeField] public Text remainTimeText;
    [SerializeField] public Text remainMonsterText; 

    private float gameTime = 300.0f;
    private float spawnTime = 1.0f;

    [SerializeField] public Spawner spawner;

    Util util;
     
    // Start is called before the first frame update
    void Start()
    {
        instance = this;
        player = playerObject.GetComponent<Player>();

        util = new Util(mainCamera, 10.0f, 10.0f);

        cam.SetTarget(player.transform, CamFollow.State.Tracking);

        gameTime = 300.0f;
        spawnTime = 0.0f;

    }

    // Update is called once per frame
    void Update()
    {
        UpdateGameTime();
        SpawnMonster();

        // util.OnDrawGizmos();
    }
    private void OnDrawGizmosSelected()
    { 
        util.OnDrawGizmos();
    } 
    public GameObject GetPlayerObject()
    {
        // 게임 월드 상의 객체들이 Player를 쉽게 찾을 수 있도록
        return playerObject;
    }
    public Player GetPlayer()
    {
        // 게임 월드 상의 객체들이 Player를 쉽게 찾을 수 있도록
        return player;
    }
    private void UpdateGameTime()
    {
        if (remainTimeText == null) { return; }

        gameTime -= Time.deltaTime;
        if (gameTime < 0){ gameTime = 0.0f; }

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
        if( spawnTime > 0.0f )
        {
            return;
        }

        // 랜덤하게 다음에 생성할 시간을 지정
        float nextSpawnTime = Random.Range(0.5f, 1.5f);
        int spawnCount = Random.Range(1, 5);

        spawnTime = nextSpawnTime;

        for(int i = 0; i < spawnCount; ++i)
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
