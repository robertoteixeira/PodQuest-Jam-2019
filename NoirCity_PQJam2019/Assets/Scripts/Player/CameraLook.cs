using UnityEngine;

public class CameraLook : MonoBehaviour
{
    private Vector2 _mouseLook;
    private Vector2 _smoothV;
    private GameObject _character;

    public float Sensitivity = 5.0f;
    public float Smoothing = 2.0f;
    public Vector2 XBoundary;
    public Vector2 YBoundary;
    
    void Start()
    {
        _character = this.transform.parent.gameObject;
    }    

    public void Look(Vector2 position)
    {
        position = Vector2.Scale(position, new Vector2(Sensitivity * Smoothing, Sensitivity * Smoothing));
        _smoothV.x = Mathf.Lerp(_smoothV.x, position.x, 1f / Smoothing);
        _smoothV.y = Mathf.Lerp(_smoothV.y, position.y, 1f / Smoothing);
        _mouseLook += _smoothV;

        if (_mouseLook.x < XBoundary.x)
            _mouseLook.x = XBoundary.x;

        if (_mouseLook.x > XBoundary.y)
            _mouseLook.x = XBoundary.y;

        if (_mouseLook.y < YBoundary.x)
            _mouseLook.y = YBoundary.x;

        if (_mouseLook.y > YBoundary.y)
            _mouseLook.y = YBoundary.y;

        Debug.Log("Camera: " + _mouseLook);

        transform.localRotation = Quaternion.AngleAxis(-_mouseLook.y, Vector3.right);
        _character.transform.localRotation = Quaternion.AngleAxis(_mouseLook.x, _character.transform.up);
    }
}
