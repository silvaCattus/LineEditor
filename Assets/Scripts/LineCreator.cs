using UnityEngine;

public class LineCreator : MonoBehaviour
{
    //ограниченная ширина линии
    [SerializeField] [Range(10, 30)] private float _width;
    //массив линий, которые будут отрисовываться
    [SerializeField] private StraightLine[] _straightLines;
    //rect transform панели, в которой будем "чертить" линию
    [SerializeField] private RectTransform _sketchingPanelRT;
    //для преобразования экранных координат
    [SerializeField] private ScreenCoordinateTransform _screenCoordinateTransform;

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
        clickPosition = _screenCoordinateTransform.GetWorldCoordinate(clickPosition);

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
}