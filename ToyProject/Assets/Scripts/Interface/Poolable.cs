using System.Collections;
using UnityEngine;

public class Poolable : MonoBehaviour
{
    private bool _isUsing;
    public bool IsUsing
    {
        get { return _isUsing; }
        set { _isUsing = value; }
    }
}