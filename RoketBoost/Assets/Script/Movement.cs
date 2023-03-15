using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody rb;

    AudioSource audioSource;

    [SerializeField]float mainthrash = 100f;
    [SerializeField]float rotetionthraash = 1f;
    [SerializeField]AudioClip mainEnging;
    [SerializeField] ParticleSystem mainengingParti;
    [SerializeField] ParticleSystem LaftSideParti;
    [SerializeField] ParticleSystem RightSideParti;



    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        audioSource = GetComponent<AudioSource>();

    }

    // Update is called once per frame
    void Update()
    {
        processTharash();
        prrossRotetion();

         
    }
    void processTharash()
    {
        if (Input.GetKey(KeyCode.Space))
        {
            StartTharsh();
        }
        else
        {
            StopTharshing();
        }

    }
    void prrossRotetion()
    {
        if (Input.GetKey(KeyCode.D))
        {
            RotationRight();
        }
        else if (Input.GetKey(KeyCode.A))
        {
            RotetionLaft();
        }
        else
        {
            StopRotetion();
        }
    }


    private void StartTharsh()
    {
        rb.AddRelativeForce(Vector3.up * Time.deltaTime * mainthrash);

        if (!audioSource.isPlaying)
        {
            audioSource.PlayOneShot(mainEnging);
        }
        if (!mainengingParti.isPlaying)
        {
            mainengingParti.Play();
        }
    }
    private void StopTharshing()
    {
        audioSource.Stop();
        mainengingParti.Stop();
    }

   
    private void StopRotetion()
    {
        RightSideParti.Stop();
        LaftSideParti.Stop();
    }

    private void RotetionLaft()
    {
        aplyrotetuon(-rotetionthraash);
        if (!RightSideParti.isPlaying)
        {
            RightSideParti.Play();
        }
    }

    private void RotationRight()
    {
        aplyrotetuon(rotetionthraash);
        if (!LaftSideParti.isPlaying)
        {
            LaftSideParti.Play();
        }
    }

    void aplyrotetuon(float rrot)
    {
        rb.freezeRotation = true;
        
        transform.Rotate(-Vector3.forward * Time.deltaTime * rrot);

        rb.freezeRotation = false;
       
    }
}
