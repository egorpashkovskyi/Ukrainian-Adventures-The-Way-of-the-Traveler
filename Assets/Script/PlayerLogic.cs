using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private GameObject _playerBody;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _groundCheckCollider;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private bool _isGrounded;
    private float _jumpForse = 250f;

    private int _speed = 2;

    private void FixedUpdate()
    {
        if (!(Input.GetButton("Vertical") && Input.GetButton("Horizontal")))
        {
            if (Input.GetButton("Vertical"))
            {
                MoveVertical();
            }

            if (Input.GetButton("Horizontal"))
            {
                MoveHorizontal();
            }
        }

    }

    private void Update()
    {
        GroundCheck();
        
        if (Input.GetButtonDown("Jump") && _isGrounded)
        {
            Jump();
        }
    }

    private void MoveVertical()
    {
        Vector3 dir = transform.right * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

        /*if (dir.x < 0.0f)
        {
            _playerBody.transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        }
        else
        {
            _playerBody.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }*/
    }

    private void MoveHorizontal()
    {
        Vector3 dir = transform.forward * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, _speed * Time.deltaTime);

        /*if (dir.x < 0.0f)
        {
            _playerBody.transform.localScale = new Vector3(-0.25f, 0.25f, 0.25f);
        }
        else
        {
            _playerBody.transform.localScale = new Vector3(0.25f, 0.25f, 0.25f);
        }*/
    }

    private void Jump()
    {
        _rb.AddForce(Vector2.up * _jumpForse);
    }
    
    private void GroundCheck()
    {
        _isGrounded = false;
        Collider[] colliders = Physics.OverlapSphere(_groundCheckCollider.position, 0.1f, _groundLayer);
        if (colliders.Length > 0)
        {
            _isGrounded = true;
        }
    }
}
