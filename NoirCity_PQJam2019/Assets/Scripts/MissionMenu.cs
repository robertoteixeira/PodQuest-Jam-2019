using UnityEngine;

public class MissionMenu : MonoBehaviour
{
    public GameObject StartButton;

    public void Hide()
    {
        StartButton.SetActive(false);
        UIManager.Instance.HideMissionPanel();
        CursorManager.Instance.HideCursor();
    }
}
