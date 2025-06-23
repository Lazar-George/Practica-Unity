using UnityEngine;

public class Mover : MonoBehaviour
{
    [SerializeField] float movespeed = 5f;


    void Start()
    {


    }


    void Update()
    {
        MovePlayer();
    }
    void MovePlayer()
    {float xvalue = Input.GetAxis("Horizontal") * Time.deltaTime * movespeed;
    float yvalue = 0;
    float zvalue = Input.GetAxis("Vertical") * Time.deltaTime * movespeed;
    transform.Translate(xvalue, yvalue, zvalue);
     }
}
