using System;
 
public static class Managers
{
    ////////////////////////////////////////////////////////////////////////////
    #region manager instance 정의

    // TODO: 외부에서 Manager 객체들을 생성할 수 있는 문제점이 있음. Manager 객체들을 이 클래스 내에서만 생성해야 함을 명시해야 함.
    private static Lazy<ResourceManager> _resourceManager = new();
    private static Lazy<UIManager> _uiManager = new();
    private static Lazy<SceneManagerEx> _sceneManager = new();
    private static Lazy<PoolManager> _poolManager = new();
    private static Lazy<GameManager> _gameManager = new(); 

    #endregion
    ////////////////////////////////////////////////////////////////////////////

    ////////////////////////////////////////////////////////////////////////////
    #region manager property 정의

    public static UIManager UI => _uiManager.Value;
    public static ResourceManager Resource => _resourceManager.Value;
    public static SceneManagerEx Scene => _sceneManager.Value;
    public static PoolManager Pool => _poolManager.Value;
    public static GameManager Game => _gameManager.Value;
    public static PrefabManager Prefab => PrefabManager.instance;

    #endregion

    ////////////////////////////////////////////////////////////////////////////
} 