using System.Collections;
using UnityEngine;

public class LastSkill : ISkill
{
    private float _skillTime;
    
    public LastSkill(PlayerController playerController, float skillCool, float skillTime) : base(playerController, skillCool)
    {
        _skillTime = skillTime;
    }

    public override void SkillPlay(float cool)
    {
        if (_skillCool > 0)
            return;

        _skillCool = cool;
        SkillManager.Instance.StartCoroutine(LastSkillCo());
    }

    private IEnumerator LastSkillCo()
    {
        foreach (var fish in SkillManager.Instance.ReturnFish())
            fish.CurrentMoveSpeed *= 0f;
        SkillManager.Instance.IsStop = true;
        
        yield return new WaitForSeconds(_skillTime);

        foreach (var fish in SkillManager.Instance.ReturnFish())
            fish.CurrentMoveSpeed = fish.MoveSpeed;
        SkillManager.Instance.IsStop = false;
    }
}
