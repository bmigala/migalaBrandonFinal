/*************************************************************
//File Name :       PlayerController.cs
//Author :          Brandon Migala
//Creation Date :   March 2, 2025
//
//Brief Description : This document allows the player to move.
*************************************************************/
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{
    // Lists the variables used to control the player.
    [SerializeField] private PlayerInput playerInput;
    [SerializeField] private float jumpValue = 7f;

    private InputAction move;
    private InputAction freeze;
    private InputAction restart;
    private InputAction quit;
    private Rigidbody rb;
    private Transform _camera;
    private Vector3 playerMovement;
    private Vector3 playerScale;
    private Animator animator;
    private PauseMenu pauseMenu;
    private bool sliding;
    private bool canAttack;
    public AudioSource JumpSound;
    public AudioSource AttackSound;
    [SerializeField] private Transform model;
    [HideInInspector] public bool isNoving = true;
    private Vector3 inputMovement;
    private Vector3 lastInputMovement;
    [SerializeField] private float playerSpeed;
    [SerializeField] private float BoxCastDistance;
    [SerializeField] private LayerMask jumpMask;
    [SerializeField] private GameObject sicklePrefab;

    /// <summary>
    /// Start is called before the first frame update
    /// </summary>
    void Start()
    {
        rb = GetComponent<Rigidbody>();
        playerInput.currentActionMap.Enable();
        move = playerInput.currentActionMap.FindAction("Move");
        freeze = playerInput.currentActionMap.FindAction("Freeze");
        restart = playerInput.currentActionMap.FindAction("Restart");
        quit = playerInput.currentActionMap.FindAction("Quit");
        _camera = Camera.main.transform;
        pauseMenu = FindAnyObjectByType<PauseMenu>();
        canAttack = true;

        move.started += Move_started;
        move.canceled += Move_canceled;
        freeze.performed += Freeze_performed;
        restart.performed += Restart_performed;
        quit.performed += Quit_performed;
        animator = GetComponent<Animator>();

        StartCoroutine(ApplyMovement());
    }

    private void OnDisable()
    {
        move.started -= Move_started;
        move.canceled -= Move_canceled;
        freeze.performed -= Freeze_performed;
        restart.performed -= Restart_performed;
        quit.performed -= Quit_performed;
    }

    /// <summary>
    /// Sets the idle animation when the player is motionless.
    /// </summary>
    private void Move_canceled(InputAction.CallbackContext obj)
    {
        if (IsGrounded())
        {
            animator.SetBool("Move", false);
        }
    }

    /// <summary>
    /// Sets the move animation for the player when in motion.
    /// </summary>
    private void Move_started(InputAction.CallbackContext obj)
    {
        //playerScale = new Vector3(move.ReadValue<float>(), 1, 1);
        //gameObject.transform.localScale = playerScale;
    }

    /// <summary>
    /// Restarts the game.
    /// </summary>
    private void Restart_performed(InputAction.CallbackContext obj)
    {
        SceneManager.LoadScene(0);
    }

    /// <summary>
    /// Closes the program.
    /// </summary>
    private void Quit_performed(InputAction.CallbackContext obj)
    {
        Application.Quit();
    }

    /// <summary>
    /// Freezes time for the player.
    /// </summary>
    private void Freeze_performed(InputAction.CallbackContext obj)
    {
        Freeze();
    }    

    public void Freeze()
    {
        if (Time.timeScale == 0.25 || FindObjectOfType<CoinController>().Score >= 5)
        {
            if (Time.timeScale == 0.25)
            {
                Time.timeScale = 1f;
                playerSpeed /= 2;
                animator.speed = 1;
            }
            else
            {
                Time.timeScale = 0.25f;
                playerSpeed *= 2;
                animator.speed = 4f;
                FindObjectOfType<CoinController>().resetCoins();
            }
        }
    }

    /// <summary>
    /// Changes the angle the player is facing within movement.
    /// </summary>
    void OnMove(InputValue iValue)
    {
        if (this.isNoving == false)
        {
            return;
        }
        inputMovement =move.ReadValue<Vector2>();
        print(inputMovement);
        if (inputMovement.x > 0) //right
        {
            model.localEulerAngles = new Vector3(0, 0, 0);
        }
        if (inputMovement.x < 0) //left
        {
            model.localEulerAngles = new Vector3(0, 180, 0);
        }
        if (inputMovement.y > 0) //up
        {
            model.localEulerAngles = new Vector3(0, -90, 0);
        }
        else if (inputMovement.y < 0) //down 
        {
            model.localEulerAngles = new Vector3(0, -270, 0);
        }
        playerMovement.x = inputMovement.x * playerSpeed;
        playerMovement.z = inputMovement.y * playerSpeed;
        
        animator.SetBool("Move", true);
       
        if (sliding && playerMovement.x != 0)
        {
            rb.velocity = new Vector3(playerMovement.x * playerSpeed, rb.velocity.y,
                    playerMovement.z * playerSpeed);
        }
    }

    /// <summary>
    /// Makes the player jump vertically.
    /// </summary>
    void OnJump()
    {
        if (isNoving == false)
        {
            return;
        }
        if (IsGrounded())
        {
            rb.velocity = new Vector3(0, jumpValue, 0);
            animator.SetBool("Jump", true);
            JumpSound.Play();
        }
    }

    /// <summary>
    /// Makes the player attack.
    /// </summary>
    void OnAttack()
    {
        if (isNoving == false || canAttack == false)
        {
            return;
        }
        StartCoroutine(sickleCooldown());
        animator.SetTrigger("Attack");
        GameObject newsickle = Instantiate(sicklePrefab, transform.position, model.rotation);
        AttackSound.Play();

        if (lastInputMovement.magnitude < 0.001f)
        {
            newsickle.GetComponent<Rigidbody>().velocity = 10 * Vector3.right;

        }
        else
        {
            Vector3 t = new Vector3(lastInputMovement.x, 0, lastInputMovement.y);
            newsickle.GetComponent<Rigidbody>().velocity = 10 * t.normalized;
        }
    }

    IEnumerator sickleCooldown()
    {
        canAttack = false;
        yield return new WaitForSeconds(2);
        canAttack = true;
    }

    // Calls for the PauseMenu script.
    void OnPause()
    {
        pauseMenu.Pause();
    }

    /// <summary>
    /// Sets the player animation when touching the ground
    /// </summary>
    bool IsGrounded()
    {
        if (Physics.BoxCast(transform.position, Vector3.zero, Vector3.down, Quaternion.identity, BoxCastDistance, 
            jumpMask))
        {

            animator.SetBool("Jump", false);
            return true;
        }
        else
        {
            return false;
        }
    }

    /// <summary>
    /// Moves the player.
    /// </summary>
    IEnumerator ApplyMovement()
    {
        while(true)
        {
            //Debug.Log(sliding);
            if (!sliding && isNoving != false)
            {
                Vector2 inputMovement = move.ReadValue<Vector2>();
                playerMovement = (_camera.transform.forward * inputMovement.y) + (_camera.transform.right * inputMovement.x);

                

                playerMovement *= playerSpeed;
                Vector3 newVelocity = new Vector3(playerMovement.x * playerSpeed, rb.velocity.y,
                    playerMovement.z * playerSpeed);
                rb.velocity = newVelocity;

                if (inputMovement.magnitude > 0.001f)
                {
                    lastInputMovement = inputMovement;
                }
            }
            if (rb.velocity == Vector3.zero)
            {
                animator.SetBool("Move", false);
            }
            yield return null;
        }
        
    }

    // Cancels the following actions.
    private void OnDestroy()
    {
        move.started -= Move_started;
        move.canceled -= Move_canceled;
    }

    /// <summary>
    /// Returns the player from the jump animation back to the idle animation after completing a jump
    /// </summary>
    private void OnCollisionEnter(Collision collision)
    {
        if (IsGrounded())
        {
            animator.SetBool("Jump", false);
            if (collision.gameObject.CompareTag("Ice"))
            {
                sliding = true;
            }
        }
    }

    private void OnCollisionExit(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ice"))
        {
            sliding = false;
        }
        
    }
}
