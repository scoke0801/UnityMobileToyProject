using System.Collections;
using UnityEngine;
using System.Collections.Generic;  

public class Pool : MonoBehaviour
{
    public GameObject Original { get; private set; }
    public Transform Root { get; set; }

    Stack<Poolable> _poolStack = new Stack<Poolable>();

    public void Init(GameObject original, int count = 5)
    {
        Original = original;

        // 빈 오브젝트 생성. 
        Root = new GameObject().transform;
        Root.name = $"{original.name}_Root";

        // count 개수만큼 오브젝트들의 자식으로. 
        for (int index = 0; index < count; ++index)
        {
            Push(Create());

        }
    }
    Poolable Create()
    {
        GameObject gameObject = Object.Instantiate<GameObject>(Original);
        gameObject.name = Original.name; // 뒤에 붙는 (Clone) 없앰. 원본 프리팹과 이름 같게.
        return gameObject.GetOrAddComponent<Poolable>();
    }

    // 풀에 넣어주기 (오브젝트 비활성화)
    public void Push(Poolable poolable) 
    {
        if (poolable == null)
        {
            return;
        }

        poolable.transform.parent = Root;
        poolable.gameObject.SetActive(false);
        poolable.IsUsing = false;

        _poolStack.Push(poolable);
    }
    public Poolable Pop(Transform parent) // 풀로부터 꺼내오기 (오브젝트 활성화)
    {
        Poolable poolable;

        // 스택(대기상태)이 빈 크기 X 즉 하나라도 재활용 할 수 있는 애가 있다면 
        if (_poolStack.Count > 0)
        {
            poolable = _poolStack.Pop();
        }
        else // _poolStack.Count == 0
        {
            // 스택이 비어있는 경우, 객체 추가.
            poolable = Create();
        }

        // 활성화 
        poolable.gameObject.SetActive(true);  

        //// DontDestroyOnLoad 해제 용도
        //if (parent == null)
        //{
        //    poolable.transform.parent = Managers.Scene.CurrentScene.transform;
        //}

        // 파라미터로 받은 parent 를 부모로 설정
        poolable.transform.parent = parent; 
        poolable.IsUsing = true;

        return poolable;
    }
} 