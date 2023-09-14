using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(CharacterController))]

public class FPSController : MonoBehaviour
{
    // Links game manager so that scripts attached to it can be used
    public GameObject GameManager;
    public GameObject checkZone;

    // Attatchs a camera to the player so when the player looks, the camera moves
    public Camera playerCamera;

    // Sets the walk speed of the player
    public float walkSpeed = 6f;
    // Sets the run speed of the player
    public float runSpeed = 12f;

    // Sets the speed the the camera moves at when the player is looking
    public float lookSpeed = 15f;
    // Sets the max angle that the camera will turn
    public float lookXLimit = 45f;

    // A three space vector to deal with the players position
    Vector3 moveDirection = Vector3.zero;
    float rotationX = 0;

    // A bool to check whether the player is allowed to move or not
    public bool canMove = true;

    // A character controller to allow for easy movement with out worrying about a rigidbody
    CharacterController characterController;

    // Start is called before the first frame update
    void Start()
    {
        // Set the character controller as the character controller component that was fetched
        characterController = GetComponent<CharacterController>();
        // Lock the cursor so that it doesn't go all over the screen
        Cursor.lockState = CursorLockMode.Locked;
        // Hide the cursor so it can't be seen
        Cursor.visible = false;
    }

    // Update is called once per frame
    void Update()
    {
        // If the player can move about
        if (canMove)
        {
            // Adds the vertical mouse movement to the rotation float
            rotationX += -Input.GetAxis("Mouse Y") * lookSpeed;
            // Sets the max and min values the rotation float can be
            rotationX = Mathf.Clamp(rotationX, -lookXLimit, lookXLimit);
            // Transforms the camera position  by the rotation angle from the mouse
            playerCamera.transform.localRotation = Quaternion.Euler(rotationX, 0, 0);
            // Allows the camera to go any angle in the horizontal direction
            transform.rotation *= Quaternion.Euler(0, Input.GetAxis("Mouse X") * lookSpeed, 0);
        }

        // If the pop up, pause menu, submit screen or the game is finished then show the cursor and allow it to move
        if (GameManager.GetComponent<PopUp>().popupActive || GameManager.GetComponent<MainMenu>().pauseMenuActive || checkZone.GetComponent<FinsihGame>().submitActive || GameManager.GetComponent<CheckResult>().gameFinished)
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            // If not then lock the cursor and hide where it is 
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;
        }

        // If the pause menu is active or the game is finished then disable player movement
        if (GameManager.GetComponent<MainMenu>().pauseMenuActive || GameManager.GetComponent<CheckResult>().gameFinished)
        {
            canMove = false;
        }
        else
        {
            // If not then let the player move as normal
            canMove = true;
        }
    }

    // Runs a fixed number of times per second
    private void FixedUpdate()
    {
        // Vector to deal with movement. Only forwards and right because negative foward it backwards and negative right is left
        Vector3 forward = transform.TransformDirection(Vector3.forward);
        Vector3 right = transform.TransformDirection(Vector3.right);

        // Checks if the player is running by checking if shift key is pressed
        bool isRunning = Input.GetKey(KeyCode.LeftShift);

        // Calculates the actual move distances
        float curSpeedX = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Vertical") : 0;
        float curSpeedY = canMove ? (isRunning ? runSpeed : walkSpeed) * Input.GetAxis("Horizontal") : 0;

        // Combines the move distances with the move directions
        moveDirection = (forward * curSpeedX) + (right * curSpeedY);

        // Apply the calculated movement to the player
        characterController.Move(moveDirection * Time.deltaTime);
    }
}
