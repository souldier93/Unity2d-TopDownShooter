using UnityEngine;
using UnityEngine.InputSystem;

public class Shoot : MonoBehaviour
{
    [SerializeField] private GameObject _bulletPrefabs;
    [SerializeField] private float _bulletSpeed;
    [SerializeField] private float _fireDelay;

    private bool _isFiring;
    private PlayerMovement _playerMovement;
    private Vector2 _mouseDirection;
    private float _fireTimer;

    private void Start()
    {
        _playerMovement = GetComponent<PlayerMovement>();
    }

    private void Update()
    {
        if (_isFiring)
        {
            _fireTimer -= Time.deltaTime;
            if (_fireTimer <= 0f)
            {
                FireBullet();
                _fireTimer = _fireDelay;
            }
        }
    }

    private void FireBullet()
    {
        GameObject bullet = Instantiate(_bulletPrefabs, transform.position, Quaternion.identity);
        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

        Vector2 bulletDirection = _mouseDirection.normalized;
        if (bulletDirection == Vector2.zero)
        {
            // Nếu không có hướng di chuyển chuột, sử dụng hướng nhìn của nhân vật
            bulletDirection = _playerMovement.GetMovementInput().normalized;
        }

        rigidbody.velocity = _bulletSpeed * bulletDirection;
    }

    private void OnFire(InputValue inputValue)
    {
        bool isPressed = inputValue.isPressed;
        if (_isFiring != isPressed)
        {
            _isFiring = isPressed;
            if (_isFiring)
            {
                _fireTimer = 0f; // Bắt đầu bắn ngay lập tức
                _mouseDirection = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
            }
        }
    }
}

//using UnityEngine;
//using UnityEngine.InputSystem;

//[System.Serializable]
//public struct WeaponData
//{
//    public GameObject bulletPrefab;
//    public float bulletSpeed;
//    public float fireDelay;
//}

//public class Shoot : MonoBehaviour
//{
//    [SerializeField] public WeaponData[] _weaponData; // Mảng chứa thông tin của từng loại súng

//    private bool _isFiring;
//    private PlayerMovement _playerMovement;
//    private Vector2 _mouseDirection;
//    private float _fireTimer;
//    private int _currentWeaponIndex = 0; // Chỉ số của vũ khí hiện tại

//    private void Start()
//    {
//        _playerMovement = GetComponent<PlayerMovement>();
//    }

//    private void Update()
//    {
//        if (_isFiring)
//        {
//            _fireTimer -= Time.deltaTime;
//            if (_fireTimer <= 0f)
//            {
//                FireBullet();
//                _fireTimer = _weaponData[_currentWeaponIndex].fireDelay;
//            }
//        }
//    }

//    private void FireBullet()
//    {
//        GameObject bullet = Instantiate(_weaponData[_currentWeaponIndex].bulletPrefab, transform.position, Quaternion.identity);
//        Rigidbody2D rigidbody = bullet.GetComponent<Rigidbody2D>();

//        Vector2 bulletDirection = _mouseDirection.normalized;
//        if (bulletDirection == Vector2.zero)
//        {
//            // Nếu không có hướng di chuyển chuột, sử dụng hướng nhìn của nhân vật
//            bulletDirection = _playerMovement.GetMovementInput().normalized;
//        }

//        rigidbody.velocity = _weaponData[_currentWeaponIndex].bulletSpeed * bulletDirection;
//    }

//    private void OnFire(InputValue inputValue)
//    {
//        bool isPressed = inputValue.isPressed;
//        if (_isFiring != isPressed)
//        {
//            _isFiring = isPressed;
//            if (_isFiring)
//            {
//                _fireTimer = 0f; // Bắt đầu bắn ngay lập tức
//                _mouseDirection = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue()) - transform.position;
//            }
//        }
//    }

//    public void SwitchBullet(int weaponIndex)
//    {
//        if (weaponIndex >= 0 && weaponIndex < _weaponData.Length)
//        {
//            _currentWeaponIndex = weaponIndex;
//        }
//    }
//}
