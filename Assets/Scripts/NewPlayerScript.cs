using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    Rigidbody rb;
    public GameObject jumpFX;
    public Transform groundChecker;
    public AnimationCurve speedUpCurve;
    public AnimationCurve slowDownCurve;
    public float turningCircle = 10f;

    Animator anim;

    bool isGrounded;

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponentInChildren<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
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

    bool previousGrounded;

    float jumpTime;

    // Update is called once per frame
    void Update()
    {
        anim.SetFloat("Speed", Input.GetAxis("Vertical"));
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
            Instantiate(jumpFX, transform.position, Quaternion.identity);
            jump = true;
        }
        else if (isGrounded && !previousGrounded)
        {
            jump = false;
        }
        if (jump)
        {
            jumpTime += Time.deltaTime * 9.8f;
            rb.velocity = Vector3.up * curveEquation(3.5f, jumpTime) + transform.forward * speedUpCurve.Evaluate(speedUpTime);
        }
        else
        {
            jumpTime = 0f;
            rb.velocity = Input.GetAxis("Vertical") * transform.forward * (speedUpCurve.Evaluate(speedUpTime) + slowDownCurve.Evaluate(slowDownTime)) + Vector3.up * rb.velocity.y;
        }
        anim.SetBool("Jump", jump);
        transform.eulerAngles += Vector3.up * Time.deltaTime * Input.GetAxis("Horizontal") * turningCircle;
        previousGrounded = isGrounded;
    }
    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, 0.2f);
    }
}
