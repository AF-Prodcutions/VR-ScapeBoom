using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class Keycard : XRGrabInteractable
{
    private ApplyPhysics applyPhysics = null;
    private Collider currentCollider = null;

    private void Start()
    {
        currentCollider = GetComponent<Collider>();
        applyPhysics = GetComponent<ApplyPhysics>();
        StartCoroutine(EjectOverSeconds(1.5f));
    }

    public IEnumerator EjectOverSeconds(float seconds)
    {
        applyPhysics.DisablePhysics();
        currentCollider.enabled = false;

        float elapsedTime = 0;
        while (elapsedTime < seconds)
        {
            transform.position += transform.forward * Time.deltaTime * 0.1f;
            elapsedTime += Time.deltaTime;

            yield return null;
        }

        currentCollider.enabled = true;
    }
}

