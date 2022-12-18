namespace Inferno
{
    public interface IScriptableEventListener
    {
        void OnEventRaised();
    }
    
    public interface IScriptableEventListener<TArg0>
    {
        void OnEventRaised(TArg0 arg0);
    }
    
    public interface IScriptableEventListener<TArg0, TArg1>
    {
        void OnEventRaised(TArg0 arg0, TArg1 arg1);
    }
    
    public interface IScriptableEventListener<TArg0, TArg1, TArg2>
    {
        void OnEventRaised(TArg0 arg0, TArg1 arg1, TArg2 arg2);
    }
    
    public interface IScriptableEventListener<TArg0, TArg1, TArg2, TArg3>
    {
        void OnEventRaised(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
    }
}