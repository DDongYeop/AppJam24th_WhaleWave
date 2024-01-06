using System;
using System.Collections;
using UnityEngine;

public class Fish : PoolableMono
{ 
    public PlayerScaleType DieScaleType;  //어떤 친구까지 괜찮은지
    [SerializeField] private float _duration;
    public int Score;
    public int Damage;
    
    public float MoveSpeed;
    [HideInInspector] public float CurrentMoveSpeed;
    private MeshRenderer _meshRenderer;
    private readonly int _hashDissolved = Shader.PropertyToID("_Dissolved");

    private void Awake()
    {
        _meshRenderer = transform.Find("Visual").GetComponent<MeshRenderer>();
    }

    public override void Init()
    {
        if (SkillManager.Instance.IsFast)
            CurrentMoveSpeed = MoveSpeed * 1.5f;
        else
            CurrentMoveSpeed = MoveSpeed;
        _meshRenderer.material.SetFloat(_hashDissolved, -1);
    }
    
    private void Update()
    {
        transform.Translate(Vector3.back * (CurrentMoveSpeed * Time.deltaTime));
        
        if (transform.position.z < -25)
            PoolManager.Instance.Push(this);
    }

    public void Dissolve()
    {
        StartCoroutine(DissolveCo());
    }

    private IEnumerator DissolveCo()
    {
        float currentTime = 0;

        while (currentTime < _duration)
        {
            yield return null;
            CurrentMoveSpeed = 0;
            currentTime += Time.deltaTime;
            float time = currentTime / _duration;
            _meshRenderer.material.SetFloat(_hashDissolved, Mathf.Lerp(-1, .5f, time));
        }
        PoolManager.Instance.Push(this);
    }
}
