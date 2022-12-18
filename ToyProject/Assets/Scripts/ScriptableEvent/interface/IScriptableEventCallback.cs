using System;

namespace Inferno
{
    public interface IScriptableEventCallback
    {
        event Action OnEventRaised;
    }
    
    public interface IScriptableEventCallback<TArg0>
    {
        event Action<TArg0> OnEventRaised;
    }
    
    public interface IScriptableEventCallback<TArg0, TArg1>
    {
        event Action<TArg0, TArg1> OnEventRaised;
    }
    
    public interface IScriptableEventCallback<TArg0, TArg1, TArg2>
    {
        event Action<TArg0, TArg1, TArg2> OnEventRaised;
    }
    
    public interface IScriptableEventCallback<TArg0, TArg1, TArg2, TArg3>
    {
        event Action<TArg0, TArg1, TArg2, TArg3> OnEventRaised;
    }
}