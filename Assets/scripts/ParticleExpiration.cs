using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ParticleExpiration : MonoBehaviour
{
    float timeSinceInstantiation;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        timeSinceInstantiation += Time.deltaTime;
        if(timeSinceInstantiation >= .7)
        {
            Destroy(this.gameObject);
        }
    }
}
