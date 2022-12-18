namespace Inferno
{
    public interface IScriptableEventRaiser
    {
        void Raise();
    }
    
    public interface IScriptableEventRaiser<TArg0>
    {
        void Raise(TArg0 arg0);
    }
    
    public interface IScriptableEventRaiser<TArg0, TArg1>
    {
        void Raise(TArg0 arg0, TArg1 arg1);
    }
    
    public interface IScriptableEventRaiser<TArg0, TArg1, TArg2>
    {
        void Raise(TArg0 arg0, TArg1 arg1, TArg2 arg2);
    }
    
    public interface IScriptableEventRaiser<TArg0, TArg1, TArg2, TArg3>
    {
        void Raise(TArg0 arg0, TArg1 arg1, TArg2 arg2, TArg3 arg3);
    }
}