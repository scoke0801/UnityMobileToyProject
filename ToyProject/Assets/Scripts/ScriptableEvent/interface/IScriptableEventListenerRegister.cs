namespace Inferno
{
    public interface IScriptableEventListenerRegister<TScriptableEventListener>
    {
        void AddListener(TScriptableEventListener listener);
        void RemoveListener(TScriptableEventListener listener);
    }
}