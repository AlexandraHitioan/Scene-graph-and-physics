using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class robotMovement : MonoBehaviour
{
    
    private float speed = 40.0f;
    private const float minRotation = -20.0f;
    private const float maxRotation = 20.0f;

    private float cRotation;
    
    private bool validRotationReset = true;
    
    public GameObject rightHip;
    public GameObject leftHip;
    
    public GameObject rightKnee;
    public GameObject leftKnee;
    
    public GameObject rightFoot;
    public GameObject leftFoot;
    
    public GameObject rightShoulderJoint;
    public GameObject leftShoulderJoint;

    public GameObject rightShoulder;
    public GameObject leftShoulder;
    
    public GameObject rightArm;
    public GameObject leftArm;
    

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
            if (transform.position.z < 9.1f)
            {
                moveForward();
                moveHands();
                moveLegs();
                //FeetMovement();
            }
            else if (transform.position.z >= 9.1f && validRotationReset)
            {
                resetHands();
                resetLegs();
                validRotationReset = false;
            }

    }
    
    private void moveHands()
    {
        var deltaTime = Time.deltaTime;
        var x1 = cRotation + speed*deltaTime;
        if (x1 > maxRotation)
            speed = -1 * Mathf.Abs(speed);
        else if (x1 < minRotation)
            speed = Mathf.Abs(speed);
        cRotation += speed*deltaTime;
        leftShoulderJoint.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.forward);
        rightShoulderJoint.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.back);
        
        leftArm.transform.localRotation = Quaternion.AngleAxis(cRotation/4, Vector3.forward);
        rightArm.transform.localRotation = Quaternion.AngleAxis(cRotation/4, Vector3.back);

    }

    private void moveLegs()
    { 
        var minRotationLeg = minRotation - 3;
        var maxRotationLeg = maxRotation + 3;
        var dt = Time.deltaTime;
        var x1 = cRotation + speed * dt;
        if (x1 > maxRotationLeg)
           speed = -1 * Mathf.Abs(speed);
        else if (x1 < minRotationLeg)
            speed = Mathf.Abs(speed);
        leftKnee.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.left);
        rightKnee.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.right);
     
        leftHip.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.left);
        rightHip.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.right);
    }
    
    
    private void resetHands()
    {
        cRotation = 0f;
        rightShoulderJoint.transform.localRotation = Quaternion.identity;
        leftShoulderJoint.transform.localRotation = Quaternion.identity;
        rightArm.transform.localRotation = Quaternion.identity;
        leftArm.transform.localRotation = Quaternion.identity;
    }

    private void resetLegs()
    {
        cRotation = 0f;
        rightHip.transform.localRotation = Quaternion.identity;
        leftHip.transform.localRotation = Quaternion.identity;
    }
    
    
    private void moveForward()
    {
        transform.Translate(0, 0,  Time.deltaTime);
    }
    
    private void moveFeet()
    {
        var maxRotationFeet = maxRotation - 10;
        var minRotationFeet = minRotation + 13;
        var dt = Time.deltaTime;
        var x1 = cRotation + speed * dt;
        if (x1 > maxRotationFeet)
            speed = -1 * Mathf.Abs(speed);
        else if (x1 < minRotationFeet)
            speed = Mathf.Abs(speed);
        leftFoot.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.left);
        rightFoot.transform.localRotation = Quaternion.AngleAxis(cRotation, Vector3.right);
    }
}