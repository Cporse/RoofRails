using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum AnimationState
{
    Idle,
    Running
}

public class AnimationManagement : MonoBehaviour
{
    public static AnimationManagement Instance = null;

    [SerializeField] private Animator animator;

    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
        }
    }
    public void PlayAnimation(Animator animator, AnimationState animationState)
    {
        int animState = (int)animationState; 
        animator.SetInteger("Player", animState);
    }

    public void StartPlayer()
    {
        PlayAnimation(animator, AnimationState.Running);
    }
    public void StopPlayer()
    {
        animator.SetInteger("Player", 3);
        animator.SetBool("isFinish", true);
        
        //PlayAnimation(animator, AnimationState.Idle);
    }
}