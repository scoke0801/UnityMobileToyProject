using UnityEngine;
using UnityEngine.UI;
using System.Collections;

namespace Toy
{ 
    public static class ScreenFaderEx
    {
        public static ScreenFader GetObject()
        {
            GameObject newObject = Object.Instantiate(Managers.Prefab.GetPrefab(Define.PrefabTypeName.SCREEN_FADER));
            if(newObject != null)
            {
                return newObject.GetComponent<ScreenFader>();
            }
            return null;
        }
    }

    public class ScreenFader : MonoBehaviour
    {
        [SerializeField]
        private Image _image;

        private Color _color;

        private Define.FadeType _type; 
        private float _time;
        private float _speed;
        private float _timePerUpdate;

        private System.Action _callback;

        private void Awake()
        {
            _color = _image.color; 
        }
        public void SetUp(Define.FadeType type, float time, float timePerUpdate, System.Action callback)
        {
            _type = type; 
            _time = time;
            
            _timePerUpdate = time / timePerUpdate;

            _callback = callback;
             
            _color = _image.color;

            switch (type)
            {
                case Define.FadeType.FADE_TYPE_IN:
                    {
                        _color.a = 0.0f;
                        _image.color = _color;
                        StartCoroutine(FadeIn());
                    }
                    break;
                case Define.FadeType.FADE_TYPE_OUT:
                    { 
                        _color.a = 1.0f;
                        _image.color = _color;
                        StartCoroutine(FadeOut());
                    }break;
                default:
                    {
                        DebugWrapper.Assert(false, $"ScreenFader::Setup < Not allowed fade type < {type}");
                    }break;
            } 
        }
         
        private IEnumerator FadeIn()
        {
            float progress = 0.0f; 

            while (true)
            {
                if (progress > 1.0f)
                {
                    _callback?.Invoke();
                    Destroy(this);
                    yield break;
                }

                progress += _timePerUpdate;
                _color.a += _timePerUpdate;
                _image.color = _color;

                yield return new WaitForSeconds(_timePerUpdate); 
            } 
        }

        private IEnumerator FadeOut()
        {
            float progress = 0.0f;

            while (true)
            {
                if (progress > 1.0f)
                { 
                    _callback?.Invoke();
                    Destroy(this);
                    yield break;
                }

                progress += _timePerUpdate;
                _color.a -= _timePerUpdate;
                _image.color = _color;

                yield return new WaitForSeconds(_timePerUpdate);
            }
        }
    }
}