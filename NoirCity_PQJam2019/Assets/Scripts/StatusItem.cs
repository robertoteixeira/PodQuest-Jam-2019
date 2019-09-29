using UnityEngine;

public class StatusItem : MonoBehaviour
{
    private StatusManager _statusManager;

    // Start is called before the first frame update
    void Start()
    {
        _statusManager = GameObject.Find("StatusManager").GetComponent<StatusManager>();
    }

    public void SetStatus(int status)
    {
        _statusManager.SetStatus(status);
    }
    
}
