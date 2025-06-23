using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerMovement : MonoBehaviour

{
    [SerializeField] float controlspeed = 10f;
    [SerializeField] float XClampRange= 30f;
    [SerializeField] float YClampRange = 30f;

    [SerializeField] float ControlRollFactor = 20f;
    [SerializeField] float rotationSpeed = 10f;
    [SerializeField] float PitchFactor = 10f;

    Vector2 Movement;

    

    
    void Update()
    {
        ProcessTranslation();
        ProcessRotation();
    }

    private void ProcessTranslation()
    {
        float XOffset = Movement.x * controlspeed * Time.deltaTime;
        float RawXpos = transform.localPosition.x + XOffset;
        float clampedXpos = Mathf.Clamp(RawXpos, -XClampRange, XClampRange);
        float YOffset = Movement.y * controlspeed * Time.deltaTime;
        float RawYpos = transform.localPosition.y + YOffset;
        float clampedYpos= Mathf.Clamp(RawYpos, -6f, YClampRange);
        transform.localPosition = new Vector3(clampedXpos, clampedYpos, 0f);
    }

    public void OnMove(InputValue value)
    {
        Movement = value.Get<Vector2>();
    }

     void ProcessRotation()
    {
        float Roll = -ControlRollFactor * Movement.x;
        float Pitch = -PitchFactor * Movement.y;

        Quaternion TargetRotation=Quaternion.Euler(Pitch, 0f, Roll);
        transform.localRotation = Quaternion.Lerp(transform.localRotation, TargetRotation, rotationSpeed*Time.deltaTime);
        
    }
}
