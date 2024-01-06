using System;
using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    public InputReader InputReader => _inputReader;

    private PlayerScaleType _scaleType;
    public PlayerScaleType ScaleType => _scaleType;

    [SerializeField] private float _scaleDuration; //스케일 조절 되는거 시간 

    [Header("hp")] 
    public float MaxHP;
    private float _hp;
    public float Hp
    {
        get => _hp;
        set
        {
            _hp = value;
            _hp = Mathf.Clamp(_hp, 0, MaxHP);
            if (_hp <= 0)
                print("GameOver");
            _hpSlider.value = Hp / MaxHP;
        }
    }
    
    [Header("Score")]
    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            _scoreUI.UpdateScore(_score);
            Biggest();
        }
    }

    [Header("UI")] 
    private Slider _hpSlider;
    
    [Header("Other")] 
    private PlayerMovement _playerMovement;
    private Score _scoreUI;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _scaleType = PlayerScaleType.LITTLE;
        _scoreUI = FindObjectOfType<Score>();
        _hpSlider = GameObject.Find("HPSlider").GetComponent<Slider>();
        Hp = MaxHP;
    }

    private void Update()
    {
        Hp -= _score * Time.deltaTime * 0.005f;
    }

    [ContextMenu("Scale Up")]
    public void ScaleUp()
    {
        _scaleType = (PlayerScaleType)((int)_scaleType - 1);
        
        if (_scaleType == PlayerScaleType.NORMAL)
        {
            if (_playerMovement.CurrentTrack >= 4)
                _playerMovement.Movement(new Vector3(-1, 1, 0) + transform.position, 3);
            else
                _playerMovement.Movement(new Vector3(1, 1, 0) + transform.position);
        }
        else
        {
            if (_playerMovement.CurrentTrack >= 3)
                _playerMovement.Movement(new Vector3(-1, 1, 0) + transform.position, 2);
            else
                _playerMovement.Movement(new Vector3(1, 1, 0) + transform.position);
        }
        StartCoroutine(ScaleCo(transform.localScale + Vector3.one));
    }

    private IEnumerator ScaleCo(Vector3 endScale)
    {
        Vector3 startScale = transform.localScale;
        float currentTime = 0;

        while (currentTime < _scaleDuration)
        {
            yield return null;
            currentTime += Time.deltaTime;
            float time = currentTime / _scaleDuration;
            transform.localScale = Vector3.Lerp(startScale, endScale, time);
        }
        transform.localScale = endScale; 
    }

    private void Biggest()
    {
        if (_score >= 500 && _scaleType == PlayerScaleType.LITTLE)
            ScaleUp();
        if  (_score >= 1500 && _scaleType == PlayerScaleType.NORMAL)
            ScaleUp(); 
    }
}
