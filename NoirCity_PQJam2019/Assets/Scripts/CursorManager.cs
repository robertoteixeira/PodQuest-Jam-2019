using System;
using UnityEngine;

public class CursorManager : Singleton<CursorManager>
{
    public Action OnShowCursor;
    public Action OnHideCursor;

    public void ShowCursor()
    {
        Cursor.visible = true;
        OnShowCursor?.Invoke();
    }

    public void HideCursor()
    {
        Cursor.visible = false;
        OnHideCursor?.Invoke();
    }
}
