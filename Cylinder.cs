using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cylinder : MonoBehaviour
{
    [SerializeField] private GameObject friction;

    private ContactPoint contact;
    private Vector3 pos;

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Consts.PLYR_TAG))
        {
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.None;
            collision.gameObject.GetComponent<Rigidbody>().constraints = RigidbodyConstraints.FreezeRotationX | RigidbodyConstraints.FreezeRotationY;
            transform.GetComponent<Collider>().enabled = false;
            if (transform.position.x <= collision.transform.position.x)
            {
                //collision.transform.Rotate(0, 0, -30);
                collision.transform.DORotate(new Vector3(0, 0, +30), 1f, RotateMode.LocalAxisAdd);
            }
            else
            {
                //collision.transform.Rotate(0, 0, +30);
                collision.transform.DORotate(new Vector3(0, 0, -30), 1f, RotateMode.LocalAxisAdd);
            }
        }
        if (collision.gameObject.CompareTag(Consts.PIPE_TAG))
        {
            contact = collision.contacts[0];
            pos = contact.point;
            Instantiate(friction, new Vector3(pos.x, pos.y, pos.z - .25f), Quaternion.identity).transform.parent = collision.gameObject.transform;

        }
    }
}