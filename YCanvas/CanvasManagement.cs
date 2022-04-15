using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class CanvasManagement : MonoBehaviour
{
    public static CanvasManagement Instance;
    private PlayerMovement playerMovement;

    [SerializeField] private Button nextLevel;
    [SerializeField] private Text textScore;
    [SerializeField] private Text textDiamond;
    [SerializeField] private Text textTapToPlay;

    private int scoreNumber = 0;
    private int diamondNumber;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    private void Start()
    {
        playerMovement = PlayerMovement.Instance;
    }
    public void ActiviteNextButton()
    {
        nextLevel.gameObject.SetActive(true);
    }
    public void DiamondCounter()
    {
        textDiamond.text = (++diamondNumber).ToString();
    }
    public void LoadScene()
    {
        SceneManager.LoadScene(0);
        AnimationManagement.Instance.StartPlayer();
    }
    public void ScoreCounter()
    {
        textScore.text = (++scoreNumber).ToString();
    }
    public void TapToPlay()
    {
        Debug.Log(Consts.GAME_STRT);
        textTapToPlay.gameObject.SetActive(false);
        playerMovement.KinematicMakeTrue(false);

        AnimationManagement.Instance.StartPlayer();
    }
}