using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;

    [SerializeField] public CamFollow cam;  
    [SerializeField] public GameObject player;

    private void Awake()
    {
        instance = this; 
    }
    // Start is called before the first frame update
    void Start()
    {
        cam.SetTarget(player.transform, CamFollow.State.Tracking);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public GameObject GetPlayer()
    {
        // 게임 월드 상의 객체들이 Player를 쉽게 찾을 수 있도록
        return player;
    }
}
