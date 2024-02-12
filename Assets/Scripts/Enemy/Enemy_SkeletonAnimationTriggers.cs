using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimaionTriggers : MonoBehaviour
{
    private Enemy_Skeleton enemy=> GetComponentInParent<Enemy_Skeleton>();
    private void AnimationTrigger()
    {
        enemy.AnimationFinishTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] collider = Physics2D.OverlapCircleAll(enemy.attackCkeck.position, enemy.attackCkeckRadius);
        foreach(var hit in collider)
        {
            // neu enemy phat hien va cham voi player thi thuc hien tan cong
            if(hit.GetComponent<Player>() != null)
            {
                hit.GetComponent<Player>().Damage();
            }
        }
    }
}
