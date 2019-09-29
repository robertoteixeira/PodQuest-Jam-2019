using UnityEngine;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{

    private void Start()
    {
        AudioManager.Instance.StopAmbient();        
    }

    public void LoadGame()
    {
        SceneManager.LoadScene(1);
        AudioManager.Instance.PlayAmbient();        
    }
}
