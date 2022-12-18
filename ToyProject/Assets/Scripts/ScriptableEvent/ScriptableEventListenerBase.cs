using UnityEngine;

namespace Inferno
{
    public abstract class ScriptableEventListenerBase<TScriptableEventListenerInterface> : MonoBehaviour
    {
        [SerializeField]
        ScriptableEventListenerRegister<TScriptableEventListenerInterface> _listenerRegister;

        protected abstract TScriptableEventListenerInterface Listener { get; }
        
        void OnEnable()
        {
            _listenerRegister.AddListener(Listener);
        }

        void OnDisable()
        {
            _listenerRegister.RemoveListener(Listener);
        }
    }
}