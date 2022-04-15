using DG.Tweening;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class StarController : MonoBehaviour
{
    private CanvasManagement canvasManagement;
    private DiaController diaController;

    private Transform targetPosition;
    private void Start()
    {
        canvasManagement = CanvasManagement.Instance;
        diaController = DiaController.Instance;

        targetPosition = diaController.TargetPosition.transform;

        transform.DOMoveY(2, .5f).SetRelative().SetLoops(-1, LoopType.Yoyo).SetId(gameObject.GetHashCode());
        transform.DORotate(new Vector3(0, 0, 360), 5f, RotateMode.LocalAxisAdd).SetRelative().SetLoops(-1, LoopType.Yoyo).SetId(gameObject.GetHashCode());
    }
    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.CompareTag(Consts.PLYR_TAG))
        {
            DOTween.Kill(gameObject.GetHashCode());

            //Camera.main.WorldToScreenPoint(transform.position)); Pozisyonu ekran pozisyonuna�evir
            Vector3 screenPoint = Camera.main.WorldToScreenPoint(transform.position);

            //Elmas� canvas�n �ocu�u yap
            this.transform.parent = canvasManagement.transform;

            //Elmas�n layer'�n� "UI" yap
            this.gameObject.layer = LayerMask.NameToLayer("UI");

            transform.localScale = new Vector3(25f, 25f, 25f);

            //Ekran Pozisyonunu ortho camerada �evirip elmas�n pozisyonuna ver
            transform.position = diaController.UiCamera.ScreenToWorldPoint(screenPoint);

            Invoke("VisibleFalse", 2.02f);

            transform.DOMove(targetPosition.position, 2f);

            //Destroy(gameObject, 5f);
        }
    }
    private void VisibleFalse()
    {
        canvasManagement.DiamondCounter();
        gameObject.SetActive(false);
    }
}