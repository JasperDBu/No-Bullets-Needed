using Unity.VisualScripting;
using UnityEngine;

public class Shooting : MonoBehaviour
{
    [SerializeField] public Transform Firepoint;

    [SerializeField] public GameObject bulletPrefab;

    [Range(0.1f, 1f)]

    [SerializeField]
    public float fireRate = 0.2f;

    private float fireTimer;



    void Update()
    {
       if (Input.GetMouseButton(0) && fireTimer <= 0)
        {
            Shoot();
            fireTimer = fireRate;
        }
       else
        {
            fireTimer -= Time.deltaTime;
        }
    }
    
    void Shoot()
    {
        Instantiate(bulletPrefab, Firepoint.position, Firepoint.rotation);
      
    }


}
