using UnityEngine;

public class MissionMenu : MonoBehaviour
{    
    public void Hide()
    {
        gameObject.SetActive(false);
        CursorManager.Instance.HideCursor();
    }
}
