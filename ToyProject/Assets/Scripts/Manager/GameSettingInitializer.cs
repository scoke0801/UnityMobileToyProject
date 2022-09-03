using UnityEngine;

namespace Manager
{
    public static class GameSettingInitializer
    {
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        static void Initialize()
        {
            // unity editor 내에서는 플레이 모드 최초 진입 시에만 수행됨.
            
            // project setting
            Application.targetFrameRate = 60;
        }
    }
}