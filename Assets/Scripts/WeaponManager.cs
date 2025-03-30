using System.Runtime.InteropServices.WindowsRuntime;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Rendering;

public class WeaponManager : MonoBehaviour
{
    [Header("Fire Rate")]
    [SerializeField] float fireRate;
    float fireRateTimer;
    [SerializeField] bool semiAuto;

    [Header("Bullet Propierties")]
    [SerializeField] GameObject bullet;
    [SerializeField] Transform barrelPos;
    [SerializeField] float bulletVelocity;
    [SerializeField] int bulletPerShot;
    public float damage = 20;
    AimStateManager aim;

    [SerializeField] AudioClip gunShot;
    [SerializeField] AudioClip emptyShot;
    [HideInInspector] public AudioSource audioSource;

    [HideInInspector] public WeaponAmmo ammo;

    WeaponBloom bloom;

    ActionStateManager actions;

    WeaponRecoil recoil;

    Light muzzleFlashLight;
    ParticleSystem muzzleFlashParticles;
    float lightIntensity;
    [SerializeField] float lightRetunrSpeed = 20;

    public float enemyKickbackForce = 100;

    public Transform leftHandTarget, leftHandHint;

    WeaponClassManager weaponClass;


    void Start()
    {
        
        aim = GetComponentInParent<AimStateManager>();
        
        bloom = GetComponent<WeaponBloom>();
        actions = GetComponentInParent<ActionStateManager>();
        muzzleFlashLight = GetComponentInChildren<Light>();
        muzzleFlashParticles = GetComponentInChildren<ParticleSystem>();
        lightIntensity = muzzleFlashLight.intensity;
        muzzleFlashLight.intensity = 0;
        fireRateTimer = fireRate;
        

    }

    private void OnEnable()
    {
        if (weaponClass == null)
        {
            weaponClass = GetComponentInParent<WeaponClassManager>();
            ammo = GetComponentInParent<WeaponAmmo>();
            audioSource = GetComponent<AudioSource>();
            recoil = GetComponent<WeaponRecoil>();
            recoil.recoilFollowPos = weaponClass.recoilFollowPos;
        }
        weaponClass.SetCurrentWeapon(this);
        
    }


    void Update()
    {
        if(ShouldFire()) Fire();
        muzzleFlashLight.intensity = Mathf.Lerp(muzzleFlashLight.intensity, 0, lightRetunrSpeed * Time.deltaTime);
    }

    bool ShouldFire()
    {
        fireRateTimer += Time.deltaTime;
        if (fireRateTimer < fireRate) return false;
        if (ammo.currentAmmo == 0) 
        {
            
            if (Input.GetKeyDown(KeyCode.Mouse0) && actions.currentState != actions.Reload)
            {
                audioSource.PlayOneShot(emptyShot);
                return false;
            }
            else
            {
                return false;
            }
         }
        if (actions.currentState == actions.Reload) return false;   
        if (actions.currentState == actions.Swap) return false;
        if(semiAuto&&Input.GetKeyDown(KeyCode.Mouse0)) return true;
        if(!semiAuto&&Input.GetKey(KeyCode.Mouse0)) return true;
        return false;
    }

    void Fire()
    {
        fireRateTimer = 0;
        barrelPos.LookAt(aim.aimPos);

        barrelPos.localEulerAngles = bloom.BloomAngle(barrelPos);

        audioSource.PlayOneShot(gunShot);
        recoil.TriggerRecoil();
        TriggerMuzzleFlash();
        ammo.currentAmmo--; 
        for (int i = 0; i < bulletPerShot; i++ )
        {
            GameObject currentBullet = Instantiate(bullet, barrelPos.position, barrelPos.rotation);

            Bullet bulletScript = currentBullet.GetComponent<Bullet>();
            bulletScript.weapon = this;

            bulletScript.dir = barrelPos.transform.forward;

            Rigidbody rb = currentBullet.GetComponent<Rigidbody>();
            rb.AddForce(barrelPos.forward * bulletVelocity, ForceMode.Impulse);
        }
        
    }


    void TriggerMuzzleFlash()
    {
        muzzleFlashParticles.Play();
        muzzleFlashLight.intensity = lightIntensity;
    }
}
