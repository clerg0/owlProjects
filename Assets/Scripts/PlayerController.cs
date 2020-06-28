using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField]
    private float speedFactor = 1f;

    private float xSpeed = 0f;
    private float ySpeed = 0f;

    private Vector2 translationVector;

    private Rigidbody2D playerRigidBody;

    // Start is called before the first frame update
    void Start()
    {
        translationVector = new Vector2(xSpeed, ySpeed);

        playerRigidBody = GetComponent<Rigidbody2D>();
        if (playerRigidBody != null)
        {
            Debug.LogError("No RigidBody2D assigned to the player controller on the player game object");
        }
    }

    // Update is called once per frame
    void Update()
    {
        xSpeed = Input.GetAxis("Horizontal");
        ySpeed = Input.GetAxis("Vertical");
        //Debug.Log("XSPEED = " + xSpeed + " // YSPEED = " + ySpeed);

        //player movement
        translationVector.Set(xSpeed, 0);
        translationVector.Normalize();
        translationVector *= speedFactor;
        // the move position is done in the Fixed Update

        //camera movement
        Camera.main.transform.Translate(new Vector3((transform.position.x - Camera.main.transform.position.x) * 0.10f, (transform.position.y - Camera.main.transform.position.y) * 0.10f, 0f));
    }

    void FixedUpdate()
    {
        if (translationVector.magnitude > 0.1)
        {
            playerRigidBody.MovePosition(new Vector2(transform.position.x, transform.position.y) + translationVector);
        }
    }
}
