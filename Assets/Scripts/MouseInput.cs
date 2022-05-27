using UnityEngine;
using UnityEngine.EventSystems;

public class MouseInput : MonoBehaviour, IPointerEnterHandler, IPointerExitHandler
{
    //LineCreator для передачи в него координат клика
    [SerializeField] private LineCreator _lineCreator;
    //курсор на панели для "черчения"?
    private bool _mouseOnSketchPanel;

    //курсор на панели для "черчения" - true
    public void OnPointerEnter(PointerEventData eventData)
    {
        _mouseOnSketchPanel = true;
    }

    //курсор на панели для "черчения" - false
    public void OnPointerExit(PointerEventData eventData)
    {
        _mouseOnSketchPanel = false;
    }

    //при клике ЛКМ на панели для "черчения" отправляет координаты клика в LineCreator
    private void Update()
    {
        if (Input.GetMouseButtonDown(0) && _mouseOnSketchPanel)
        {
            _lineCreator.SetPoint(Input.mousePosition);
        }
    }
}
