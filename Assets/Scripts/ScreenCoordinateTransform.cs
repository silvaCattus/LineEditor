using UnityEngine;

public class ScreenCoordinateTransform : MonoBehaviour
{
    //main camera
    [SerializeField] private Camera _camera;

    //перевод в мировые координаты из координат экрана
    public Vector2 GetWorldCoordinate(Vector2 screenPoint)
    {
        screenPoint = new Vector3(screenPoint.x, screenPoint.y, 1);
        return _camera.ScreenToWorldPoint(screenPoint);
    }
}
