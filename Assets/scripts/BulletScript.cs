using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletScript : MonoBehaviour
{
    bool hasImpacted = false;
    public LayerMask layerMask = 1;
    float timeSinceImpact;
    float timeSinceFired;

    public ParticleSystem impactEffect;

    bool hasFired;

    // Start is called before the first frame update
    void Start()
    {
        impactEffect.gameObject.SetActive(false);
    }

    void Update()
    {
        timeSinceFired += Time.deltaTime;
        if ((hasImpacted || timeSinceFired >= 3) && gameObject.name != "Bullet")
        {
            timeSinceImpact += Time.deltaTime;
            Destroy(this.gameObject);
        }
    }

    // Update is called once per frame
    void OnCollisionEnter(Collision collision)
    {   
        hasImpacted = true;
        print(hasImpacted);
        if (gameObject.name != "Bullet")
        {
            ParticleSystem impactEffectInstance = Instantiate(impactEffect, new Vector3(transform.position.x, transform.position.y, transform.position.z), transform.rotation);
            impactEffectInstance.gameObject.AddComponent<ParticleExpiration>();
            impactEffectInstance.gameObject.SetActive(true);
        }
    }

    
}
