using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DeerScared : DeerStrategy
{
    public void Action(Animator _animator){
        _animator.SetBool("scared", true);
        _animator.SetBool("idle_0",false);
        _animator.SetBool("idle_1",false);
        _animator.SetBool("idle_2",false);
        // _animator.SetBool("idle", false);
        _animator.SetBool("running", false);
    }
}
