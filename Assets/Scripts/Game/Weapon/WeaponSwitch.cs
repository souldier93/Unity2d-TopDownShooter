

//using UnityEngine;
//using UnityEngine.InputSystem;

//public class WeaponSwitch : MonoBehaviour
//{
//    public GameObject[] guns;
//    public GameObject weaponHolder;
//    public Canvas ImgGun;


//    public int currentWeaponIndex = 0;
//    private GunShoot currentGunShoot;
//    //private BulletController BulletController;
//    //private int currentBullet = 0;
//    private void Start()
//    {
//        //BulletController = GetComponent<BulletController>();
//        int totalWeapons = weaponHolder.transform.childCount;
//        guns = new GameObject[totalWeapons];

//        for (int i = 0; i < totalWeapons; i++)
//        {
//            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
//            guns[i].SetActive(false);
//        }

//        if (guns.Length > 0)
//        {
//            guns[currentWeaponIndex].SetActive(true);
//            currentGunShoot = guns[currentWeaponIndex].GetComponent<GunShoot>();
//        }
//    }

//    private void Update()
//    {
//        if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
//        {
//            SwitchWeapon(0);
//        }
//        else if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
//        {
//            SwitchWeapon(1);
//        }
//        else if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
//        {
//            SwitchWeapon(2);
//        }
//    }

//    private void SwitchWeapon(int weaponIndex)
//    {
//        if (weaponIndex >= 0 && weaponIndex < guns.Length)
//        {
//            guns[currentWeaponIndex].SetActive(false);

//            currentWeaponIndex = weaponIndex;
//            guns[currentWeaponIndex].SetActive(true);
//            currentGunShoot = guns[currentWeaponIndex].GetComponent<GunShoot>();
//            currentGunShoot.currentWeaponIndex = currentWeaponIndex;
//            if (currentWeaponIndex == 0)
//            {
//                currentGunShoot.currentBulletCount += GameManager.pistolBulletCount;
//                GameManager.pistolBulletCount = 0;
//            }
//            else if (currentWeaponIndex == 1)
//            {
//                currentGunShoot.currentBulletCount += GameManager.akBulletCount;
//                GameManager.akBulletCount = 0;
//            }
//            else if (currentWeaponIndex == 2)
//            {
//                currentGunShoot.currentBulletCount += GameManager.shotgunBulletCount;
//                GameManager.shotgunBulletCount = 0;
//            }
//        }
//    }

//    private void OnFire(InputValue inputValue)
//    {
//        bool isPressed = inputValue.isPressed;
//        if (currentGunShoot != null)
//        {
//            if (isPressed)
//            {
//                currentGunShoot.StartFiring();
//            }
//            else
//            {
//                currentGunShoot.StopFiring();
//            }
//        }
//    }
//}



using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.UI;

public class WeaponSwitch : MonoBehaviour
{
    public GameObject[] guns;
    public GameObject weaponHolder;
    public Image[] imgGun;
    public Canvas ImgGun;


    public int currentWeaponIndex = 0;
    private GunShoot currentGunShoot;
    //private BulletController BulletController;
    //private int currentBullet = 0;
    private void Start()
    {
        //BulletController = GetComponent<BulletController>();
        int totalWeapons = weaponHolder.transform.childCount;
        guns = new GameObject[totalWeapons];
        imgGun = new Image[totalWeapons];

        for (int i = 0; i < totalWeapons; i++)
        {
            guns[i] = weaponHolder.transform.GetChild(i).gameObject;
            guns[i].SetActive(false);

            imgGun[i] = ImgGun.transform.GetChild(i).GetComponent<Image>();
            imgGun[i].enabled = false;
        }


        if (guns.Length > 0)
        {
            guns[currentWeaponIndex].SetActive(true);
            imgGun[currentWeaponIndex].enabled = true;
            currentGunShoot = guns[currentWeaponIndex].GetComponent<GunShoot>();
        }
    }

    private void Update()
    {
        if (Keyboard.current[Key.Digit1].wasPressedThisFrame)
        {
            SwitchWeapon(0);
        }
        else if (Keyboard.current[Key.Digit2].wasPressedThisFrame)
        {
            SwitchWeapon(1);
        }
        else if (Keyboard.current[Key.Digit3].wasPressedThisFrame)
        {
            SwitchWeapon(2);
        }
    }

    private void SwitchWeapon(int weaponIndex)
    {
        if (weaponIndex >= 0 && weaponIndex < guns.Length)
        {
            guns[currentWeaponIndex].SetActive(false);
            imgGun[currentWeaponIndex].enabled = false;

            currentWeaponIndex = weaponIndex;
            guns[currentWeaponIndex].SetActive(true);
            imgGun[currentWeaponIndex].enabled = true;

            currentGunShoot = guns[currentWeaponIndex].GetComponent<GunShoot>();
            currentGunShoot.currentWeaponIndex = currentWeaponIndex;
            if (currentWeaponIndex == 0)
            {
                currentGunShoot.currentBulletCount += GameManager.pistolBulletCount;
                GameManager.pistolBulletCount = 0;
            }
            else if (currentWeaponIndex == 1)
            {
                currentGunShoot.currentBulletCount += GameManager.akBulletCount;
                GameManager.akBulletCount = 0;
            }
            else if (currentWeaponIndex == 2)
            {
                currentGunShoot.currentBulletCount += GameManager.shotgunBulletCount;
                GameManager.shotgunBulletCount = 0;
            }
        }
    }

    private void OnFire(InputValue inputValue)
    {
        bool isPressed = inputValue.isPressed;
        if (currentGunShoot != null)
        {
            if (isPressed)
            {
                currentGunShoot.StartFiring();
            }
            else
            {
                currentGunShoot.StopFiring();
            }
        }
    }

}