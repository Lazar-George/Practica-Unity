using UnityEngine;

public class CollisionHandler : MonoBehaviour
{
    [SerializeField] GameObject destroyedVfx;
    private void OnTriggerEnter(Collider other)
    {
        Instantiate(destroyedVfx, transform.position, Quaternion.identity);
        Destroy(this.gameObject);
    }
}
