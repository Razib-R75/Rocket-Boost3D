using UnityEngine;
using UnityEngine.SceneManagement;

public class Oncolusoin : MonoBehaviour
{
    [SerializeField]float levelLodeDiley = 2f;
    [SerializeField] AudioClip success;
    [SerializeField] AudioClip crusht;

    [SerializeField] ParticleSystem successParti;
    [SerializeField] ParticleSystem CrushParti;

    AudioSource audioSource;
    bool isTransitioning = false;
    bool ColutionDisable = false;
    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }

    void Update()
    {
        RespondToDebugKey();
    }
    void RespondToDebugKey()
    {
        if (Input.GetKeyDown(KeyCode.L))
        {
            lodeNextLevel();
        }  
        else if (Input.GetKeyDown(KeyCode.C))
        {
            ColutionDisable = !ColutionDisable;
        }
    }

    void OnCollisionEnter(Collision other)
    {

        if (isTransitioning||ColutionDisable) { return; }

            switch (other.gameObject.tag)
            {
                case "Friendly":
                    Debug.Log("This thing is friendly");
                    break;


                case "Finish":
                    startSuccessSequance();
                    break;


                default:
                    StartCrashSquance();
                    break;

            }
        
    }
    void startSuccessSequance()
    {
        isTransitioning = true;

        audioSource.Stop();
        audioSource.PlayOneShot(success);

        successParti.Play();

        GetComponent<Movement>().enabled = false;
        Invoke("lodeNextLevel", levelLodeDiley);
    }
    void RelodeLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }
    void lodeNextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        
        int nextSceneIndex = currentSceneIndex + 1;
        if(nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }
        SceneManager.LoadScene(nextSceneIndex);
    }
    void StartCrashSquance()
    {
        isTransitioning = true;
        audioSource.Stop();

        audioSource.PlayOneShot(crusht);
        CrushParti.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("RelodeLevel",levelLodeDiley);
    }

}
