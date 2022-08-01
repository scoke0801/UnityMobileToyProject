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
        // ���� ���� ���� ��ü���� Player�� ���� ã�� �� �ֵ���
        return playerObject;
    }
    public Player GetPlayer()
    {
        // ���� ���� ���� ��ü���� Player�� ���� ã�� �� �ֵ���
        return player;
    }
}
