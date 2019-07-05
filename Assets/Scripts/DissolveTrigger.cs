using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DissolveTrigger : MonoBehaviour
{
    // store the mesh renderer
    public SkinnedMeshRenderer meshRenderer;
    public float dissolveValue = 0.001f;
    public float minimum = -1.0f;
    public float maximum = 1.0f;
    public float t = 1.0f;
    public float dissolvedSpeed = 0.3f;
    private bool isDissolve = false;
    

    private void Update()
    {
        if (Input.GetKeyDown(KeyCode.D))
            isDissolve = !isDissolve;

        if (isDissolve)
            DissolveOut();
        //else
        //    DissolveIn();
        meshRenderer.material.SetFloat("Vector1_5FD04FB2", dissolveValue);
        
           
    }

    // make the model slow disappear
    private void DissolveOut()
    {
        dissolveValue = Mathf.Lerp(minimum, maximum, t);
        // .. and increase the t interpolater
        t += dissolvedSpeed * Time.deltaTime;

        // now check if the interpolator has reached 1.0
        // and swap maximum and minimum so game object moves
        // in the opposite direction.
        if (t > 1.0f)
        {
            float temp = maximum;
            maximum = minimum;
            minimum = temp;
            t = 0.001f;
        }

        // shader has a bug when it is set to 0.0f
        if (t == 0.0f)
            t = 0.001f;
    }

    private void DissolveIn()
    {

    }
}
