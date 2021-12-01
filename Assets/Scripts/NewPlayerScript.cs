using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewPlayerScript : MonoBehaviour
{
    public Rigidbody rb;
    Camera cam;
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
        cam = Camera.main;
    }

    void FixedUpdate()
    {
        isGrounded = Physics.CheckSphere(groundChecker.position, 0.2f);
    }

    public float speedUpTime;
    float slowDownTime;

    public void Die()
    {
        
    }

    public float curveEquation(float a, float timeInterval)
    {
        float newHeight = -((timeInterval - a) * (timeInterval - a)) + (a * a);
        return newHeight;
    }

    bool jump;

    bool previousGrounded;

    float jumpTime;

    Vector2 Direction;

    // Update is called once per frame
    void Update()
    {
        Direction = new Vector2(Input.GetAxis("Vertical"), Input.GetAxis("Horizontal"));
        Vector3 movementDirection = Vector3.Scale(cam.transform.rotation * new Vector3(Direction.y, 0f, Direction.x), new Vector3(1f, 0f, 1f));
        anim.SetFloat("Speed", Direction.magnitude);
        if(Direction.magnitude != 0f)
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
            jumpTime = 0f;
            jump = false;
            try
            {
                FindObjectOfType<JumppadScript>().jump = false;
            }
            catch
            {

            }
        }
        if (jump)
        {
            jumpTime += Time.deltaTime * 9.8f;
            rb.velocity = Vector3.up * curveEquation(3.5f, jumpTime) + transform.forward * (speedUpCurve.Evaluate(speedUpCurve.keys[speedUpCurve.length - 1].time) * 1.5f);
        }
        else
        {
            if (!isGrounded)
            {
                jumpTime += Time.deltaTime * 9.8f;
                rb.velocity = transform.forward * (speedUpCurve.Evaluate(speedUpTime) * 1.5f) + Vector3.up * curveEquation(0f, jumpTime);
            }
            else
            {
                jumpTime = 0f;
                rb.velocity = movementDirection * (speedUpCurve.Evaluate(speedUpTime) + slowDownCurve.Evaluate(slowDownTime)) + Vector3.up * rb.velocity.y;
            }
        }
        anim.SetBool("Jump", jump);
        previousGrounded = isGrounded;
        transform.forward = Vector3.Lerp(transform.forward, movementDirection, Time.deltaTime * turningCircle);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawWireSphere(groundChecker.position, 0.2f);
    }
}
