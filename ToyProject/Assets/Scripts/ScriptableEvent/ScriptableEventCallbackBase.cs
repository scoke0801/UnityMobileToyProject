using UnityEngine;

namespace Inferno
{
    public abstract class ScriptableEventCallbackBase<TScriptableEventListenerInterface>
    {
        [SerializeField]
        ScriptableEventListenerRegister<TScriptableEventListenerInterface> _listenerRegister;

        [SerializeField]
        string _listenerName = string.Empty;
        
        protected abstract TScriptableEventListenerInterface Listener { get; }

        public string ListenerName
        {
            get => _listenerName;
            set => _listenerName = value;
        }
        
        public override string ToString() => _listenerName;
        
        public void RegisterCallback()
        {
            _listenerRegister.AddListener(Listener);
        }

        public void DeregisterCallback()
        {
            _listenerRegister.RemoveListener(Listener);
        }
    }
}