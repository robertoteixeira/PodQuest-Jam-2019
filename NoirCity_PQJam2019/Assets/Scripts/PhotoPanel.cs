using UnityEngine;

public class PhotoPanel : MonoBehaviour
{    
    public void Cancel()
    {        
        CursorManager.Instance.HideCursor();
        UIManager.Instance.HidePhotoPanel();
    }

    public void Send()
    {
        UIManager.Instance.HidePhotoPanel();
        GameManager.Instance.SendPhoto();
    }
}
