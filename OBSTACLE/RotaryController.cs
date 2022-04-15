using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using DG.Tweening;

public class RotaryController : MonoBehaviour
{
    [SerializeField] private GameObject bloodEffect;
    private void Start()
    {
        transform.DOMoveZ(10, 2f).SetRelative().SetLoops(-1, LoopType.Yoyo);
        //transform.DORotate(new Vector3(0, 0, 360), 1f).SetRelative().SetLoops(-1, LoopType.Yoyo);
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Consts.PLYR_TAG))
        {
            Instantiate(bloodEffect, new Vector3(other.transform.position.x, other.transform.position.y + 1.5f, other.transform.position.z + 2f), Quaternion.identity);
            //Pipe DeCREASE
        }
    }


    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Consts.PIPE_TAG))
        {
            //ContactPoint contact = collision.contacts[0];
            //Quaternion rot = Quaternion.FromToRotation(Vector3.up, contact.normal);
            //Vector3 pos = contact.point;

            //collision.transform.position = new Vector3(-(10 / 2 - pos.x), collision.transform.position.y, collision.transform.position.z);
            //Debug.Log(pos.x);
            //collision.transform.localScale = new Vector3(collision.transform.localScale.x, collision.transform.localScale.y - ((10 / 2 - pos.x) / 2), collision.transform.localScale.z);

            //StartCoroutine(Center(collision.gameObject));
        }
    }

    //END LINE.

    IEnumerator Center(GameObject collision)
    {
        yield return new WaitForSeconds(3f);

        collision.transform.localPosition = new Vector3(0, collision.transform.localPosition.y, collision.transform.localPosition.z);
    }
}