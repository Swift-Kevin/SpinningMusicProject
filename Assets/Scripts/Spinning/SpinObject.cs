using System.Collections;
using System.Collections.Generic;
using System.Net.NetworkInformation;
using UnityEngine;

public class SpinObject : MonoBehaviour
{
    [SerializeField] SpinManager spinManagerScript;

    private bool canSpin = false;
    private Quaternion origRot;

    private Quaternion targetRotation;
    private float rotationTime = 0f;
    private float range = 0.35f; 

    private void Start()
    {
        origRot = transform.rotation;
    }

    // Update is called once per frame
    void Update()
    {
        if (canSpin)
        {

            rotationTime += Time.deltaTime;

            transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime);

            if (rotationTime >= range)
            {
                GenerateRandomRotation();
            }
        }
        else
        {
            StopSpinning();
        }
    }
    void GenerateRandomRotation()
    {
        Vector3 randomAxis = Random.insideUnitSphere;
        float randomAngle = Random.Range(0f, 360f); 

        targetRotation = Quaternion.AngleAxis(randomAngle, randomAxis);
        rotationTime = 0f;
    }
   
    /// <summary>
    /// Stops the Flip Dir coroutine in case it is running and sets the current rotation
    /// of the spinning object to the original rotation - So it can be displayed properly.
    /// </summary>
    private void StopSpinning()
    {
        transform.rotation = origRot;
    }

    /// <summary>
    /// Sets if the spinner should run or not
    /// </summary>
    /// <param name="val"></param>
    public void SetCanSpin(bool val) { canSpin = val; }


}
