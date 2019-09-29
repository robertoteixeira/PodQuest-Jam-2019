using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public int CurrentStatus;
    public CaseProfile[] Profiles;

    private CaseProfile _currentStatus;

    public void SetStatus(int status)
    {
        _currentStatus = Profiles[status];
    }
}
