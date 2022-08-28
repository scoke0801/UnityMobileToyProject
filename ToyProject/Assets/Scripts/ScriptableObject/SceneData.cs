using UnityEditor;
using UnityEngine;



[CreateAssetMenu(menuName = "Scriptable/SceneData", fileName = "Scene Data")]
public class SceneData : ScriptableObject
{
    public Vector3 playerPos = new Vector3(0,0,0);

}
 