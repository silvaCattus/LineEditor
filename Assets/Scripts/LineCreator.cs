using UnityEngine;

public class LineCreator : MonoBehaviour
{
    //ограниченная ширина линии
    [SerializeField] [Range(10, 30)] private float _width;
    //массив линий, которые будут отрисовываться
    [SerializeField] private StraightLine[] _straightLines;
    //rect transform панели, в которой будем "чертить" линию
    [SerializeField] private RectTransform _sketchingPanelRT;

    //центр панели для "черчения"
    private Vector2 _centerOfPanel;
    //смещение  точки линии от центра панели для черчения
    private Vector2 _offsetPosition;


    //устанавливаем центр панели
    private void Start()
    {
        _centerOfPanel = transform.TransformPoint(_sketchingPanelRT.rect.center);
    }


    //принимаем точку клика (vector2), переводим в мировые координаты, в массив неотрисованных линий передаем смещение от центра панели
    public void SetPoint(Vector2 clickPosition)
    {
        clickPosition = GetWorldCoordinate(clickPosition);

        _offsetPosition = clickPosition - _centerOfPanel;

        foreach (var line in _straightLines)
        {
            LineRenderer lineRenderer = line.GetComponent<LineRenderer>();
            if (lineRenderer.positionCount < line.Vertexs)
            {
                line.SetWidth(_width);
                line.SetOffsetPosition(_offsetPosition);
            }
        }
    }

    //перевод в мировые координаты из координат экрана
    public static Vector2 GetWorldCoordinate(Vector2 screenPoint)
    {
        screenPoint = new Vector3(screenPoint.x, screenPoint.y, 1);
        return Camera.main.ScreenToWorldPoint(screenPoint);
    }
}
