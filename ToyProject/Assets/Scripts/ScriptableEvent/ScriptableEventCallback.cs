using System;

namespace Inferno
{
    [Serializable]
    public class ScriptableEventCallback : 
        ScriptableEventCallbackBase<IScriptableEventListener>,
        IScriptableEventListener,
        IScriptableEventCallback
    {
        public event Action OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener Listener => this;
        
        void IScriptableEventListener.OnEventRaised()
        {
            OnEventRaised.Invoke();
        }
    }
    
    [Serializable]
    public class ScriptableEventCallback<TArg0> : 
        ScriptableEventCallbackBase<IScriptableEventListener<TArg0>>,
        IScriptableEventListener<TArg0>,
        IScriptableEventCallback<TArg0>
    {
        public event Action<TArg0> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0> Listener => this;
        
        void IScriptableEventListener<TArg0>.OnEventRaised(TArg0 arg0)
        {
            OnEventRaised.Invoke(arg0);
        }
    }
    
    [Serializable]
    public class ScriptableEventCallback<TArg0, TArg1> : 
        ScriptableEventCallbackBase<IScriptableEventListener<TArg0, TArg1>>,
        IScriptableEventListener<TArg0, TArg1>,
        IScriptableEventCallback<TArg0, TArg1>
    {
        public event Action<TArg0, TArg1> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0, TArg1> Listener => this;
        
        void IScriptableEventListener<TArg0, TArg1>.OnEventRaised(TArg0 arg0, TArg1 arg1)
        {
            OnEventRaised.Invoke(arg0, arg1);
        }
    }
    
    [Serializable]
    public class ScriptableEventCallback<TArg0, TArg1, TArg2> : 
        ScriptableEventCallbackBase<IScriptableEventListener<TArg0, TArg1, TArg2>>,
        IScriptableEventListener<TArg0, TArg1, TArg2>,
        IScriptableEventCallback<TArg0, TArg1, TArg2>
    {
        public event Action<TArg0, TArg1, TArg2> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0, TArg1, TArg2> Listener => this;
        
        void IScriptableEventListener<TArg0, TArg1, TArg2>.OnEventRaised(TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            OnEventRaised.Invoke(arg0, arg1, arg2);
        }
    }
    
    [Serializable]
    public class ScriptableEventCallback<TArg0, TArg1, TArg2, TArg3> : 
        ScriptableEventCallbackBase<IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>>,
        IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>,
        IScriptableEventCallback<TArg0, TArg1, TArg2, TArg3>
    {
        public event Action<TArg0, TArg1, TArg2, TArg3> OnEventRaised = delegate { };
        
        protected sealed override IScriptableEventListener<TArg0, TArg1, TArg2, TArg3> Listener => this;
        
        void IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>.OnEventRaised(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            OnEventRaised.Invoke(arg0, arg1, arg2, arg3);
        }
    }
}