using UnityEngine;

public class Spinner : MonoBehaviour
{
    [SerializeField] float rotatiex = 0f;
    [SerializeField] float rotatiey = 1f;
    [SerializeField] float rotatiez = 0f;
void Start()
    {
        
    }

    
    void Update()
    {
        transform.Rotate(rotatiex, rotatiey, rotatiez);

    }
}
