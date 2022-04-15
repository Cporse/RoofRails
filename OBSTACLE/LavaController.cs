using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LavaController : MonoBehaviour
{
    private float duration;
    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.CompareTag(Consts.PLYR_TAG))
        {
            //Debug.Log("Lava temas edildi.");

            duration += Time.deltaTime;

            if (duration >= .4f)
            {
                other.transform.GetChild(3).localScale = new Vector3(other.transform.GetChild(3).localScale.x, other.transform.GetChild(3).localScale.y - .5f, other.transform.GetChild(3).localScale.z);

                //if (CPlayerController.Instance.cubeS.Count >= 1)
                //{
                //}
                duration = 0f;
            }
            //tr.DOLocalMove(newPos, .75f);
        }
    }

    //END LINE.
}