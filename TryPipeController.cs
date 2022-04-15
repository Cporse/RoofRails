using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TryPipeController : MonoBehaviour
{
    public static TryPipeController Instance;

    [SerializeField] private GameObject pipe;

    private Rigidbody body;
    private float distance;
    private float cutPipe;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
        body = GetComponent<Rigidbody>();
    }
    private void FixedUpdate()
    {
        if (body.IsSleeping())
        {
            //body.WakeUp();
            Debug.Log("girdi");
        }
    }
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Consts.SAW_TAG))
        {
            Debug.Log("Býçký kesmeli");

            ContactPoint contact = collision.contacts[0];
            Vector3 pos = contact.point;

            //Debug.Log(pos.x - .35f);
            distance = Mathf.Abs((pos.x - .35f) - transform.position.x);

            print(distance);    //Pipe center ile olan uzaklýðý
            distance /= 2;

            cutPipe = transform.localScale.y / 2 - distance;
            print(cutPipe);
            GameObject tempPipe;
            bool isRight = (transform.position.x < pos.x) ? true : false;
            if (isRight)
            {
                transform.position = new Vector3(transform.position.x - cutPipe, transform.position.y, transform.position.z);
                tempPipe = Instantiate(pipe, new Vector3(pos.x + cutPipe, transform.position.y, transform.position.z), Quaternion.identity);
            }
            else
            {
                //cutPipe kadar pivotu SAÐA KAYDIR.
                transform.position = new Vector3(transform.position.x + cutPipe, transform.position.y, transform.position.z);
                tempPipe = Instantiate(pipe, new Vector3(pos.x, transform.position.y, transform.position.z), Quaternion.identity);
            }
            tempPipe.transform.Rotate(0, 0, 90);
            tempPipe.transform.localScale = new Vector3(transform.localScale.x, cutPipe, transform.localScale.z);
            tempPipe.AddComponent<Rigidbody>();
            Destroy(tempPipe, .5f);

            //cutPipe kadar localScale DÜÞÜR.
            transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y - cutPipe, transform.localScale.z);

            collision.gameObject.GetComponent<Collider>().enabled = false;
            StartCoroutine(Center(transform));
        }
    }

    IEnumerator Center(Transform tr)
    {
        yield return new WaitForSeconds(.25f);

        Vector3 newPos = new Vector3(0, tr.localPosition.y, tr.localPosition.z);

        tr.DOLocalMove(newPos, .75f);
    }
    public void MyPipeAdd()
    {
        transform.localScale = new Vector3(transform.localScale.x, transform.localScale.y + 0.7f, transform.localScale.z);
    }
}