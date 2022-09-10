using UnityEngine;

// TODO: 외부 Pool 클래스들과의 이름 충돌을 방지하기 위한 임시 namespace. 추후 변경 필요.
namespace Toy
{
    public class ManagedGameObjectPrefabPool : ManagedPrefabPool<GameObject>
    {
        public ManagedGameObjectPrefabPool(GameObject prefab, string name) : base(prefab, name)
        {
        }

        protected override GameObject GetGameObjectFromInstance(GameObject instance) => instance;
    }
}