using UnityEngine;
using TMPro;

namespace Toy
{
    public class TimerText : MonoBehaviour
    {
        [SerializeField]
        TMP_Text _text;
        
        public void UpdateTimerText(float time)
        {
            int min = (int)time / 60;
            int sec = (int)time - min * 60;

            _text.text = $"{min, 2:00} : {sec, 2:00}"; 
        }
    }
}