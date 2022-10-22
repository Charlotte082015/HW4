using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CupCakeControl : MonoBehaviour
{
    CharacterController controller;
    public float speed = 3;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        float v = Input.GetAxis("Vertical");

        Vector3 dir = new Vector3(h, 0, v);

        if (dir.magnitude > 0.1f)
        {
            float faceAngle = Mathf.Atan2(h, v) * Mathf.Rad2Deg;
            Quaternion targetRotation = Quaternion.Euler(0, faceAngle, 0);
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, 0.3f);
        }

        Vector3 move = dir * speed;

        if (!controller.isGrounded)
        {
            move.y = -9.8f * 50 * Time.deltaTime;
        }

        controller.Move(move * speed * Time.deltaTime);
    }

}
