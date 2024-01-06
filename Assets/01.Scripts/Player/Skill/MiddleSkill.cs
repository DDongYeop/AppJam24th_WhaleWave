using System.Collections;
using UnityEngine;

public class MiddleSkill : ISkill
{
    private float _middleCoolTime;

    public MiddleSkill(PlayerController playerController, float skillCool, float coolTime) : base(playerController, skillCool)
    {
        _middleCoolTime = coolTime;
    }

    public override void SkillPlay(float cool)
    {
        if (_skillCool > 0)
            return;
        
        _skillCool = cool;
        SkillManager.Instance.StartCoroutine(MiddleSkillCo());
    }

    private IEnumerator MiddleSkillCo()
    {
        foreach (var fish in SkillManager.Instance.ReturnFish())
            fish.CurrentMoveSpeed *= 1.5f;
        SkillManager.Instance.IsFast = true;
        
        yield return new WaitForSeconds(_middleCoolTime);
        
        SkillManager.Instance.IsFast = false;
        foreach (var fish in SkillManager.Instance.ReturnFish())
            fish.CurrentMoveSpeed = fish.MoveSpeed;
    }
}
