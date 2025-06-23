using UnityEngine;

public class Dropper : MonoBehaviour
{
    [SerializeField] float timetowait = 3f;
    MeshRenderer MyMeshRenderer;
    Rigidbody rb;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        MyMeshRenderer = gameObject.GetComponent<MeshRenderer>();

        rb.useGravity = false;
        MyMeshRenderer.enabled = false;
       
    }

    // Update is called once per frame
    void Update()
    {
        if (Time.time > timetowait)
        {
            rb.useGravity = true;
            MyMeshRenderer.enabled = true;
        }
    }
}
