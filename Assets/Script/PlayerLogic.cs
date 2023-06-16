using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerLogic : MonoBehaviour
{
    [SerializeField] private GameObject _playerBody;

    private int _speed = 3;

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

}
