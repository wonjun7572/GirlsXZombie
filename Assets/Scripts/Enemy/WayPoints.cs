using UnityEngine;

public class WayPoints : MonoBehaviour
{
    public static Transform[] points;

    private void Awake()
    {
        // Waypoints 의 자식들을 가져옴
        points = new Transform[transform.childCount];
        for (int i =0; i< points.Length; i++)
        {
            points[i] = transform.GetChild(i);
        }
    }
}
