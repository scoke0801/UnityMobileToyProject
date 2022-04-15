using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance;
    public CamFollow cam;
    public GameObject player;

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
}
