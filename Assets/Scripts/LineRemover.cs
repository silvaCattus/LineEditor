using UnityEngine;

public class LineRemover : MonoBehaviour
{
    //массив  линий
    [SerializeField] private LineRenderer[] _lines;

    //устанавливаем значение вершин отрисованных линий в ноль ("удаляем" линии)
    public void RemoveLines()
    {
        foreach (var line in _lines)
        {
            line.positionCount = 0;
        }
    }
}
