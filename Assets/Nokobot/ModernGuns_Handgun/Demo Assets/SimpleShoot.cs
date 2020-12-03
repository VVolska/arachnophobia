using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleShoot : MonoBehaviour
{
    public TMPro.TextMeshPro text;
    public GameObject bulletPrefab;
    public GameObject casingPrefab;
    public GameObject muzzleFlashPrefab;
    public Transform barrelLocation;
    public Transform casingExitLocation;
    public int ammo = 10;
    private int currentammo;

  //  public AudioSource _shot;
  //  public AudioClip shot;

    public float shotPower = 10000f;
    private GameObject line;

    void Start()
    {
        if (barrelLocation == null)
            barrelLocation = transform;
    }
//Input.GetButtonDown("Fire1")
    void Update()
    {
        bool bDown = OVRInput.GetDown(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch);
        //OVRInput.Get(OVRInput.Button.PrimaryIndexTrigger, OVRInput.Controller.RTouch)

        if (bDown)
        {
           if(currentammo>0)
            GetComponent<Animator>().SetTrigger("Fire");
           else
                SoundManagerScript.PlaySound("noammo");
        }

        if (Vector3.Angle(transform.up, Vector3.up) > 100 && currentammo < ammo)
            Reload();

        text.text = currentammo.ToString();

    }
    void Reload()
    {
        currentammo = ammo;
        SoundManagerScript.PlaySound("reload");

    }
    void Shoot()
    {
        //  GameObject bullet;
        //  bullet = Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation);
        // bullet.GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        currentammo--;
        SoundManagerScript.PlaySound("Small_Gun_Shot");
        GameObject tempFlash;

        Instantiate(bulletPrefab, barrelLocation.position, barrelLocation.rotation).GetComponent<Rigidbody>().AddForce(barrelLocation.forward * shotPower);
        tempFlash = Instantiate(muzzleFlashPrefab, barrelLocation.position, barrelLocation.rotation);
        
        //SoundManagerScript.PlaySound("Small_Gun_Shot");
       //  Destroy(tempFlash, 0.5f);
    //      Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation).GetComponent<Rigidbody>().AddForce(casingExitLocation.right * 100f);

    }

    void CasingRelease()
    {
         GameObject casing;
        casing = Instantiate(casingPrefab, casingExitLocation.position, casingExitLocation.rotation) as GameObject;
        casing.GetComponent<Rigidbody>().AddExplosionForce(550f, (casingExitLocation.position - casingExitLocation.right * 0.3f - casingExitLocation.up * 0.6f), 1f);
        casing.GetComponent<Rigidbody>().AddTorque(new Vector3(0, Random.Range(100f, 500f), Random.Range(10f, 1000f)), ForceMode.Impulse);
    }


}
