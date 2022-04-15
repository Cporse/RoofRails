using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public static PlayerMovement Instance;

    public int speed;

    [SerializeField] private Camera OrthoG;
    [SerializeField] private float sensivity;
    //[SerializeField] private Animator playerAnimator;

    private Rigidbody rigidBody;
    private Vector3 mousePosition;
    private Vector3 firstPosition;
    private Vector3 difference;
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }

        rigidBody = gameObject.GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        rigidBody.velocity = Vector3.Lerp(rigidBody.velocity, new Vector3(difference.x, rigidBody.velocity.y, speed), 11.2f);
    }

    void Update()
    {
        firstPosition = Vector3.Lerp(firstPosition, mousePosition, .1f);

        if (Input.GetMouseButtonDown(0))
            MouseDown(Input.mousePosition);

        else if (Input.GetMouseButtonUp(0))
            MouseUp();

        else if (Input.GetMouseButton(0))
            MouseHold(Input.mousePosition);

        transform.position = new Vector3(Mathf.Clamp(transform.position.x, -4.5f, 4.5f), transform.position.y, transform.position.z);
    }

    //END LINE.
    //Functions Start,
    public void KinematicMakeTrue(bool isKinematic)
    {
        rigidBody.isKinematic = isKinematic;
    }
    private void MouseDown(Vector3 inputPos)
    {
        mousePosition = OrthoG.ScreenToWorldPoint(inputPos);
        firstPosition = mousePosition;
    }
    private void MouseHold(Vector3 inputPos)
    {
        mousePosition = OrthoG.ScreenToWorldPoint(inputPos);
        difference = mousePosition - firstPosition;
        difference *= sensivity;
    }
    private void MouseUp()
    {
        difference = Vector3.zero;
    }
}