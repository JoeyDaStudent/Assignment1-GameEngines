using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    public float playerSpeed = 10.0f;
    public float playerRotation = 100.0f;
    public float jumpSpeed = 5.0f;

    public Vector3 jump;
    public Vector3 OriginalLocation;

    public Rigidbody rb;

    public bool grounded;

    void OnCollisionStay()
    {
        rb = GetComponent<Rigidbody>();

        grounded = true;    
    }

    private void Start()
    {
        OriginalLocation = transform.position;
    }

    void OnTriggerEnter(Collider collide)
    {
        transform.position = OriginalLocation;
    }

    // Update is called once per frame
    void Update()
    {
        float translation = Input.GetAxis("Vertical") * playerSpeed * Time.deltaTime;
        float rotation = Input.GetAxis("Horizontal") * playerRotation * Time.deltaTime;

        transform.Translate(0, 0, translation);

        transform.Rotate(0, rotation, 0);

        if (Input.GetButton("Jump") && grounded)
        {
            rb.AddForce(jump * jumpSpeed, ForceMode.Impulse);
            grounded = false;
        }
    }
 }
