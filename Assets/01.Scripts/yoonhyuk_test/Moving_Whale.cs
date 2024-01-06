using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Moving_Whale : MonoBehaviour
{
    public float spinan=0f;
    public float spin_speed = 0.3f;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        transform.rotation = Quaternion.Euler(0f, spinan, 0f);
        spinan += Time.deltaTime * spin_speed * 360;
        if(spinan >= 360f)
        {
            spinan = 0f;
        }
    }
}
