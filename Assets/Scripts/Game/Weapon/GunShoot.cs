

//using Goldmetal.UndeadSurvivor;
//using UnityEngine;
//using UnityEngine.InputSystem;
//using UnityEngine.UI;

//public class GunShoot : MonoBehaviour
//{
//    [SerializeField] private GameObject bulletPrefab;
//    [SerializeField] private Transform firePoint;
//    [SerializeField] private float bulletSpeed;
//    [SerializeField] private float fireRate;
//    [SerializeField] private int maxBulletCount; // Số lượng đạn tối đa mỗi súng
//    [SerializeField] public int currentBulletCount;// Số lượng đạn hiện tại

//    private bool isFiring;
//    private float fireTimer;
//    private int updateBulletCollect;
//    private BulletController bulletController;
//    private WeaponSwitch weaponSwitch;
//    public int currentWeaponIndex;
//    public Image[] imgBullet;
//    public Canvas ImgBullet;
//    //private ItemManager itemManager;

//    private void Start()
//    {
//        int totalImages = ImgBullet.transform.childCount;
//        imgBullet = new Image[totalImages];
//        for (int i = 0; i < totalImages; i++)
//        {

//            imgBullet[i] = ImgBullet.transform.GetChild(i).GetComponent<Image>();
//            imgBullet[i].enabled = false;
//        }

//        bulletController = GetComponent<BulletController>();
//        weaponSwitch = GetComponent<WeaponSwitch>();
//        //itemManager = GetComponent<ItemManager>();
//    }

//    private void Update()
//    {
//        imgBullet[0].enabled = false;
//        imgBullet[1].enabled = false;
//        imgBullet[2].enabled = false;
//        if (currentWeaponIndex == 0)
//        {
//            imgBullet[0].enabled = true;
//            currentBulletCount += GameManager.pistolBulletCount;
//            GameManager.pistolBulletCount = 0;
//        }
//        else if (currentWeaponIndex == 1)
//        {
//            imgBullet[1].enabled = true;
//            currentBulletCount += GameManager.akBulletCount;
//            GameManager.akBulletCount = 0;
//        }
//        else if (currentWeaponIndex == 2)
//        {
//            imgBullet[2].enabled = true;
//            currentBulletCount += GameManager.shotgunBulletCount;
//            GameManager.shotgunBulletCount = 0;
//        }
//        bulletController.BulletChange(currentBulletCount);
//        if (isFiring)
//        {
//            fireTimer -= Time.deltaTime;
//            if (fireTimer <= 0f && currentBulletCount > 0)
//            {
//                FireBullet();
//                fireTimer = 1f / fireRate;
//                currentBulletCount--;
//                //currentBulletCount = currentBulletCount; // Cập nhật giá trị currentBulletCount
//                bulletController.BulletChange(currentBulletCount);
//            }
//        }
//    }

//    private void FireBullet()
//    {
//        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
//        Vector2 direction = mousePosition - (Vector2)firePoint.position;
//        direction.Normalize();

//        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
//        Bullet bulletScript = bullet.GetComponent<Bullet>();
//        bulletScript.SetRotation(direction);

//        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
//        bulletRigidbody.velocity = direction * bulletSpeed;
//    }

//    public void StartFiring()
//    {
//        if (currentBulletCount <= 0)
//        {
//            // Không đủ đạn để bắn, thực hiện hành động phù hợp (ví dụ: thông báo cho người chơi)
//            return;
//        }

//        isFiring = true;
//        fireTimer = 0f;
//    }

//    public void StopFiring()
//    {
//        isFiring = false;
//    }

//    public void Reload()
//    {
//        currentBulletCount = maxBulletCount;
//    }
//}



using Goldmetal.UndeadSurvivor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class GunShoot : MonoBehaviour
{
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed;
    [SerializeField] private float fireRate;
    [SerializeField] private int maxBulletCount; // Số lượng đạn tối đa mỗi súng
    [SerializeField] public int currentBulletCount;// Số lượng đạn hiện tại


    private bool isFiring;
    private float fireTimer;
    private int updateBulletCollect;
    private BulletController bulletController;
    private WeaponSwitch weaponSwitch;
    public int currentWeaponIndex;
    public Image[] imgBullet;
    public Canvas ImgBullet;
    //private ItemManager itemManager;

    private void Start()
    {
        int totalImages = ImgBullet.transform.childCount;
        imgBullet = new Image[totalImages];
        for (int i = 0; i < totalImages; i++)
        {

            imgBullet[i] = ImgBullet.transform.GetChild(i).GetComponent<Image>();
            imgBullet[i].enabled = false;
        }

        bulletController = GetComponent<BulletController>();
        weaponSwitch = GetComponent<WeaponSwitch>();
        //itemManager = GetComponent<ItemManager>();
    }

    private void Update()
    {
        imgBullet[0].enabled = false;
        imgBullet[1].enabled = false;
        imgBullet[2].enabled = false;
        if (currentWeaponIndex == 0)
        {
            imgBullet[0].enabled = true;
            currentBulletCount += GameManager.pistolBulletCount;
            GameManager.pistolBulletCount = 0;
        }
        else if (currentWeaponIndex == 1)
        {
            imgBullet[1].enabled = true;
            currentBulletCount += GameManager.akBulletCount;
            GameManager.akBulletCount = 0;
        }
        else if (currentWeaponIndex == 2)
        {
            imgBullet[2].enabled = true;
            currentBulletCount += GameManager.shotgunBulletCount;
            GameManager.shotgunBulletCount = 0;
        }
        
        bulletController.BulletChange(currentBulletCount);
        if (isFiring)
        {
            fireTimer -= Time.deltaTime;
            if (fireTimer <= 0f && currentBulletCount > 0)
            {
                FireBullet();
                fireTimer = 1f / fireRate;
                currentBulletCount--;
                //currentBulletCount = currentBulletCount; // Cập nhật giá trị currentBulletCount
                bulletController.BulletChange(currentBulletCount);
            }
        }
    }

    private void FireBullet()
    {
        Vector2 mousePosition = Camera.main.ScreenToWorldPoint(Mouse.current.position.ReadValue());
        Vector2 direction = mousePosition - (Vector2)firePoint.position;
        direction.Normalize();

        GameObject bullet = Instantiate(bulletPrefab, firePoint.position, Quaternion.identity);
        Bullet bulletScript = bullet.GetComponent<Bullet>();
        bulletScript.SetRotation(direction);

        Rigidbody2D bulletRigidbody = bullet.GetComponent<Rigidbody2D>();
        bulletRigidbody.velocity = direction * bulletSpeed;
    }

    public void StartFiring()
    {
        if (currentBulletCount <= 0)
        {
            // Không đủ đạn để bắn, thực hiện hành động phù hợp (ví dụ: thông báo cho người chơi)
            return;
        }

        isFiring = true;
        fireTimer = 0f;
    }

    public void StopFiring()
    {
        isFiring = false;
    }

    public void Reload()
    {
        currentBulletCount = maxBulletCount;
    }
}