using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementManager : MonoBehaviour
{
    [SerializeField] private Rigidbody2D playersRigidbody;
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 50f;
    [SerializeField] private LayerMask groundLayer;
    [SerializeField] private Transform playerFoot;
    float moveX;
    bool jump = false;

    // Start is called before the first frame update
    void Start()
    {
        playersRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {

        HandleInput();

    }

    private void FixedUpdate()
    {
        HandleMovement();
    }

  

    private void HandleInput()
    {
        moveX = 0f;
        if (Input.GetKey(KeyCode.D))
        {
            moveX = 1f;
        }
        if (Input.GetKey(KeyCode.A))
        {
            moveX = -1f;
        }
        if (Input.GetKeyDown(KeyCode.Space))
        {
            jump = true;
        }
    }
    private void HandleMovement()
    {
        if (jump)
        {
            if (CheckGround())
            {
            playersRigidbody.AddForce(Vector2.up * jumpForce * Time.deltaTime, ForceMode2D.Impulse);
            jump = false;
            }
        }
        playersRigidbody.velocity = new Vector2(moveX * moveSpeed * Time.deltaTime, playersRigidbody.velocity.y);
    }
    private bool CheckGround()
    {
        Debug.DrawRay(playerFoot.position, Vector2.down*0.5f, Color.red,1f);
        return Physics2D.Raycast(playerFoot.position, Vector2.down, 0.5f, groundLayer);
    }
}

