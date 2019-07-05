using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    // store the mesh renderer
    public SkinnedMeshRenderer meshRenderer;
    public string shaderDissolveValueKey = "Vector1_5FD04FB2";
    public float startDissolve = 0f;
    public float reformStart = 1f;
    private float dissolveRate = 0.01f;
    private bool readyToDissolve = true;



    private void Update()
    {
        // press d and start the dissolving
        if (Input.GetKeyDown(KeyCode.D))
        {
            if (readyToDissolve)
                InvokeDissolve();
        }
           

        if (Input.GetKeyDown(KeyCode.A))
        {
            if (!readyToDissolve)
                InvokeReform();
        }
            
    }

    private void InvokeDissolve ()
    {
        // repeating call the Dissolve function at a dissolve rate seconds
        startDissolve = 1;
        readyToDissolve = false;
        InvokeRepeating("Dissolve", 0, dissolveRate);
    }

    private void InvokeReform()
    {
        // repeating call the Reform function at a dissolve rate seconds
        startDissolve = 0.001f;
        readyToDissolve = true;
        InvokeRepeating("Reform", 0, dissolveRate);
    }

    private void Dissolve()
    {
        // if in the middle of reforming, cancel it
        CancelInvoke("Reform");

        meshRenderer.material.SetFloat(shaderDissolveValueKey, startDissolve -= dissolveRate);
        if (meshRenderer.material.GetFloat(shaderDissolveValueKey) <= 0.01)
        {
            readyToDissolve = false;
            CancelInvoke("Dissolve");
        }
    }

    private void Reform()
    {
        // if in the middle of dissolving, cancel it
        CancelInvoke("Dissolve");

        meshRenderer.material.SetFloat(shaderDissolveValueKey, startDissolve += dissolveRate);
        if (meshRenderer.material.GetFloat(shaderDissolveValueKey) >= 0.95)
        {
            readyToDissolve = true;
            CancelInvoke("Reform");
        }
    }

}
