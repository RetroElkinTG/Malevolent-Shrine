using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed;
    private Rigidbody2D myRigidbody;
    private Vector3 myPosition;

    // Start is called before the first frame update
    void Start()
    {
        myRigidbody = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        myPosition = Vector3.zero;
        myPosition.x = Input.GetAxisRaw("Horizontal");
        myPosition.y = Input.GetAxisRaw("Vertical");
        if (myPosition != Vector3.zero)
        {
            MoveCharacter();
        }
    }

    // Move the character
    void MoveCharacter()
    {
        myRigidbody.MovePosition(
            transform.position + myPosition * speed * Time.deltaTime);
    }
}
