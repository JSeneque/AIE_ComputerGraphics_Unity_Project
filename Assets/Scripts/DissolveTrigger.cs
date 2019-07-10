using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    // This class controls the dissolving and reforming shader that is attached to a gameobject

    // store the mesh renderer
    public SkinnedMeshRenderer meshRenderer;
    private readonly string shaderDissolveValueKey = "Vector1_5FD04FB2";
    private float startDissolve = 0f;
    private readonly float reformStart = 1f;
    private readonly float dissolveRate = 0.01f;
    private bool readyToDissolve = true;

    

    public void InvokeDissolve ()
    {
        if (readyToDissolve)
        {
            // repeating call the Dissolve function at a dissolve rate seconds
            startDissolve = 1;
            readyToDissolve = false;
            InvokeRepeating("Dissolve", 0, dissolveRate);
        }
    }

    public void InvokeReform()
    {
        if (!readyToDissolve)
        {
            // repeating call the Reform function at a dissolve rate seconds
            startDissolve = 0.001f;
            readyToDissolve = true;
            InvokeRepeating("Reform", 0, dissolveRate);
        }
    }

    private void Dissolve()
    {
        // if in the middle of reforming, cancel it
        CancelInvoke("Reform");

        // decrement the value
        meshRenderer.material.SetFloat(shaderDissolveValueKey, startDissolve -= dissolveRate);

        // check once the value hits the lower limit. Bug at 0.0f
        if (meshRenderer.material.GetFloat(shaderDissolveValueKey) <= 0.01)
        {
            // it's now ready to be reformed again
            readyToDissolve = false;

            // cancel the dissolving
            CancelInvoke("Dissolve");
        }
    }

    private void Reform()
    {
        // if in the middle of dissolving, cancel it
        CancelInvoke("Dissolve");

        // increment the value
        meshRenderer.material.SetFloat(shaderDissolveValueKey, startDissolve += dissolveRate);

        // check once the value hits the upper limit. Bug at 1.0f
        if (meshRenderer.material.GetFloat(shaderDissolveValueKey) >= 0.95)
        {
            // it's now ready to be dissolved again
            readyToDissolve = true;

            // cancel the reforming
            CancelInvoke("Reform");
        }
    }

}
