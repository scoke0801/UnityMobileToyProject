using System;
using UnityEngine;

namespace Inferno
{
    [Serializable]
    public class ScriptableEventRaiser : IScriptableEventRaiser
    {
        [SerializeField]
        ScriptableEvent _scriptableEvent;

        public void Raise()
        {
            _scriptableEvent.Raise();
        }
    }
    
    [Serializable]
    public class ScriptableEventRaiser<TArg0> : IScriptableEventRaiser<TArg0>
    {
        [SerializeField]
        ScriptableEvent<TArg0> _scriptableEvent;

        public void Raise(TArg0 arg0)
        {
            _scriptableEvent.Raise(arg0);
        }
    }
    
    [Serializable]
    public class ScriptableEventRaiser<TArg0, TArg1> : IScriptableEventRaiser<TArg0, TArg1>
    {
        [SerializeField]
        ScriptableEvent<TArg0, TArg1> _scriptableEvent;

        public void Raise(TArg0 arg0, TArg1 arg1)
        {
            _scriptableEvent.Raise(arg0, arg1);
        }
    }
    
    [Serializable]
    public class ScriptableEventRaiser<TArg0, TArg1, TArg2> : IScriptableEventRaiser<TArg0, TArg1, TArg2>
    {
        [SerializeField]
        ScriptableEvent<TArg0, TArg1, TArg2> _scriptableEvent;

        public void Raise(TArg0 arg0, TArg1 arg1, TArg2 arg2)
        {
            _scriptableEvent.Raise(arg0, arg1, arg2);
        }
    }
    
    [Serializable]
    public class ScriptableEventRaiser<TArg0, TArg1, TArg2, TArg3> : IScriptableEventRaiser<TArg0, TArg1, TArg2, TArg3>
    {
        [SerializeField]
        ScriptableEvent<TArg0, TArg1, TArg2, TArg3> _scriptableEvent;

        public void Raise(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3)
        {
            _scriptableEvent.Raise(arg0, arg1, arg2, arg3);
        }
    }
}