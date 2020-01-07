using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    bool hasImpacted = false;
    public LayerMask layerMask = 1;
    float timeSinceImpact;

    public ParticleSystem impactEffect;

    // Start is called before the first frame update
    void Start()
    {
        this.impactEffect.gameObject.SetActive(false);
    }

    void Update()
    {
        if (hasImpacted)
        {
            timeSinceImpact += Time.deltaTime;
        }
        if (timeSinceImpact >= .1)
        {
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {   
        hasImpacted = true;
        print(hasImpacted);
        this.impactEffect.gameObject.SetActive(true);
        this.GetComponent<Renderer>().enabled = !GetComponent<Renderer>().enabled;
    }

    
}
