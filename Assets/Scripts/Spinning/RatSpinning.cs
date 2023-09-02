using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatSpinning : MonoBehaviour
{

    [SerializeField] SpinManager spinManagerScript;

    private float rotRate;
    private float waitMin, waitMax;
    private bool flipX, flipY, flipZ;
    private bool runningIENUM;
    private bool canSpin = false;
    private Quaternion origRot;
    private float waitingTime;

    private Vector3 toRot, up, right;

    private void Awake()
    {
        origRot = transform.rotation;
        
        toRot = Vector3.one;
        right = Vector3.Cross(toRot, Vector3.up);
        up = Vector3.Cross(toRot, right);
    }

    private void OnEnable()
    {
        spinManagerScript.TurnOffSpinScript();
    }

    private void OnDisable()
    {
        spinManagerScript.TurnOnSpinScript();
    }
    
    // Update is called once per frame
    void Update()
    {
        if (canSpin)
        {
            float rotX = flipX ? rotRate : -rotRate;
            float rotY = flipY ? rotRate : -rotRate;
            float rotZ = flipZ ? rotRate : -rotRate;
            
            rotX *= Time.deltaTime;
            rotY *= Time.deltaTime;
            rotZ *= Time.deltaTime;
            
            if (!runningIENUM)
            {
                StartCoroutine(flipDir());
            }
            
            transform.Rotate(rotX, rotY, rotZ);

        }
        else
        {
            StopSpinning();
        }
    }

    /// <summary>
    /// Stops the Flip Dir coroutine in case it is running and sets the current rotation
    /// of the spinning object to the original rotation - So it can be displayed properly.
    /// </summary>
    private void StopSpinning()
    {
        StopCoroutine(flipDir());
        transform.rotation = origRot;
    }

    // 
    private IEnumerator flipDir()
    {
        runningIENUM = true;
        waitingTime = Random.Range(waitMin, waitMax);
        yield return new WaitForSeconds(waitingTime);

        flipX = Random.Range(0f, 1f) > 0.5f ? true : false;
        flipY = Random.Range(0f, 1f) > 0.5f ? true : false;
        flipZ = Random.Range(0f, 1f) > 0.5f ? true : false;

        runningIENUM = false;
    }



    /// <summary>
    /// Sets if the spinner should run or not
    /// </summary>
    /// <param name="val"></param>
    public void SetRatCanSpin(bool val) { canSpin = val; }

    /// <summary>
    /// Sets the rotational speed of the rotating object.
    /// </summary>
    /// <param name="val"></param>
    public void SetRatRotSpeed(float val) { rotRate = val; }

    /// <summary>
    /// Sets the minimum wait time to continue rotating.
    /// </summary>
    /// <param name="val"></param>
    public void SetRatWaitMin(float val) { waitMin = val; }

    /// <summary>
    /// Sets the maximum waiting time to continue rotating.
    /// </summary>
    /// <param name="val"></param>
    public void SetRatWaitMax(float val) { waitMax = val; }


}
