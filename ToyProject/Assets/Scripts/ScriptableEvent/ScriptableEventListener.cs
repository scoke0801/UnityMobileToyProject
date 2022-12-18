using System;
using UnityEngine;
using UnityEngine.Events;

namespace Inferno
{
    public abstract class ScriptableEventListener : 
        ScriptableEventListenerBase<IScriptableEventListener>,
        IScriptableEventListener,
        IScriptableEventCallback
    {
        [SerializeField]
        UnityEvent _onEventRaised;
        
        public event Action OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener Listener => this;
        
        void IScriptableEventListener.OnEventRaised()
        {
            _onEventRaised.Invoke();
            OnEventRaised.Invoke();
        }
    }
    
    public abstract class ScriptableEventListener<TArg0> : 
        ScriptableEventListenerBase<IScriptableEventListener<TArg0>>,
        IScriptableEventListener<TArg0>,
        IScriptableEventCallback<TArg0>
    {
        [SerializeField]
        UnityEvent<TArg0> _onEventRaised;
        
        public event Action<TArg0> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0> Listener => this;
        
        void IScriptableEventListener<TArg0>.OnEventRaised(TArg0 arg0)
        {
            _onEventRaised.Invoke(arg0);
            OnEventRaised.Invoke(arg0);
        }
    }
    
    public abstract class ScriptableEventListener<TArg0, TArg1> : 
        ScriptableEventListenerBase<IScriptableEventListener<TArg0, TArg1>>,
        IScriptableEventListener<TArg0, TArg1>,
        IScriptableEventCallback<TArg0, TArg1>
    {
        [SerializeField]
        UnityEvent<TArg0, TArg1> _onEventRaised;
        
        public event Action<TArg0, TArg1> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0, TArg1> Listener => this;
        
        void IScriptableEventListener<TArg0, TArg1>.OnEventRaised(TArg0 arg0, TArg1 arg1)
        {
            _onEventRaised.Invoke(arg0, arg1);
            OnEventRaised.Invoke(arg0, arg1);
        }
    }
    
    public abstract class ScriptableEventListener<TArg0, TArg1, TArg2> : 
        ScriptableEventListenerBase<IScriptableEventListener<TArg0, TArg1, TArg2>>,
        IScriptableEventListener<TArg0, TArg1, TArg2>,
        IScriptableEventCallback<TArg0, TArg1, TArg2>
    {
        [SerializeField]
        UnityEvent<TArg0, TArg1, TArg2> _onEventRaised;
        
        public event Action<TArg0, TArg1, TArg2> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0, TArg1, TArg2> Listener => this;
        
        void IScriptableEventListener<TArg0, TArg1, TArg2>.OnEventRaised(TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            _onEventRaised.Invoke(arg0, arg1, arg2);
            OnEventRaised.Invoke(arg0, arg1, arg2);
        }
    }
    
    public abstract class ScriptableEventListener<TArg0, TArg1, TArg2, TArg3> : 
        ScriptableEventListenerBase<IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>>,
        IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>,
        IScriptableEventCallback<TArg0, TArg1, TArg2, TArg3>
    {
        [SerializeField]
        UnityEvent<TArg0, TArg1, TArg2, TArg3> _onEventRaised;
        
        public event Action<TArg0, TArg1, TArg2, TArg3> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0, TArg1, TArg2, TArg3> Listener => this;
        
        void IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>.OnEventRaised(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            _onEventRaised.Invoke(arg0, arg1, arg2, arg3);
            OnEventRaised.Invoke(arg0, arg1, arg2, arg3);
        }
    }
}