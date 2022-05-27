using UnityEngine;
using UnityEngine.UI;

public class DrawnLine : StraightLine, IPrintable, ITexturable
{
    //ColorsPanelManager для подписки на событие выбора нового цвета для линии
    [SerializeField] private ColorsPanelManager _colorsManager;

    //текстура линии
    public Sprite SpriteTexture { get; private set; }
    //альфа цвета линии
    private int _alpha;

    //подписываемся на смену выбранного цвета для линии
    protected override void StartExtension()
    {
        _colorsManager.ColorChanged += PrintMyself;
    }

    //назначаем цвет материалу линии
    public void PrintMyself(Color color)
    {
        _lineRenderer.material.color = color;
    }

    //назначаем текстуру
    public void TexturateMyself(Sprite sprite)
    {
        SpriteTexture = sprite;
    }

    //устанавливаем значениее альфы цвета линии
    public void SetAlpha(Text text)
    {
        if(int.TryParse(text.text, out _alpha))
        {
            if(_alpha < 0)
                _alpha = 0;
            else if(_alpha > 100)
                _alpha = 100;

            float alpha = _alpha;
            alpha /= 100;
            _lineRenderer.material.SetColor("_Color", new Color(_lineRenderer.material.color.r, _lineRenderer.material.color.g,
            _lineRenderer.material.color.b, alpha));
        }
    }
}
