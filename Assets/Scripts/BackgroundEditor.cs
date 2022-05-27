using UnityEngine;
using UnityEngine.UI;

public class BackgroundEditor : MonoBehaviour, IPrintable
{
    //фон панели, цвет которого планируем менять
    [SerializeField] private Image _backgroundImage;

    //ColorsPanelManager для подписки на событие по выбору нового цвета
    [SerializeField] private ColorsPanelManager _colorsManager;

    //подписываемся на выбор нового цвета для фона панели
    private void Start()
    {
        _colorsManager.ColorChanged += PrintMyself;
    }

    //меняем цвет картинки панели (фона)
    public void PrintMyself(Color color)
    {
        _backgroundImage.color = color;
    }
}
