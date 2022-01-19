using UnityEngine;
using UnityEngine.SceneManagement;


public class CollisionHandler : MonoBehaviour
{

    private float delay = 3;
    private AudioSource audioSource;

    public AudioClip crashAudio;
    public AudioClip finishAudio;

    [SerializeField] ParticleSystem crashParticles;
    [SerializeField] ParticleSystem finishParticles;

    bool isTransitioning = false;
    bool collisionDisabled = false;


    void Start()
    {
        audioSource = GetComponent<AudioSource>();
    }



    private void OnCollisionEnter(Collision other)
    {
        if (isTransitioning == true || collisionDisabled)
        {
            return;
        }

        switch (other.gameObject.tag)
        {

            case "Launchpad":
                Debug.Log("Launchpad touched!");
                break;

            case "FinishTag":
                FinishedLevel();
                break;

            default:
                StartCrashSequence();
                break;
        }
    }

    

    void ReloadLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        SceneManager.LoadScene(currentSceneIndex);
    }

    /*void NextLevel()
    {
        int currentSceneIndex = SceneManager.GetActiveScene().buildIndex;
        int nextSceneIndex = currentSceneIndex + 1;
        if (nextSceneIndex == SceneManager.sceneCountInBuildSettings)
        {
            nextSceneIndex = 0;
        }

        SceneManager.LoadScene(nextSceneIndex);
    }*/

    /*private void Update()
    {
        Cheats();
    }*/




    /*void Cheats()
    {

        if (Input.GetKeyDown(KeyCode.L))
        {
            NextLevel();
        }

        else if (Input.GetKeyDown(KeyCode.C))
        {
            collisionDisabled = !collisionDisabled; // toggle collision
        }
    }*/

    void StartCrashSequence()
    {

        isTransitioning = true;
        //audioSource.Stop();
        audioSource.PlayOneShot(crashAudio);
        crashParticles.Play();
        GetComponent<Movement>().enabled = false;
        Invoke("ReloadLevel", delay);

    }

    void FinishedLevel()
    {

        isTransitioning = true;
        //audioSource.Stop();
        audioSource.PlayOneShot(finishAudio);
        finishParticles.Play();
        GetComponent<Movement>().enabled = false;
        //Invoke("NextLevel", delay);

    }
}

