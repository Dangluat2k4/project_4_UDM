using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerState
{
    protected PlayerStateMachine sStateMachine;
    protected Player player;
    public string animBoolName;
    public PlayerState(Player _player, PlayerStateMachine _sStateMachine, string _animBoolName)
    {
        this.player = _player;
        this.sStateMachine = _sStateMachine;
        this.animBoolName = _animBoolName;
    }
    public virtual void Update()
    {
        Debug.Log("I in :" + animBoolName);
    }
    public virtual void Enter() {
        Debug.Log("I enter :" + animBoolName);
    }
    public virtual void Exit() {
        Debug.Log("I exit :" + animBoolName);
    }  
}
