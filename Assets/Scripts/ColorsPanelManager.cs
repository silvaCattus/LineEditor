using System;
using UnityEngine;
using UnityEngine.UI;

public class ColorsPanelManager : MonoBehaviour
{
    //GameObject родительского объекта панели с цветовой палитрой 
    [SerializeField] private GameObject _colorPanelObj;
    //картинка с панели для цветовой палитры
    [SerializeField] private Image _colorsPanelImage;
    //картинка с  выбранным цветом
    [SerializeField] private Image _chosenColorImage;
    //для преобразования экранных координат
    [SerializeField] private ScreenCoordinateTransform _screenCoordinateTransform;

    //rect transform панели палитры
    private RectTransform _colorPanelRT;
    //Texture2D для создания текстуры с цветами
    private Texture2D _colorSelector;
    //цвет для установки в пиксель текстуры палитры
    private Color _color;
    //выбранный пользователем цвет с палитры
    private Color _chosenColor;


    //ширина rect transform панели палитры
    private int _width;
    // высота rect transform панели палитры
    private int _height;


    //событие выбора нового цвета
    public Action<Color> ColorChanged;

    /// <summary>
    /// устанавливаем ширину и высоту rect transform панели палитры
    /// отрисовываем текстуру панели цветов
    /// </summary>

    private void Start()
    {
        _colorPanelRT = _colorPanelObj.GetComponent<RectTransform>();

        Rect panelRect = _colorPanelRT.rect;
        _width = (int)Math.Round(panelRect.width);
        _height = (int)Math.Round(panelRect.height);

        _colorSelector = new Texture2D(_width, _height, TextureFormat.ARGB32, false, false);

        for (int y = 0; y < _height; y += 1)
            for (int x = 0; x < _width; x += 1)
            {
                _color = Color.HSVToRGB((float)x / _width, (float)y / _height, 1f);
                _colorSelector.SetPixel(x, y, _color);
            }
        _colorSelector.Apply();
        SaveTexture();
    }

    //сохраняем текстуру панели цветов в спрайт картинки панели цветов
    private void SaveTexture()
    {
        Sprite colors = Sprite.Create((Texture2D)_colorSelector, new Rect(0, 0, _colorSelector.width, _colorSelector.height), Vector2.zero);
        _colorsPanelImage.sprite = colors;
    }

    //устанавливаем активным объект панели палитры (открываем)
    public void OpenColorPanel()
    {
        _colorPanelObj.SetActive(true);
    }

    //устанавливаем неактивным объект панели палитры (закрываем)
    public void CloseColorPanel()
    {
        _colorPanelObj.SetActive(false);
    }

    //сохраняем цвет пикселя под курсором в _chosenColor и назначаем этот цвет в картинку выбранного цвета
    public void ChooseColor()
    {
        _chosenColor = _colorSelector.GetPixel((int)_screenCoordinateTransform.GetWorldCoordinate(Input.mousePosition).y, (int)_screenCoordinateTransform.GetWorldCoordinate(Input.mousePosition).x);
        _chosenColorImage.color = _chosenColor;
    }

    //событие! цвет выбран. вызываем закрытие панели цветов
    public void SetChosenColor()
    {
        if (ColorChanged != null)
            ColorChanged(_chosenColor);
        CloseColorPanel();
    }
}
