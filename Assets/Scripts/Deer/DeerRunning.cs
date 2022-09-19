using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerRunning : DeerStrategy
{
    public void Action(Animator _animator){
        SetAnimation(_animator);
    }
    private void SetAnimation(Animator _animator){
        _animator.SetBool("running", true);
        _animator.SetBool("idle_0",false);
        _animator.SetBool("idle_1",false);
        _animator.SetBool("idle_2",false);
        // _animator.SetBool("idle", false);
        _animator.SetBool("scared", false);
    }
}
