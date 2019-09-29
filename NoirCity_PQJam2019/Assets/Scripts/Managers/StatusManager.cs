using UnityEngine;

public class StatusManager : MonoBehaviour
{
    public int CurrentStatus;
    public CaseProfile[] Profiles;

    public CaseProfile CurrentProfile;

    public bool CaughtOnCamera = false;

    public void SetStatus(int status)
    {
        if (status == 99)
            CurrentProfile = null;
        else
            CurrentProfile = Profiles[status];
        CurrentStatus = status;
    }
}
