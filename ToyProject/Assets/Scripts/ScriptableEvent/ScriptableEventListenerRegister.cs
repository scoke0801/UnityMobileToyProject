using System;
using UnityEngine;

namespace Inferno
{
    [Serializable]
    public class ScriptableEventListenerRegister<TScriptableEventListener>
        : IScriptableEventListenerRegister<TScriptableEventListener>
    {
        [SerializeField]
        ScriptableEventBase<TScriptableEventListener> _scriptableEvent;

        public void AddListener(TScriptableEventListener listener)
        {
            _scriptableEvent.AddListener(listener);
        }

        public void RemoveListener(TScriptableEventListener listener)
        {
            _scriptableEvent.RemoveListener(listener);
        }
    }
}