using UnityEngine;
using UnityEngine.UI;

namespace Toy
{
    public class ScreenFader : MonoBehaviour
    {
        [SerializeField]
        Image _image;
        
        float _alpha;
        Define.FadeType _type;

        private void Awake()
        {
            _type = Define.FadeType.FADE_TYPE_IN;
        }
        private void OnEnable()
        {
            _alpha = 1.0f;
        }

        // Update is called once per frame
        void Update()
        {
            Color color = _image.color;
            color.a = _alpha;
            _image.color = color;

            if(_type == Define.FadeType.FADE_TYPE_IN)
            {
                FadeIn();
            }
            else 
            {
                FadeOut();
            }
        }

        void FadeIn()
        { 
            _alpha -= Time.deltaTime;
            if (_alpha >= 1.0f)
            {

            }  
        }

        void FadeOut()
        { 
            _alpha += Time.deltaTime;
            if (_alpha <= 0.0f)
            {

            }

        }
    }
}