using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Consts.PIPE_TAG))
        {
            //UZAMA ve Kamera target fonksiyonu burada.
            CameraController.Instance.SetTarget(transform, true);
            //transform.GetChild(1).localScale = new Vector3(transform.GetChild(1).localScale.x, transform.GetChild(1).localScale.y + .7f, transform.GetChild(1).localScale.z);

            TryPipeController.Instance.MyPipeAdd();
        }
    }

    //END LINE.
}