using System.Collections.Generic;
using UnityEngine;

public class PlayerSkill : MonoBehaviour
{
    private PlayerController _playerController;
    private List<ISkill> _skills = new List<ISkill>();
    [SerializeField] private List<float> _skillCools = new List<float>(); // 리틀 -> 노말 -> 빅. 역순

    [SerializeField] private float _middleSkillTime;
    [SerializeField] private float _lastSkillTime;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
        
        _skills.Add(new LastSkill(_playerController, _skillCools[0], _lastSkillTime));
        _skills.Add(new MiddleSkill(_playerController, _skillCools[1], _middleSkillTime));
        _skills.Add(new YouthSkill(_playerController, _skillCools[2]));
        foreach (var skill in _skills)
            skill.Init();
    }

    private void Update()
    {
        _skills[(int)_playerController.ScaleType - 3].Update();
    }

    private void OnEnable()
    {
        _playerController.InputReader.SkillEvent += SkillPlay;
    }

    private void OnDisable()
    {
        _playerController.InputReader.SkillEvent -= SkillPlay;
    }

    private void SkillPlay()
    {
        int index = (int)_playerController.ScaleType - 3;
        _skills[index].SkillPlay(_skillCools[index]);
    }
}
