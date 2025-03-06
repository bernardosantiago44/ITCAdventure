using UnityEngine;

public class Motion : MonoBehaviour
{

    // Editor available variables
    [SerializeField] private float _speed = 5.0f;
    [SerializeField] private bool _dynamicMotion = false;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        // print("AWAKE!");
    }

    // Update is called once per frame
    void Update()
    {
        // Polling for input
        // poll directly to a device
        // true if key was up last frame but down this frame
        // if (Input.GetKeyDown(KeyCode.O)) {
        //     print("Key Down O");
        // }

        // if (Input.GetKey(KeyCode.O)) {
        //     print("Key O");
        // }

        // if (Input.GetKeyUp(KeyCode.O)) {
        //     print("Key Up O");
        // }

        // // Also poll the mouse
        // if (Input.GetMouseButtonDown(0)) {
        //     print("Mouse Down 0");
        // }

        // Axes are a way to abstract input from different devices
        // GetAxis returns a float between -1 and 1
        float horizontal = Input.GetAxis("Horizontal");
        float vertical = Input.GetAxis("Vertical");

        if (Input.GetButtonDown("Jump"))
            print("Jump!");

        // The closer the object is from the center,
        // the slower it moves
        float speed = this._speed;
        if (this._dynamicMotion) {
            float distance = Vector3.Distance(Vector3.zero, transform.position);
            speed = this._speed * Mathf.Max(distance / 10, 0.01f); // Limit the speed to 1% of the original speed
        }

        transform.Translate(
            horizontal * Time.deltaTime * speed,
            vertical * Time.deltaTime * speed,
            0,
            Space.World // Default - Space.Self
        );

    }

    // COLISIONS
    // requirement
    // 1. everyone involved has a collider
    // 2. someone has a rigidbody
    // 3. the objetct with the rigidbody is moving

    // https://docs.unity3d.com/6000.0/Documentation/ScriptReference/Collision.html

    void OnCollisionEnter(Collision c)
    {   
        print("Oh no! Collision with  " + c.transform.name + "!");
        SpriteRenderer squareRenderer = GetComponent<SpriteRenderer>();
        if (squareRenderer != null )
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
    }
}
