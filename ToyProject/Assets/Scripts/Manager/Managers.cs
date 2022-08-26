using System.Collections;
using UnityEngine;
 
public class Managers : MonoBehaviour
{
    public static Managers _instance = null;
    public static Managers Instance { get { return _instance; } }

    private static ResourceManager _resourceManager = new ResourceManager();
    private static UIManager _uiManager = new UIManager();

    public static UIManager UI { get { return _uiManager; } } 
    public static ResourceManager Resource { get { Init(); return _resourceManager; } }

    void Start()
    {
        Init(); 
    }
     
    private static void Init()
    {
        if (_instance == null)
        {
            GameObject gameObject = GameObject.Find("@Managers");
            if (gameObject == null)
            {
                gameObject = new GameObject { name = "@Managers" };
            }
            _instance = Util.GetOrAddComponent<Managers>(gameObject);
            // DontDestroyOnLoad(go);

            //s_adsManager.Init();
            //s_iapManager.Init();
            //s_dataManager.Init();
            _resourceManager.Init();
            //s_sceneManager.Init();
            //s_soundManager.Init();

            Application.targetFrameRate = 60;
        }
    }
} 