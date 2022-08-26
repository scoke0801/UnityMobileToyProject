using System.Collections;
using UnityEngine;
 
public class Managers : MonoBehaviour
{
    ////////////////////////////////////////////////////////////////////////////
    #region manager instance 정의

    public static Managers _instance = null;

    private static ResourceManager _resourceManager = new ResourceManager();
    private static UIManager _uiManager = new UIManager();
    private static SceneManagerEx _sceneManager = new SceneManagerEx();
    private static PoolManager _poolManager = new PoolManager();

    #endregion
    ////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////
    #region manager property 정의
    public static Managers Instance { get { return _instance; } }
    public static UIManager UI { get { Init(); return _uiManager; } } 
    public static ResourceManager Resource { get { Init(); return _resourceManager; } }
    public static SceneManagerEx Scene { get { Init(); return _sceneManager; } }
    public static PoolManager Pool { get { Init(); return _poolManager; } }

    #endregion 
    ////////////////////////////////////////////////////////////////////////////

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
            _sceneManager.Init();
            //s_soundManager.Init();

            Application.targetFrameRate = 60;
        }
    }
} 