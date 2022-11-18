using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float rotationSpeed = 3f;
    
    [SerializeField] private CharacterController characterController;
    [SerializeField] private float moveSpeed = 5f;

    private Animator animator;
    private Transform transform;
    private static readonly int Speed = Animator.StringToHash("Speed");
    
    private void Awake()
    {
        animator = GetComponentInChildren<Animator>();
        characterController = GetComponent<CharacterController>();
        transform = GetComponent<Transform>();
    }

    void Update()
    {
        var horizontal = Input.GetAxis("Horizontal");
        var vertical = Input.GetAxis("Vertical");

        animator.SetFloat(Speed, vertical);
        
        transform.Rotate(Vector3.up, horizontal * Time.deltaTime * rotationSpeed);
        characterController.SimpleMove(transform.forward * (vertical * Time.deltaTime * moveSpeed));
    }
}
