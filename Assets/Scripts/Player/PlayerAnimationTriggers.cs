using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationTriggers : MonoBehaviour
{
    // goi lai ham
    private Player player => GetComponentInParent<Player>();
    private void AnimationTrigger()
    {
        player.AnimationTrigger();
    }
    private void AttackTrigger()
    {
        Collider2D[] colliders = Physics2D.OverlapCircleAll(player.attackCkeck.position, player.attackCkeckRadius);
        foreach(var hit in colliders)
        {
            // neu phat hien co va cham thuc hien tan cong
            if(hit.GetComponent<Enemy>() != null)
            {
                // thuc hien tan cong
                hit.GetComponent<Enemy>().Damage();
            }
        }
    }
}
