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
        if (other.CompareTag("Fish"))
        {
            Transform trm = PoolManager.Instance.Pop("HitParticle").GetComponent<Transform>();
            trm.position = other.transform.position;
            
            Fish fish = other.GetComponent<Fish>();
            if ((int)_playerController.ScaleType > (int)fish.DieScaleType)
            {
                _playerController.Hp -= fish.Damage;
                PoolManager.Instance.Push(other.GetComponent<PoolableMono>());
                SoundManager.Instance.PlaySound("whale_hit");
            }
            else
            {
                _playerController.Hp += fish.Heal;
                _playerController.Score += fish.Score;
                PoolManager.Instance.Push(other.GetComponent<PoolableMono>());
                SoundManager.Instance.PlaySound("whale_eat_2");
            }
        }
    }
}
