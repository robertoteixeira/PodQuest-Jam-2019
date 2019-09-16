using UnityEngine;
using UnityEngine.UI;

public class TopSecretController : MonoBehaviour
{
    public Image Photo;

    // Start is called before the first frame update
    void Start()
    {
        UIManager.Instance.OnScreenshot += OnScreenShot;    
    }

    private void OnScreenShot(Texture2D screenshot)
    {
        var sprite = Sprite.Create(screenshot, new Rect(0, 0, Screen.width, Screen.height), Vector2.zero);
        Photo.sprite = sprite;
        Photo.preserveAspect = true;
    }
    
}
