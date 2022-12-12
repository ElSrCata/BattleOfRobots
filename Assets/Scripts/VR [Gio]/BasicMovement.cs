using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//-----------------------------------------------------------------------
// Basic movement when we want the player to move using a gamepad
// Author (Discord): Gio#0753
//-----------------------------------------------------------------------

public class BasicMovement : MonoBehaviour {

    
    new Rigidbody rigidbody;
    new Camera camera;
    public bool wasd;
    Vector3 movementInput;
    public float speedH;
    public float speedV;


    float yaw;
    float pitch;



    int jumps = 0;
    [SerializeField] float speed = 3, jumpForce = 500;

    void Start() {
        camera = GetComponentInChildren<Camera>();
        rigidbody = GetComponent<Rigidbody>();
    }

    CharacterController cc;
    void Awake() {
        
        cc = GetComponent<CharacterController>();
    }

    
    void Update() {
 
            if (wasd) {
                KeyMove();
            } else {
                camMove();
            }
    }

    public void camMove() {
       
        //Vector3 velocity = camera.transform.forward * Input.GetAxis("Vertical") * speed;
            float f =Input.acceleration.z;
            //agafa valors positius i negatius per si el mòbil esta girat al revès
            if (f>0.3f || f<-0.3f)
            {
                Vector3 velocity = camera.transform.forward * 1 * speed;
                transform.position += velocity * Time.deltaTime;
            }

            if (Input.GetButtonDown("Jump")) {
             Jump();
            }
    }


    public void Jump() {
        if(jumps >= 1) {
            rigidbody.AddForce(Vector3.up * jumpForce);
            jumps--;
        }
    }

    private void KeyMove() {
        
        yaw += speedH * Input.GetAxis("Mouse X");
        pitch += speedV * Input.GetAxis("Mouse Y");

        transform.eulerAngles = new Vector3(pitch, yaw, 0.0f);

        movementInput = Vector3.zero;

        if(Input.GetKey(KeyCode.W)) {
            
            movementInput.z = -1;
        
        } else if (Input.GetKey(KeyCode.S)) {

            movementInput.z = 1;

        } else if (Input.GetKey(KeyCode.D)) {

            movementInput.x = -1;

        } else if (Input.GetKey(KeyCode.A)) {

            movementInput.x = 1; 
        }

        Move(movementInput);
    }

    
    void Move(Vector3 direction) {

        cc.SimpleMove(direction.normalized * speed);    
    }
        

    

    void OnCollisionEnter(Collision collision) {
        jumps = 1;
    }
}
