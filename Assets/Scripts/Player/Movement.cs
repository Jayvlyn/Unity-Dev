using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.Windows;

public class Movement : MonoBehaviour
{
    [SerializeField] private Camera playerCamera;
    CharacterController controller;
    public InputAction inputAction;
    private Vector2 movement;

    float speed = 5f;

    // Start is called before the first frame update
    void Start()
    {
        controller = GetComponent<CharacterController>();
        inputAction.Enable();

    }

    // Update is called once per frame
    void Update()
    { 
    }

    private void FixedUpdate()
    {
        Vector3 direction = movement.x * playerCamera.transform.right + movement.y * playerCamera.transform.forward;
        direction = new Vector3(direction.x, 0 , direction.z);
        controller.Move(direction * Time.deltaTime * speed);
    }

    public void OnMove(InputValue value)
    {
        movement = value.Get<Vector2>();
    }

}
