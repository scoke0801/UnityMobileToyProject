using System.Collections.Generic;
using UnityEngine;

namespace Inferno
{
    public abstract class ScriptableEventBase<TScriptableEventListener> : 
        ScriptableObject, 
        IScriptableEventListenerRegister<TScriptableEventListener>
    {
        List<TScriptableEventListener> _listeners = new();

        protected IEnumerable<TScriptableEventListener> Listeners => _listeners;

#if UNITY_EDITOR
        List<string> _listenerStrings = new();      // show in inspector view (debug mode)
#endif

        public void AddListener(TScriptableEventListener listener)
        {
            if (_listeners.Contains(listener))
                return;
            
            _listeners.Add(listener);
            
#if UNITY_EDITOR
            string listenerString;
            if (listener is MonoBehaviour monoListener)
            {
                listenerString = monoListener.gameObject.name;
            }
            else if (listener is UnityEngine.Object unityObject)
            {
                listenerString = unityObject.name;
            }
            else
            {
                listenerString = listener.ToString();
            }
            
            _listenerStrings.Add(listenerString);
#endif
        }

        public void RemoveListener(TScriptableEventListener listener)
        {
            var index = _listeners.IndexOf(listener);
            if (index == -1)
                return;
            
            _listeners.RemoveAt(index);
#if UNITY_EDITOR
            _listenerStrings.RemoveAt(index);
#endif
        }
    }
}