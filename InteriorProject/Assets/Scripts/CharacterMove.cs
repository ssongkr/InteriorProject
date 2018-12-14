using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterMove : MonoBehaviour {

    public bool isWalking;
    public bool isJumping;

    public float movSpeed = 240.0f;
    public float jumpHeight = 10.0f;
    private float gravity = 28.0f;
    private float height = 0.0f;

    private float cameraValue = 0.0f;
    private float rotLeftRight;
    private float rotUpDown;
    private float verticalRotation = 0f;

    GameObject gameObject1, gameObject2;
    CharacterController controller;
    private Animator anim;

    private AudioSource footstepAudio;
    
    void Start() {
        isWalking = false;
        isJumping = false;

        controller = GetComponent<CharacterController>();
        anim = transform.Find("Ethan").gameObject.GetComponent<Animator>();
        gameObject1 = transform.Find("Ethan").gameObject;
        gameObject2 = transform.Find("ThirdCam").gameObject;
        footstepAudio = GetComponent<AudioSource>();
    }
    
    void Update() {
        // move controller ( mouse_left or key_w )
        Vector3 moveDirection = new Vector3(0.0f, 0.0f, 0.0f);
        if (Input.GetMouseButton(1) || Input.GetKey(KeyCode.W)) {
            isWalking = true;
            setWalkAnim(isWalking);
            setWalkAudio(isWalking, isJumping);
            moveDirection = Camera.main.transform.forward;
            moveDirection *= movSpeed * Time.deltaTime;
        }
        else {
            isWalking = false;
            setWalkAnim(isWalking);
            setWalkAudio(isWalking, isJumping);
        }
        moveDirection.y = height;
        controller.Move(moveDirection * Time.deltaTime);

        // jump controller
        if (controller.isGrounded) {
            setJumpAudio(isJumping);
            isJumping = false;
            if (Input.GetMouseButton(2) || Input.GetKey(KeyCode.Space)) {
                setWalkAudio(false, isJumping);
                isJumping = true;
                height = jumpHeight;
            }
        } else { // jumping
            height -= gravity * Time.deltaTime;
        }


        // mouse controller
        cameraValue = Camera.main.transform.eulerAngles.y;
        gameObject1.transform.rotation = Quaternion.Euler(new Vector3(0.0f, cameraValue, 0.0f));
        //좌우
        rotLeftRight = Input.GetAxis("Mouse X") * 2.0f;
        transform.Rotate(0f, rotLeftRight, 0f);
        //상하
        verticalRotation -= Input.GetAxis("Mouse Y") * 2.0f;
        verticalRotation = Mathf.Clamp(verticalRotation, -90.0f, 90.0f);
        Camera.main.transform.localRotation = Quaternion.Euler(verticalRotation, 0f, 0f);


        //Transform camera = Camera.main.transform;
        //Ray ray;
        //RaycastHit hit;
        //Debug.DrawRay(camera.position, camera.rotation * Vector3.forward * 100f, Color.red);
        //ray = new Ray(camera.position, camera.rotation * Vector3.forward * 100f);
        //if (Physics.Raycast(ray, out hit)) {
        //}

        //if (Input.GetKey(KeyCode.B)) {
        //    gameObject2.transform.position.Set(gameObject2.transform.position.x, gameObject2.transform.position.y, gameObject2.transform.position.z - 5.0f);
        //}
        // cameraValue = 0.0f;
    }

    void setWalkAnim(bool isWalking) {
        if (isWalking) {
            anim.SetFloat("speed", movSpeed);
            anim.SetBool("step", true);
        }
        else {
            anim.SetBool("step", false);
            anim.SetFloat("speed", 0.0f);
            anim.SetFloat("Direction", 0.0f);
        }
    }

    void setWalkAudio(bool isWalking, bool isJumping) {
        if (isWalking && !isJumping) {
            if (!footstepAudio.isPlaying) {
                footstepAudio.Play();
            }
        } else {
            footstepAudio.Stop();
        }
    }

    void setJumpAudio(bool isJumping) {
        if (isJumping) {
            AudioManager.instance.PlaySound();
        }
    }
    
}
