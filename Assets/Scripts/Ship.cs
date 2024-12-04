using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Ship : MonoBehaviour
{
    [SerializeField, Range(0, 10)] private float movementSpeed;
    [SerializeField] private Transform baseTransform;
    [SerializeField] private GameObject bulletPrefab;
    [SerializeField] private Transform firePoint;
    [SerializeField] private float bulletSpeed = 10f;


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

        if (bulletPrefab && firePoint)
        {
            GameObject bullet = Instantiate(bulletPrefab, firePoint.position, firePoint.rotation);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            if (rb != null)
            {
                rb.velocity = firePoint.up * bulletSpeed;
            }
        }


    }
        private void OnMove(InputValue input)
        {
            moveInput = input.Get<Vector2>();
        }
}
