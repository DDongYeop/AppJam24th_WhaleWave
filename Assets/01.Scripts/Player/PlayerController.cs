using System;
using System.Collections;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private InputReader _inputReader;
    public InputReader InputReader => _inputReader;

    private PlayerScaleType _scaleType;
    public PlayerScaleType ScaleType => _scaleType;

    [SerializeField] private float _scaleDuration; //스케일 조절 되는거 시간 

    [Header("Score")]
    private int _score;
    public int Score
    {
        get => _score;
        set
        {
            _score = value;
            //UI반영 
        }
    }
    
    [Header("Other")] 
    private PlayerMovement _playerMovement;
    
    private void Awake()
    {
        _playerMovement = GetComponent<PlayerMovement>();
        _scaleType = PlayerScaleType.LITTLE;
    }

    [ContextMenu("Scale Up")]
    public void ScaleUp()
    {
        _scaleType = (PlayerScaleType)((int)_scaleType - 1);
        
        if (_scaleType == PlayerScaleType.NORMAL)
        {
            if (_playerMovement.CurrentTrack >= 4)
                _playerMovement.Movement(Vector3.left + transform.position, 3);
            else
                _playerMovement.Movement(Vector3.right + transform.position);
        }
        else
        {
            if (_playerMovement.CurrentTrack >= 3)
                _playerMovement.Movement(Vector3.left + transform.position, 2);
            else
                _playerMovement.Movement(Vector3.right + transform.position);
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
}