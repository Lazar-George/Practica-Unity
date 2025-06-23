using UnityEngine;
using UnityEngine.InputSystem;

public class movement : MonoBehaviour
{
    [SerializeField] InputAction thrust;
    [SerializeField] InputAction rotation;
    [SerializeField]  float ThrustPower;
    [SerializeField] float RotationPower;
    [SerializeField] AudioClip mainEngine;
    [SerializeField] ParticleSystem mainjet;
    [SerializeField] ParticleSystem leftjet;
    [SerializeField] ParticleSystem rightjet;
    Rigidbody rb;
    AudioSource audioSource;
    private void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();
    }
    private void OnEnable()
    {
        thrust.Enable();
        rotation.Enable();
    }
    private void FixedUpdate()
    {
        ProcessThrust();
        ProcessRotation();
    }

    private void ProcessThrust()
    {
        if (thrust.IsPressed())
        {
            rb.AddRelativeForce(Vector3.up * ThrustPower * Time.deltaTime);
            if (!audioSource.isPlaying)
                audioSource.PlayOneShot(mainEngine);
            if (!mainjet.isPlaying)
                mainjet.Play();
        }
        else
        {
            audioSource.Stop();
            mainjet.Stop();
        }
    }
    private void ProcessRotation()
    {
        float RotationInput = rotation.ReadValue<float>();
        if (RotationInput < 0)
        {
            if (!rightjet.isPlaying)
            {
                leftjet.Stop();
                rightjet.Play(); 
            }
           
               
            ApplyRotation(RotationPower);
        }
        else if (RotationInput > 0)
        {
            ApplyRotation(-RotationPower);
            if (!leftjet.isPlaying)
            {
                leftjet.Play();
                rightjet.Stop();
            }
                
        }
        else
        {
            rightjet.Stop();
            leftjet.Stop();

        }

    }

    private void ApplyRotation(float RotationThisFrame)
    {
        rb.freezeRotation = true;
        transform.Rotate(Vector3.forward * RotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;
    }
}
