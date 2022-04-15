using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinishController : MonoBehaviour
{
    CanvasManagement canvasManagement;
    LevelManagement levelManagement;
    PlayerMovement playerMovement;

    [SerializeField] private int stepValue;
    private void Start()
    {
        canvasManagement = CanvasManagement.Instance;
        levelManagement = LevelManagement.Instance;
        playerMovement = PlayerMovement.Instance;
    }
    //private void OnTriggerEnter(Collider other)
    //{
    //    if (other.gameObject.CompareTag(Consts.PLYR_TAG))
    //    {
    //        Debug.Log(Consts.GAME_WIN);

    //        playerMovement.KinematicMakeTrue(true);

    //        //Debug.Log(levelManagement.LevelIndex.ToString());
    //        levelManagement.LevelIndex++;
    //        //Debug.Log(levelManagement.LevelIndex.ToString());
    //        canvasManagement.ActiviteNextButton();
    //    }
    //}
    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag(Consts.PLYR_TAG))
        {
            //Debug.Log(Consts.GAME_WIN);
            //Debug.Log(stepValue.ToString());

            playerMovement.KinematicMakeTrue(true);

            //Debug.Log(levelManagement.LevelIndex.ToString());
            levelManagement.LevelIndex++;
            //Debug.Log(levelManagement.LevelIndex.ToString());

            canvasManagement.ActiviteNextButton();

            AnimationManagement.Instance.StopPlayer();
        }
    }

    //END LINE.
}