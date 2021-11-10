using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScript : MonoBehaviour
{
    public LayerMask groundMask;
    public GameObject bottomCollider;
    public GameObject topCollider;
    public GameObject frontCollider;

    public float gravity = 9.8f;
    public float movementSpeed = 10f;
    public float rotationSpeed = 30f;
    public float height = 1f;

    Animator anim;

    enum States { jump, drop, idle};
    States states;
    // Start is called before the first frame update
    void Start()
    {
        states = States.idle;
        anim = GetComponentInChildren<Animator>();
    }

    RaycastHit hit;
    RaycastHit hitUp;

    Vector2 lastInput;

    private void FixedUpdate()
    {
        isTouchingCeiling = Physics.Raycast(new Ray(topCollider.transform.position - Vector3.up * 0.5f - (transform.forward * 0.5f * lastInput.y), Vector3.up), out hitUp, 1f, groundMask);
        Physics.Raycast(new Ray(bottomCollider.transform.position + Vector3.up * 0.5f - (transform.forward * 0.5f * lastInput.y), Vector3.down), out hit, Mathf.Infinity, groundMask);
        checkGround = Physics.Raycast(bottomCollider.transform.position + Vector3.up * 0.5f - (transform.forward * 0.5f * lastInput.y), Vector3.down, 1f, groundMask, QueryTriggerInteraction.Ignore);
    }

    float curveEquation(float a, float timeInterval, float originY)
    {
        float newHeight = -((timeInterval - a) * (timeInterval - a)) + (a * a);
        return newHeight + originY;
    }

    float checkForNextPoint(float a, float timeInterval, float originY)
    {
        return curveEquation(a, timeInterval + (Time.deltaTime * gravity), originY);
    }

    void changeIsGrounded(float a, float timeInterval, float originY)
    {
        if (hit.point.y - checkForNextPoint(a, timeInterval, originY) <= 0f)
        {
            isGrounded = false;
        }
        else
        {
            isGrounded = true;
        }
    }

    bool isTouchingCeiling;
    bool isGrounded;
    bool isJumping;

    IEnumerator Jump(float height)
    {
        float time = 0f;
        isJumping = true;
        float og = transform.position.y;
        float ogG = bottomCollider.transform.position.y;
        float ogT = topCollider.transform.position.y;
        for (; ; )
        {
            transform.position = new Vector3(transform.position.x, curveEquation(height, time, og), transform.position.z);
            changeIsGrounded(height, time, ogG);
            if (isTouchingCeiling && hitUp.point.y -  checkForNextPoint(height, time, ogT) <= 0f)
            {
                states = States.drop;
            }
            if(checkGround && time >= height && isGrounded)
            {
                states = States.jump;
            }
            if (states == States.jump)
            {
                states = States.idle;
                break;
            }
            else if(states == States.drop && height != 0f)
            {
                states = States.idle;
                break;
            }
            time += Time.deltaTime * gravity;
            yield return null;
        }
        isJumping = false;
    }

    bool checkGround;
    // Update is called once per frame
    void Update()
    {
        if(new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical")).magnitude != 0f)
        {
            lastInput = new Vector2(Input.GetAxis("Horizontal"),Input.GetAxis("Vertical"));
        }
        transform.position += Input.GetAxis("Vertical") * transform.forward * Time.deltaTime * movementSpeed;
        transform.eulerAngles += new Vector3(0f, Input.GetAxis("Horizontal") * Time.deltaTime * rotationSpeed, 0f);
        if (Input.GetButtonDown("Jump") && !isJumping && !isTouchingCeiling)
        {
            StartCoroutine(Jump(height));
        }
        if (checkGround)
        {
            transform.position = new Vector3(transform.position.x, hit.point.y - bottomCollider.transform.localPosition.y + Time.deltaTime, transform.position.z);
        }
        else if (!checkGround && !isJumping)
        {
            StartCoroutine(Jump(0f));
        }
        anim.SetFloat("Speed", new Vector2(Input.GetAxis("Horizontal"), Input.GetAxis("Vertical")).magnitude);
    }

    private void OnDrawGizmos()
    {
        Gizmos.DrawRay(new Ray(bottomCollider.transform.position + Vector3.up * 0.5f - (transform.forward * 0.5f * lastInput.y), Vector3.down));
        Gizmos.DrawRay(new Ray(topCollider.transform.position - Vector3.up * 0.5f - (transform.forward * 0.5f * lastInput.y), Vector3.up));
    }
}
