using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public Transform groundChecker;
    public AnimationCurve speedUpCurve;
    public AnimationCurve slowDownCurve;
    public float turningCircle = 10f;
    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.2f);
    }

    float speedUpTime;
    float slowDownTime;

    float curveEquation(float a, float timeInterval)
    {
        float newHeight = -((timeInterval - a) * (timeInterval - a)) + (a * a);
        return newHeight;
    }

    bool jump;

    float jumpTime;

    // Update is called once per frame
    void Update()
    {
        if(Input.GetAxis("Vertical") != 0f)
        {
            slowDownTime = 0f;
            speedUpTime += Time.deltaTime;
        }
        else
        {
            speedUpTime = 0f;
            slowDownTime += Time.deltaTime;
        }
        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            jump = true;
        }
        if(isGrounded && jumpTime >= 0.5f)
        {
            jump = false;
        }
        if (jump)
        {
            jumpTime += Time.deltaTime;
        }
        else
        {
            jumpTime = 0f;
        }
        transform.eulerAngles += Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal") * turningCircle;
        rb.velocity = Input.GetAxis("Vertical") * transform.forward * (speedUpCurve.Evaluate(speedUpTime) + slowDownCurve.Evaluate(slowDownTime)) + Vector3.up * rb.velocity.y;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, 0.2f);
    }
}
