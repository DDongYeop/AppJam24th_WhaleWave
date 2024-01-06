using UnityEngine;
using UnityEngine.Serialization;

public class Fish : PoolableMono
{ 
    public PlayerScaleType DieScaleType;  //어떤 친구까지 괜찮은지 
    public int Score;
    public int Damage;
    
    public float MoveSpeed;
    [HideInInspector] public float CurrentMoveSpeed;

    public override void Init()
    {
        if (SkillManager.Instance.IsFast)
            CurrentMoveSpeed = MoveSpeed * 1.5f;
        else
            CurrentMoveSpeed = MoveSpeed;
    }
    
    private void Update()
    {
        transform.Translate(Vector3.back * (CurrentMoveSpeed * Time.deltaTime));
        
        if (transform.position.z < -25)
            PoolManager.Instance.Push(this);
    }

}
