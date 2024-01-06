using System.Collections;
using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    [SerializeField] private float _duration; //움직이는거 시간
    private PlayerController _playerController;

    private int _currentTrack = 2;
    public int CurrentTrack => _currentTrack;
    private bool _isMoving = false;
    
    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void OnEnable()
    {
        _playerController.InputReader.UpEvent += UpMovement;
        _playerController.InputReader.DownEvent += DownMovement;
    }

    private void OnDisable()
    {
        _playerController.InputReader.UpEvent -= UpMovement;
        _playerController.InputReader.DownEvent -= DownMovement;
    }

    private void UpMovement()
    {
        if (_isMoving || _currentTrack - 1 < 0)
            return;

        _currentTrack -= 1;
        Movement(transform.position + Vector3.left * 2);
    }
    
    private void DownMovement()
    {
        if (_isMoving || (int)_playerController.ScaleType <= _currentTrack + 1)
            return;
        
        _currentTrack += 1;
        Movement(transform.position + Vector3.right * 2);
    }

    public void Movement(Vector3 endPos, int track = -1)
    {
        if (track != -1)
            _currentTrack = track;
        
        StopAllCoroutines();
        StartCoroutine(MovementCo(endPos));
    }

    private IEnumerator MovementCo(Vector3 endPos)
    {
        _isMoving = true;
        Vector3 startPos = transform.position;
        float currentTime = 0;

        while (currentTime < _duration)
        {
            yield return null;
            currentTime += Time.deltaTime;
            float time = currentTime / _duration;
            transform.position = Vector3.Lerp(startPos, endPos, time);
        }

        transform.position = endPos;
        _isMoving = false;
    }
}
