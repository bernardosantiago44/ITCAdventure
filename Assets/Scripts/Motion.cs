using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class CharacterController2D : MonoBehaviour
{
    [SerializeField] private float moveSpeed = 5f;
    [SerializeField] private float jumpForce = 10f;
    [SerializeField] private Transform groundCheck;
    [SerializeField] private LayerMask groundLayer;

    private Rigidbody2D rb;
    private int maxJumps = 2;
    private int jumps = 0;
    // private float groundCheckRadius = 0.2f; // nse qué es esto

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rb.gravityScale = 1.5f; // Escala de gravedad
    }

    void Update()
    {
        Move();
        Jump();
        LockRotation();
    }

    private void Move()
    {
        float moveInput = Input.GetAxis("Horizontal");
        Vector2 moveVelocity = new Vector2(moveInput * moveSpeed, rb.linearVelocity.y);
        rb.linearVelocity = moveVelocity;

        // Voltea el personaje según la dirección del movimiento
        if ((moveInput > 0 && transform.localScale.x < 0) || (moveInput < 0 && transform.localScale.x > 0))
        {
            Vector3 newScale = transform.localScale;
            newScale.x *= -1;
            transform.localScale = newScale;
        }
    }

    private void Jump()
    {
        if (jumps < maxJumps && Input.GetButtonDown("Jump"))
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            jumps++;

        }
    }

    private void LockRotation()
    {
        transform.rotation = Quaternion.Euler(0, 0, 0);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Piso"))
        {
            jumps = 0;
        }

        if (collision.gameObject.CompareTag("Boss"))
        {
            print("Oh no! Collision with " + collision.transform.name);
        }
    }

    private void OnTriggerEnter2D(Collider2D trigger)
    {
        if (trigger.CompareTag("WinZone"))
        {
            print("You Win!");
            // SceneManager.LoadScene(nextSceneName); // Esto cambia la pantalla 
        }
    }

    // COLISIONS
    // requirement
    // 1. everyone involved has a collider
    // 2. someone has a rigidbody
    // 3. the objetct with the rigidbody is moving

    // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Collision.html

    /*void OnCollisionEnter(Collision c)
    {
        print("Oh no! Collision with  " + c.transform.name + "!");
        SpriteRenderer squareRenderer = GetComponent<SpriteRenderer>();
        if (squareRenderer != null)
        {
            squareRenderer.color = Color.red;
        }
    }

    void OnCollisionStay(Collision c)
    {
        // print("COLLISION STAY!");
    }

    void OnCollisionExit(Collision c)
    {
        // print("COLLISION EXIT!");
    }*/
}
