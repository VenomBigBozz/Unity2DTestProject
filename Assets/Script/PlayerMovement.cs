using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public PlayerController controller;
    public float runSpeed = 40f;
    float horizontalMove = 0f;
    bool jump = false;
    bool crouch = false;
    public Animator m_Animator;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        horizontalMove = Input.GetAxisRaw("Horizontal") * runSpeed;

        m_Animator.SetFloat("Speed", Mathf.Abs(horizontalMove));

        if (Input.GetButtonDown("Jump"))
        {
            jump = true;
            m_Animator.SetBool("IsJumping", jump);
        }

        if (Input.GetButtonDown("Crouch")) crouch = true;

        else if (Input.GetButtonUp("Crouch")) crouch = false;
    }

    public void OnLanding()
    {
        m_Animator.SetBool("IsFalling", false);
    }

    private void FixedUpdate()
    {
        // Character move
        controller.Move(horizontalMove * Time.fixedDeltaTime, crouch, jump);
        jump = false;
    }
}
