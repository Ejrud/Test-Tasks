using UnityEngine;
using UnityEngine.EventSystems;

public class CustomButton : MonoBehaviour, IPointerDownHandler, IPointerEnterHandler, IPointerExitHandler, IPointerUpHandler
{
    public float value { get; private set; }
    [SerializeField] private bool _inversed;
    [SerializeField] private float _sensitivity = 0.1f;
    private bool _isEntered;
    private bool _isTouch;
    
    public void OnPointerDown(PointerEventData eventData)
    {
        if (_isEntered)
        {
            _isTouch = true;
        }
    }

    public void OnPointerEnter(PointerEventData eventData)
    {
        _isEntered = true;
    }

    public void OnPointerExit(PointerEventData eventData)
    {
        _isEntered = false;
        _isTouch = false;
        value = 0;
    }

    private void Update()
    {
        if (_isTouch)
        {
            value += !_inversed ? _sensitivity * Time.deltaTime : -_sensitivity * Time.deltaTime;
        }
    }

    public void OnPointerUp(PointerEventData eventData)
    {
        _isEntered = false;
        _isTouch = false;
        value = 0;
    }
}
