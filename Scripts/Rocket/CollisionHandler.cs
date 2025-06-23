using System.Collections;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;




public class CollisionHandler : MonoBehaviour
{
    [SerializeField] float levelload = 2f;
    [SerializeField] AudioClip crash;
    [SerializeField] AudioClip succes;
    [SerializeField] ParticleSystem bomba;
    [SerializeField] ParticleSystem yay;

    AudioSource AudioSource;
    bool IsControllable = true;
    bool IsCollidable = true;
    private void Start()
    {
        AudioSource = GetComponent<AudioSource>();
    }
    private void Update()
    {
        DebugKeys();

    }

    private void DebugKeys()
    {
        if (Keyboard.current.lKey.wasPressedThisFrame)
            LoadNextLevel();
        else if (Keyboard.current.kKey.wasPressedThisFrame)
            IsCollidable = !IsCollidable;

    }

    private void OnCollisionEnter(Collision other)
    { if (IsControllable && IsCollidable)
            switch (other.gameObject.tag)
            {
                case "friendly":
                    break;
                case "Finish":
                    StartSuccesSequence();
                    break;
                default:
                    StartCrashSequence();

                    break;
            }
        else
            return;

    }
    void StartSuccesSequence()
    {
        yay.Play();
        AudioSource.Stop();
        IsControllable = false;
        AudioSource.PlayOneShot(succes);
        GetComponent<movement>().enabled = false;
        Invoke("LoadNextLevel", levelload);
        
    }
    
    void StartCrashSequence()
    {
        bomba.Play();
        AudioSource.Stop();
        IsControllable = false;
        AudioSource.PlayOneShot(crash);
        GetComponent<movement>().enabled = false;
        Invoke("ReloadLevel", levelload);
    }
    private void LoadNextLevel()
    {
        
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        int nextscene = CurrentScene + 1;
        if (nextscene == SceneManager.sceneCountInBuildSettings)
            nextscene = 0;
        SceneManager.LoadScene(nextscene);

    }
    private void ReloadLevel()
    {
        int CurrentScene = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(CurrentScene);
    }
}
