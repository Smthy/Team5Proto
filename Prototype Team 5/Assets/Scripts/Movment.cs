using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movment : MonoBehaviour
{
    public CharacterController controller;
    public float speed = 8f;
    public float turnSmooth = 0.1f;
    private float turnSmoothVel;
    public Transform cam;

    void Update()
    {
        float hozizontal = Input.GetAxisRaw("Horizontal");
        float verticle = Input.GetAxisRaw("Vertical");
        Vector3 direction = new Vector3(hozizontal, 0, verticle).normalized;

        if (direction.magnitude >= 0.1f)
        {
            float targetAng = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg + cam.eulerAngles.y;
            float ang = Mathf.SmoothDampAngle(transform.eulerAngles.y, targetAng, ref turnSmoothVel, turnSmooth);
            transform.rotation = Quaternion.Euler(0, ang, 0);
            Vector3 moveDir = Quaternion.Euler(0f, targetAng, 0f) * Vector3.forward;
            controller.Move(moveDir.normalized * speed * Time.deltaTime);
        }
    }
}
