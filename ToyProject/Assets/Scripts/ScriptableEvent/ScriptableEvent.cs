namespace Inferno
{
    public abstract class ScriptableEvent :
        ScriptableEventBase<IScriptableEventListener>,
        IScriptableEventRaiser
    {
        public void Raise()
        {
            foreach (var listener in Listeners)
                listener.OnEventRaised();
        }
    }

    public abstract class ScriptableEvent<TArg0> :
        ScriptableEventBase<IScriptableEventListener<TArg0>>,
        IScriptableEventRaiser<TArg0>
    {
        public void Raise(TArg0 arg0)
        {
            foreach (var listener in Listeners)
                listener.OnEventRaised(arg0);
        }
    }

    public abstract class ScriptableEvent<TArg0, TArg1> :
        ScriptableEventBase<IScriptableEventListener<TArg0, TArg1>>,
        IScriptableEventRaiser<TArg0, TArg1>
    {
        public void Raise(TArg0 arg0, TArg1 arg1)
        {
            foreach (var listener in Listeners)
                listener.OnEventRaised(arg0, arg1);
        }
    }
    
    public abstract class ScriptableEvent<TArg0, TArg1, TArg2> :
        ScriptableEventBase<IScriptableEventListener<TArg0, TArg1, TArg2>>,
        IScriptableEventRaiser<TArg0, TArg1, TArg2>
    {
        public void Raise(TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            foreach (var listener in Listeners)
                listener.OnEventRaised(arg0, arg1, arg2);
        }
    }
    
    public abstract class ScriptableEvent<TArg0, TArg1, TArg2, TArg3> :
        ScriptableEventBase<IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>>,
        IScriptableEventRaiser<TArg0, TArg1, TArg2, TArg3>
    {
        public void Raise(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            foreach (var listener in Listeners)
                listener.OnEventRaised(arg0, arg1, arg2, arg3);
        }
    }
}