using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("The speed of the player")]
    [SerializeField]
    private int playerSpeed = 4;

    private Rigidbody2D myRigidbody;

    private Vector3 movementChange;

    private Animator animator; 

    // start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();

        // set the default animation to face down
            animator.SetFloat("moveX", 0);
            animator.SetFloat("moveY", 1);
        
    }

    // update is called once per frame
    void Update()
    {
        
        HandleMovementAndAnimation();


    }

    private void HandleMovementAndAnimation()
    {
        // this way the character doesn't continuously move
        movementChange = Vector3.zero;

        // i can change what horizontal and vertical means in Unity
        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");

        // normalized makes it so you can't go faster no matter what direction
        myRigidbody.MovePosition(transform.position + movementChange.normalized * playerSpeed * Time.fixedDeltaTime);

    //if there is movement change the vector is no longer zero
        if(movementChange != Vector3.zero)
        {
            animator.SetFloat("moveX", movementChange.x);
            animator.SetFloat("moveY", movementChange.y);

            //tells the animator that the player is moving
            animator.SetBool("isMoving", true);
        }
        else
        {
            //makes it so the engine knows the player is not moving
            animator.SetBool("isMoving", false);
        }
    }
}
