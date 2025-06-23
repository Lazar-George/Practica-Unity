using UnityEngine;
using UnityEngine.InputSystem;

public class NewMonoBehaviourScript : MonoBehaviour
{
    [SerializeField] GameObject[] lasers;
    [SerializeField] RectTransform crosshair;
    [SerializeField] Transform targetpoint;
    [SerializeField] float targetDistance = 20f;

    bool IsFiring=false;

    private void Start()
    {
        Cursor.visible = false;
    }
    private void Update()
    {
        ProcessFiring();
        MoveCrosshair();
        MoveTargetPoint();
        AimLasers();
    }
    public void OnFire(InputValue value)
    {
        IsFiring = value.isPressed;
    }
    void ProcessFiring()
    {
        foreach (GameObject laser in lasers)
        {
            var emmisionmodule = laser.GetComponent<ParticleSystem>().emission;
            emmisionmodule.enabled = IsFiring;
        }
       
    }
    private void MoveTargetPoint()
    {
        Vector3 targetpointPosition = new Vector3(Input.mousePosition.x, Input.mousePosition.y,targetDistance);
        targetpoint.position = Camera.main.ScreenToWorldPoint(targetpointPosition);
    }
    private void MoveCrosshair()
    {
        crosshair.position = Input.mousePosition;
    }
    private void AimLasers()
    {
        foreach(GameObject laser in lasers)
        {
            Vector3 FireDirection = targetpoint.position - this.transform.position;
            Quaternion RotationToTarget = Quaternion.LookRotation(FireDirection);
            laser.transform.rotation = RotationToTarget;
        }
    }
    
}
