using UnityEngine;

public class Player : MonoBehaviour
{
    [Tooltip("The speed of the player")]
    [SerializeField]
    private int playerSpeed = 4;
    private Rigidbody2D myRigidbody;
    private Vector3 movementChange;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {

        myRigidbody = GetComponent<Rigidbody2D>();
        
    }

    // Update is called once per frame
    void Update()
    {
        
        HandleMovementAndAnimation();


    }

    private void HandleMovementAndAnimation()
    {
        // This way the character doesn't continuously move
        movementChange = Vector3.zero;

        // I can change what horizontal and vertical means in Unity
        movementChange.x = Input.GetAxisRaw("Horizontal");
        movementChange.y = Input.GetAxisRaw("Vertical");

        // Normalized makes it so you can't go faster no matter what direction
        myRigidbody.MovePosition(transform.position + movementChange.normalized * playerSpeed * Time.fixedDeltaTime);
    }
}
