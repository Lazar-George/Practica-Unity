using UnityEngine;

public class TriggerProjectile : MonoBehaviour
{
    [SerializeField] GameObject Projectile1;
    [SerializeField] GameObject Projectile2;
    [SerializeField] GameObject Projectile3;
    [SerializeField] GameObject Projectile4;
    [SerializeField] GameObject Projectile5;
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.tag=="Player")
        {
            Projectile1.SetActive(true);
            Projectile2.SetActive(true);
            Projectile3.SetActive(true);
            Projectile4.SetActive(true);
            Projectile5.SetActive(true);
        }
    }
}
