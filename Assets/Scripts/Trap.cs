using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Trap : MonoBehaviour
{
    [SerializeField] GameObject surpriseGroup;
    [SerializeField] AudioSource surpriseSound;
    [SerializeField] ParticleSystem surpriseParticle;

    // Start is called before the first frame update
    void Start()
    {
        formSurprise();
    }

    
    private void formSurprise()
    {
        surpriseSound = surpriseGroup.GetComponentInChildren<AudioSource>();
        surpriseParticle = surpriseGroup.GetComponentInChildren<ParticleSystem>();
    }
    private void OnTriggerEnter(Collider other)
    {
        if(other.gameObject.CompareTag("Player"))
        {
            Debug.Log("you colided with" + gameObject.name);
            //surpriseGroup.SetActive(true);
            surpriseSound.Play();
            surpriseParticle.Play();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            Debug.Log("no more traps");
            gameObject.GetComponent<Collider>().enabled = false;

        }
    }
}
