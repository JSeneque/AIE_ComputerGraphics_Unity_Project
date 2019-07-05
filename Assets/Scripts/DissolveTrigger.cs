using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    // store the mesh renderer
    public SkinnedMeshRenderer meshRenderer;
     

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            meshRenderer.material.SetFloat("Vector1_19BE8542", Time.time);
    }

}
