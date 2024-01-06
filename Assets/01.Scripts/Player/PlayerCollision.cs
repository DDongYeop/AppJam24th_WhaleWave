using UnityEngine;

public class PlayerCollision : MonoBehaviour
{
    private PlayerController _playerController;

    private void Awake()
    {
        _playerController = GetComponent<PlayerController>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Finish"))
        {
            Fish fish = other.GetComponent<Fish>();
            if ((int)_playerController.ScaleType > (int)fish.DieScaleType)
            {
                print("GameOver");
                return;
            }
            _playerController.Score += fish.Score;
            PoolManager.Instance.Push(other.GetComponent<PoolableMono>());
        }
    }
}
