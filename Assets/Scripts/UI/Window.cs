using UnityEngine;
using UnityEngine.UI;

public abstract class Window : MonoBehaviour
{
    [SerializeField] private CanvasGroup _canvas;
    [SerializeField] private Button _button;

    protected CanvasGroup WindowGroup => _canvas;
    protected Button ActionButton => _button;

    private void OnEnable() => _button.onClick.AddListener(OnButtonClick);
    private void OnDisable() => _button.onClick.RemoveListener(OnButtonClick);
    public abstract void Open();
    public abstract void Close();
    protected abstract void OnButtonClick();
}