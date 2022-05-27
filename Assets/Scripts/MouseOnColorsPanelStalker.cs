using UnityEngine;
using UnityEngine.EventSystems;

public class MouseOnColorsPanelStalker : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //ColorsPanelManager для установки выбранного цвета
    [SerializeField] private ColorsPanelManager _colorsPanelManager;
    //курсор на цветовой панели?
    public bool MouseOnColorPanel { get; private set; }

    //курсор на цветовой панели - false
    public void OnPointerExit(PointerEventData eventData)
    {
        MouseOnColorPanel = false;
    }

    //курсор на цветовой панели - true
    public void OnPointerEnter(PointerEventData eventData)
    {
        MouseOnColorPanel = true;
    }

    //проверяем нахождение курсора на панели цвета, вызываем выбор цвета. При клике ЛКМ сохраняем выбранный цвет для окраса
    private void Update()
    {
        if (MouseOnColorPanel)
        {
            _colorsPanelManager.ChooseColor();
            if (Input.GetMouseButtonDown(0))
            {
                _colorsPanelManager.SetChosenColor();
            }
        }
    }
}
