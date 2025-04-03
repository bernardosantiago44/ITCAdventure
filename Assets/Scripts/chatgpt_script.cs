using UnityEngine;

public class chatgpt_script : MonoBehaviour
{

    private Rigidbody2D _rigidbody;

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        _rigidbody = GetComponent<Rigidbody2D>();

        GetComponent<Rigidbody2D>().AddForce(
            transform.right * 2,
            ForceMode2D.Impulse
        );

        // whenever we create objects on runtime we need clean-up strategies
        Destroy(gameObject, 3);
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnCollisionEnter2D(Collision2D collision)
    {
        Destroy(gameObject);
    }
}
