using System.Collections;
using UnityEngine;

enum SceneEnterTriggerType
{
    NONE = -1,
    SHOP,
    GAME,
}

public class LobbyEnterHelper : MonoBehaviour
{
    [SerializeField] SceneEnterTriggerType sceneEnterTrigerType;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    private void OnTriggerEnter(Collider other)
    {
        switch (sceneEnterTrigerType)
        {
            case SceneEnterTriggerType.SHOP:
                {
                    Debug.Log("OnTriggerEnter < case SceneEnterTriggerType.SHOP");
                }break;
            case SceneEnterTriggerType.GAME:
                { 
                }break;
            default:
                { 
                }break;
        }
    }
}
 