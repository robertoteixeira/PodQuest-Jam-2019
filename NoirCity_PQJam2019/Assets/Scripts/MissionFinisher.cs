using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class MissionFinisher : MonoBehaviour
{
    public Text ConclusionText;
    public GameObject SuccessImage;
    public GameObject FailureImage;

    public string NextMission;

    private StatusManager _statusManager;

    private void Start()
    {
        _statusManager = GameObject.Find("StatusManager").GetComponent<StatusManager>();
    }

    public void FinishMission()
    {        
        var profile = _statusManager.CurrentProfile;

        SuccessImage.SetActive(false);
        FailureImage.SetActive(false);

        if (_statusManager.CaughtOnCamera)
        {
            if (profile != null)
            {
                ConclusionText.text = profile.Text;

                if (profile.Conclusive)
                {
                    SuccessImage.SetActive(true);
                }
                else
                {
                    FailureImage.SetActive(true);
                }
            } 
        }
        else
        {
            ConclusionText.text = "Caso inconclusivo.";
            FailureImage.SetActive(true);
        }

    }

    public void Next()
    {
        if (!string.IsNullOrEmpty(NextMission))
            SceneManager.LoadScene(NextMission);
        else
            SceneManager.LoadScene(0);
    }

    public void Again()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }

}
