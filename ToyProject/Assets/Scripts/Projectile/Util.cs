using UnityEditor;
using UnityEngine;
  
public class Util : MonoBehaviour
{
    float width;
    float height;
    Camera gameCamera;
    public Util( Camera camera, float width, float height)
    {
        this.gameCamera = camera;
        this.width = width;
        this.height = height;
    }
     
    public void OnDrawGizmos()
    {
        Gizmos.color = Color.white;

        if (width <= 0 || height <= 0)
            return;
         
        for (float x = -50f; x < 60f; x += width)
        {
            Gizmos.DrawLine(
                new Vector3(Mathf.Floor(x / width) * width, 1.0f, 50.0f), 
                new Vector3(Mathf.Floor(x / width) * width, 1.0f, -50.0f));
        }

        for (float z = -50f; z < 60f; z += height)
        {
            Gizmos.DrawLine(
                new Vector3(50.0f, 1.0f, Mathf.Floor(z / height) * height),
                new Vector3(-50.0f, 1.0f, Mathf.Floor(z / height) * height));
        }
    } 
} 