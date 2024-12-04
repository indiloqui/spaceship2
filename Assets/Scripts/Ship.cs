using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float movementSpeed;
    [SerializeField] private Transform baseTransform;

    private Vector2 moveInput;

    void Update()
    {
        
        transform.Translate(moveInput * movementSpeed * Time.deltaTime, Space.World);

        
        if (moveInput != Vector2.zero)
        {
            baseTransform.up = moveInput.normalized;
        }
    }

    private void OnShoot()
    {
        print("BOOM!");
    }

    private void OnMove(InputValue input)
    {
        moveInput = input.Get<Vector2>();
    }
}
