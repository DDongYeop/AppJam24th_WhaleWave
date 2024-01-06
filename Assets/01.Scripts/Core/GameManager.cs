using UnityEngine;

public class GameManager : MonoBehaviour
{
    [SerializeField] private PoolingListSO _poolingListSo;

    private void Awake()
    {
        CreatePool();
    }

    private void CreatePool()
    {
        PoolManager.Instance = new PoolManager(transform);
        _poolingListSo.PoolList.ForEach(p =>
        {
            PoolManager.Instance.CreatePool(p.Prefab, p.Count);
        });
    }
}
