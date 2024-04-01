using System;

public class EndScreen : Window
{
    public event Action RestartButtonClick;

    public override void Open()
    {
        WindowGroup.alpha = 1.0f;
        ActionButton.interactable = true;
    }

    public override void Close()
    {
        WindowGroup.alpha = 0f;
        ActionButton.interactable = false;
    }

    protected override void OnButtonClick() => RestartButtonClick?.Invoke();
}
