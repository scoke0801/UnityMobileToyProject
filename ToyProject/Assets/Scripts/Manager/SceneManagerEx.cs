using System.Collections;
using UnityEngine; 
using UnityEngine.SceneManagement;

// SceneManager는 Unity에 이미 정의되어있으므로 Ex를 붙여서 구분!
public class SceneManagerEx
{
    private Define.Scene _curSceneType = Define.Scene.None;

    public Define.Scene CurrentSceneType
    {
        get
        {
            if (_curSceneType != Define.Scene.None)
            {
                return _curSceneType;
            }
            return CurrentScene.SceneType;
        }
        set { _curSceneType = value; }
    }

    public BaseScene CurrentScene 
    {
        get
        {
            return GameObject.Find("@Scene").GetComponent<BaseScene>(); 
        }
    }

    public void ChangeScene(Define.Scene type)
    {
        CurrentScene.Clear();

        _curSceneType = type;
        SceneManager.LoadScene(GetSceneName(type));
    }

    string GetSceneName(Define.Scene type)
    {
        string name = System.Enum.GetName(typeof(Define.Scene), type);
        char[] letters = name.ToLower().ToCharArray();
        letters[0] = char.ToUpper(letters[0]);
        return new string(letters);
    }
} 