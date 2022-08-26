using System.Collections;
using UnityEngine;
using System;

public struct TT{ };

public class Base
{ }

 
public class C1
{
    public enum Te { var1 }
}

public class C2
{
    public enum Te { var2 }
}

public class Derived : Base { }

namespace Assets.Scripts.Test
{
    public class TestModule : MonoBehaviour
    {
        private void Start()
        {  
        }
    }
}