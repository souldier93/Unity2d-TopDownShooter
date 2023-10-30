using UnityEngine;

public class WeaponRotation : MonoBehaviour
{
    private Camera _camera;
    private Vector3 _initialScale;

    private void Start()
    {
        _camera = Camera.main;
        _initialScale = transform.localScale;
    }

    private void Update()
    {
        RotateWeaponTowardsMouse();
    }

    private void RotateWeaponTowardsMouse()
    {
        Vector3 mousePosition = _camera.ScreenToWorldPoint(Input.mousePosition);
        mousePosition.z = 0f;

        Vector3 direction = mousePosition - transform.position;
        float angle = Mathf.Atan2(direction.y, direction.x) * Mathf.Rad2Deg;

        if (angle > 90 || angle < -90)
        {
            // Quay sang bên trái, lật ngược súng
            transform.localScale = new Vector3(_initialScale.x, -_initialScale.y, _initialScale.z);
        }
        else
        {
            // Quay sang bên phải, không lật ngược súng
            transform.localScale = _initialScale;
        }

        transform.rotation = Quaternion.AngleAxis(angle, Vector3.forward);
    }
}