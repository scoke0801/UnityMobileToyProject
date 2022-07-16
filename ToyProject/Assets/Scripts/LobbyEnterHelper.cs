using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement; 

enum SceneEnterTriggerType
{
    NONE = -1,
    SHOP,
    GAME,
    MANAGEMENT,
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
                    SceneManager.LoadScene("Scenes/MainGame");
                    Debug.Log("OnTriggerEnter < case SceneEnterTriggerType.GAME");
                }
                break;
            case SceneEnterTriggerType.MANAGEMENT: 
                {
                    Debug.Log("OnTriggerEnter < case SceneEnterTriggerType.MANAGEMENT");
                }
                break;
            default:
                { 
                }break;
        }
    }
}
 