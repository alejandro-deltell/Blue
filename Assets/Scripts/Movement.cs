using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

/*public class Movement : MonoBehaviour
{
    Rigidbody rb;
    AudioSource audioSouce;

    public float mainThrust = 100f;
    public float rotationSpeed = 100f;
    public AudioClip mainEngine;

    public bool isAlive = true;
    public bool hasFinished = false;

    public ParticleSystem centralBoost;
    public ParticleSystem leftParticles;
    public ParticleSystem rightParticles;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSouce = GetComponent<AudioSource>();
    }

    // Update is called once per frame
    void Update()
    {
        ProcessThrust();
        ProcessRotation();
    }


    void ProcessThrust()
    {

        if (Input.GetKey(KeyCode.Space) && isAlive)
        {
            rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

            if (!audioSouce.isPlaying)
            {
                audioSouce.PlayOneShot(mainEngine);
            }

            if (!centralBoost.isPlaying)
            {
                centralBoost.Play();

            }
        }

        else
        {
            audioSouce.Stop();
            centralBoost.Stop();
        }

    }

    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            ApplyRotation(rotationSpeed);

            if (!rightParticles.isPlaying)
            {
                rightParticles.Play();
            }

            else if (Input.GetKey(KeyCode.D))
            {
                ApplyRotation(-rotationSpeed);
                if (!leftParticles.isPlaying)
                {
                    leftParticles.Play();
                }
            }

            else
            {
                rightParticles.Stop();
                leftParticles.Stop();
            }
        }

        void ApplyRotation(float rotationThisFrame)
        {
            rb.freezeRotation = true; // freezing rotation so we can manually rotate
            transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
            rb.freezeRotation = false; // unfreezing rotation so the physics system can take over
        }


    }
}
*/

using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    // PARAMETERS - for tuning, typically set in the editor
    // CACHE - e.g. references for readability or speed
    // STATE - private instance (member) variables

    [SerializeField] float mainThrust = 2000f;
    [SerializeField] float rotationThrust = 2000f;
    [SerializeField] AudioClip mainEngine;

    [SerializeField] ParticleSystem mainEngineParticles;


    Rigidbody rb;
    AudioSource audioSource;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {
        Thrusting();
        ProcessRotation();
    }



    void ProcessRotation()
    {
        if (Input.GetKey(KeyCode.A))
        {
            RightRotation();
        }
        else if (Input.GetKey(KeyCode.D))
        {
            LeftRotation();
        }
    }

    void Thrusting()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartThrusting();
        }
        else
        {
            StopThrusting();
        }
    }

    void StartThrusting()
    {
        rb.AddRelativeForce(Vector3.up * mainThrust * Time.deltaTime);

        if (!mainEngineParticles.isPlaying)
        {
            mainEngineParticles.Play();
        }
    }

    void StopThrusting()
    {
        mainEngineParticles.Stop();
    }



    void RightRotation()
    {
        ApplyRotation(rotationThrust);
    }

    void LeftRotation()
    {
        ApplyRotation(-rotationThrust);
    }

    void ApplyRotation(float rotationThisFrame)
    {
        rb.freezeRotation = true;  // freezing rotation so we can manually rotate
        transform.Rotate(Vector3.forward * rotationThisFrame * Time.deltaTime);
        rb.freezeRotation = false;  // unfreezing rotation so the physics system can take over
    }
}
