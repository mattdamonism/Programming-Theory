using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Animal : MonoBehaviour
{
    protected float movementSpeed = 3;
    protected float jumpForce = 5;
    protected bool canJump = true;

    abstract public string AnimalName { get; set; }

    Animator anim;
    Rigidbody rb;

    protected virtual void Start()
    {
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 movement = new Vector3(moveHorizontal, 0.0f, moveVertical);

        if (movement != Vector3.zero)
        {
            transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(movement), 0.15f);
            anim.SetInteger("Walk", 1);
        }
        else
        {
            anim.SetInteger("Walk", 0);
        }

        transform.Translate(movement * movementSpeed * Time.deltaTime, Space.World);

        if (Input.GetButtonDown("Jump") && canJump)
        {
            Jump();
        }
    }

    public virtual void Jump()
    {
        rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
        anim.SetTrigger("jump");
        canJump = false;
    }

    private void OnCollisionEnter(Collision collision)
    {
        GameObject other = collision.gameObject;
        if (other.CompareTag("Ground") || other.CompareTag("Tree"))
        {
            canJump = true;
        }
    }

    public void Stop()
    {
        anim.SetInteger("Walk", 0);
    }

    private void OnMouseOver()
    {
        if (Input.GetMouseButtonDown(0))
        {
            PlayerControl.Instance.SelectAnimal(this);
        }
        if (Input.GetMouseButtonDown(1))
        {
            PlayerControl.Instance.RenameAnimal(this);
        }
    }
}
