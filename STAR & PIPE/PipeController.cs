using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PipeController : MonoBehaviour
{
    //[SerializeField] private Transform pipeBox;

    private CanvasManagement canvasManagement;

    private void Start()
    {
        canvasManagement = CanvasManagement.Instance;
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Consts.PLYR_TAG))
        {
            canvasManagement.ScoreCounter();
            Destroy(gameObject);
        }
    }
}