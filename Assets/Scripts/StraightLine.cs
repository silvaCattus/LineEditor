using UnityEngine;

[RequireComponent(typeof(LineRenderer))]

public class StraightLine : MonoBehaviour
{
    //rect transform панели с нарисованной линией
    [SerializeField] protected RectTransform _drawPanelRT;
    //для преобразования экранных координат
    [SerializeField] private ScreenCoordinateTransform _screenCoordinateTransform;


    protected LineRenderer _lineRenderer;
    //вершины прямой линии - константа
    public const int VertexNumber = 2;

    //VertexNumber для считывания
    public int Vertexs { get => VertexNumber; }

    //центер панели с нарисованной линией
    protected Vector2 _centerOfPanel;
    //полученное смещение для установки вершины линии
    protected Vector2 _offsetPosition;

    //устанавливаем line renderer, устанавливаем центр панели
    protected void Start()
    {
        _lineRenderer = GetComponent<LineRenderer>();
        _lineRenderer.positionCount = 0;

        _centerOfPanel = transform.TransformPoint(_drawPanelRT.rect.center);
        StartExtension();
    }

    protected virtual void StartExtension()
    {
    }

    //устанавливаем ширину всей линии
    public void SetWidth(float width)
    {
        _lineRenderer.startWidth = width;
        _lineRenderer.endWidth = width;
    }

    //высчитываем точку - вершину линии через полученное смещение от центра панели
    public void SetOffsetPosition(Vector2 offset)
    {
        _offsetPosition = _centerOfPanel + offset;
        _offsetPosition = _screenCoordinateTransform.GetWorldCoordinate(_offsetPosition);
        SetPoint(_offsetPosition);
    }

    //отрисовываем вершину линии
    protected void SetPoint(Vector2 point)
    {
        _lineRenderer.positionCount++;
        _lineRenderer.SetPosition(_lineRenderer.positionCount - 1, point);
    }
}
