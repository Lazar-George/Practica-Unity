using UnityEngine;

public class Oscilator : MonoBehaviour
{
    [SerializeField] Vector3 Movementvector;
    [SerializeField] float Speed;
     Vector3 StartPosition;
     Vector3 Endposition;
    [SerializeField] float Movementfactor;

    void Start()
    {
        StartPosition = transform.position;
        Endposition =  StartPosition+ Movementvector;
    }

    // Update is called once per frame
    void Update()
    {

        Movementfactor = Mathf.PingPong(Time.time * Speed, 1f);
        transform.position = Vector3.Lerp(StartPosition, Endposition, Movementfactor);

    }
}
