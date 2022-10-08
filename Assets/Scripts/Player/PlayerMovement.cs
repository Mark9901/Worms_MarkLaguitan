using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private PlayerManager manager;

    ////Camera
    [SerializeField] private Camera characterCamera;
    [SerializeField] private float speedH = 2.0f;
    [SerializeField] private float speedV = 2.0f;
    [SerializeField] private float pitchClamp = 90;

    private float yaw = 0.0f;
    private float pitch = 0.0f;

    //player
    public Transform player;
    
    //movement
    [SerializeField] public float movementSpeed;
    [SerializeField] private float rotationSpeed;

    //jump
    private Vector3 jump;
    public float jumpAmount = .05f;

    //check ground
    private bool isGrounded = false;
    private float distToGround = 0.5f;

    // Start is called before the first frame update
    void Start()
    {
        jump = new Vector3(0, 2f, 0);

        Cursor.lockState = CursorLockMode.Confined;
    }

    // Update is called once per frame
    void Update()
    {
        if (manager.PlayerCanPlay())
        {
            Movement();
            Shoot();
            ReadRotationInput();
        }
        
    }

    private void FixedUpdate()
    {
        CheckGround();
    }

    void Movement()
    {
        if (Input.GetAxis("Horizontal") != 0)
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.transform.Rotate(Vector3.up * rotationSpeed * Time.deltaTime * Input.GetAxis("Horizontal"), Space.World);
        }

        if (Input.GetAxis("Vertical") != 0)
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.transform.Translate(currentPlayer.transform.forward * movementSpeed * Time.deltaTime * Input.GetAxis("Vertical"), Space.World);
        }

        if (Input.GetKeyDown(KeyCode.Space) && isGrounded)
        {
            Jump();
        }
    }

    void Shoot()
    {
        if (Input.GetAxis("Vertical") == 0 && Input.GetAxis("Horizontal") == 0 && Input.GetKeyDown(KeyCode.Q))
        {
            ActivePlayer currentPlayer = manager.GetCurrentPlayer();
            currentPlayer.FireProjectile();
        }
    }

    void Jump()
    {
        ActivePlayer currentPlayer = manager.GetCurrentPlayer();
        currentPlayer.GetComponent<Rigidbody>().AddForce(jump * jumpAmount, ForceMode.Impulse); 

    }

    void CheckGround()
    {
        if(Physics.Raycast(transform.position,Vector3.down,distToGround +0.1f))
        {
            isGrounded = true;
        }
        else
        {
            isGrounded = false;
        }
    }
    private void ReadRotationInput()
    {
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch -= speedV * Input.GetAxis("Mouse Y");
        pitch = Mathf.Clamp(pitch, -pitchClamp, pitchClamp);

        characterCamera.transform.localEulerAngles = new Vector3(pitch, 0.0f, 0.0f);
        transform.eulerAngles = new Vector3(0.0f, yaw, 0.0f);
    }
    private void OnTriggerStay(Collider other)
    {
        if(other.gameObject.CompareTag("Slow"))
        {
            movementSpeed = movementSpeed * .2f ;
            Debug.Log("SLowed");
        }
        if(other.gameObject.CompareTag("Fast"))
        {
            movementSpeed = movementSpeed * 1.05f;
                Debug.Log("Fast");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.CompareTag("Slow"))
        {
            movementSpeed = movementSpeed * 1;
        }
        if (other.gameObject.CompareTag("Fast"))
        {
            movementSpeed = movementSpeed * 1;
        }
    }
}
