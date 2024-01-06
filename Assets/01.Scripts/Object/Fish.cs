using UnityEngine;

public class Fish : PoolableMono
{ 
    public PlayerScaleType DieScaleType;  //어떤 친구까지 괜찮은지 
    public int Score;
    
    [SerializeField] private float _moveSpeed;

    public override void Init()
    {
    }
    
    private void Update()
    {
        transform.Translate(Vector3.back * (_moveSpeed * Time.deltaTime));
        
        if (transform.position.z < -25)
            PoolManager.Instance.Push(this);
    }

}
