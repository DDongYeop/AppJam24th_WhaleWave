public class YouthSkill : ISkill
{
    public YouthSkill(PlayerController playerController, float skillCool) : base(playerController, skillCool) { }
    
    public override void SkillPlay(float cool)
    {
        if (_skillCool > 0)
            return;
        _skillCool = cool;
        foreach (var fish in SkillManager.Instance.ReturnFish())
            PoolManager.Instance.Push(fish);
    }
}
