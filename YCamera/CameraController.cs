using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public static CameraController Instance;

    [SerializeField] private Transform target;
    private float y = 12;
    private float z = 12;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    void FixedUpdate()
    {
        transform.position = new Vector3(target.position.x, target.position.y + y, target.position.z - z);
    }
    public void SetTarget(Transform target, bool up)
    {
        this.target = target;
        if (up)
        {
            y += 1f;
            z += 1f;
        }
        else
        {
            y -= 1f;
            z -= 1f;
        }
    }
}