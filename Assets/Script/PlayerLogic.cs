using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

public class PlayerLogic : MonoBehaviour
{ 
    [SerializeField] private GameObject _playerBackpack;
    [SerializeField] private Rigidbody _rb;
    [SerializeField] private Transform _groundCheckCollider;
    [SerializeField] private LayerMask _groundLayer;

    [SerializeField] private bool _isGrounded;
    private float _jumpForse = 250f;

    public bool _sceneTrigger;

    private int _speed = 2;

    private void FixedUpdate()
    {
        if (_sceneTrigger == false)
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

    }

    private void Update()
    {
        GroundCheck();

        if (_sceneTrigger == false)
        {
            if (Input.GetButtonDown("Jump") && _isGrounded)
            {
                Jump();
            }
        }
    }

    private void MoveVertical()
    {
        Vector3 dir = transform.right * Input.GetAxis("Vertical");
        transform.position = Vector3.MoveTowards(transform.position, transform.position + dir, _speed * Time.deltaTime);

        /*if (dir.x < 0.0f)
        {
            _playerBackpack.transform.rotation = new Quaternion(0f, 0f, 0f, 0f);
        }
        else
        {
            _playerBackpack.transform.rotation = new Quaternion(0f, 180f, 0f, 0f);
        }*/
    }

    private void MoveHorizontal()
    {
        Vector3 dir = transform.forward * Input.GetAxis("Horizontal");
        transform.position = Vector3.MoveTowards(transform.position, transform.position - dir, _speed * Time.deltaTime);

        /*if (dir.z < 0.0f)
        {
            _playerBackpack.transform.rotation = new Quaternion(0f, 90f, 0f, 0f);
        }
        else
        {
            _playerBackpack.transform.rotation = new Quaternion(0f, -90f, 0f, 0f);
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
