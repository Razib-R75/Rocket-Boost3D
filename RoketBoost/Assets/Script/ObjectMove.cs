using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObjectMove : MonoBehaviour
{
    [SerializeField][Range(0,1)]float MovmentFector;
    Vector3 StatPosition;
    [SerializeField] Vector3 MovementVector;
    [SerializeField] float period = 2f;
    // Start is called before the first frame update
    void Start()
    {
        StatPosition = transform.position;  
    }

    // Update is called once per frame
    void Update()
    {
        if (period <= Mathf.Epsilon)
        {
            return;
        }
        float cycles = Time.time / period; // continually growing
        
        const float tau = Mathf.PI * 2; // constant value 6.283
       
        float rawsineWave = Mathf.Sin(cycles * tau);// going from -1 to 1


        MovmentFector = (rawsineWave + 1f) / 2f;// re calculetor 
        
        Vector3 offset = MovementVector * MovmentFector;
        transform.position = StatPosition + offset;
    }
}
