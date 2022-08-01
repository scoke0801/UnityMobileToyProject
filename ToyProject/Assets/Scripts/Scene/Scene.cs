using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Scene
{
    public CamFollow camFollow;
    public GameObject playerObject;
    public Player player; 

    public Scene( GameObject playerObject, CamFollow camFollow )
    {
        this.playerObject = playerObject;
        this.camFollow = camFollow;
         
        player = playerObject.GetComponent<Player>();
        this.camFollow.SetTarget(player.transform, CamFollow.State.Tracking);
    }
    void Start()
    {

    }
     
    virtual public void Update()
    {

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
}
