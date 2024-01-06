using UnityEngine;

public abstract class ISkill
{
    protected PlayerController _playerController;
    protected float _skillCool;

    public ISkill(PlayerController playerController, float skillCool)
    {
        _playerController = playerController;
        _skillCool = skillCool;
    }


    public void Init()
    {
        _skillCool = 0;
    }

    public void Update()
    {
        _skillCool -= Time.deltaTime;
    }

    public abstract void SkillPlay(float cool);
}
