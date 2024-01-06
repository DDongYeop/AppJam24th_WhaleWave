using System.Collections;
using UnityEngine;

public class ObjectSpawner : MonoBehaviour
{
    [SerializeField] private Vector2 _waitTime; //x == 최소 시간, y == 최대시간 
    [SerializeField] private string[] _spawnObjStr;
    private Transform[] _spawnPoint;
 
    private void Awake()
    {
        _spawnPoint = GetComponentsInChildren<Transform>();
        StartCoroutine(ObjectSpawnCo());
    }

    private IEnumerator ObjectSpawnCo()
    {
        while (true)
        {
            float waitTime = Random.Range(_waitTime.x, _waitTime.y);
            yield return new WaitForSeconds(waitTime);
            
            if (SkillManager.Instance.IsStop)
                continue;
            
            int spawnPoint = Random.Range(1, _spawnPoint.Length);
            int objIndex = Random.Range(0, _spawnObjStr.Length);
            Transform fish = PoolManager.Instance.Pop(_spawnObjStr[objIndex]).GetComponent<Transform>();
            fish.position = _spawnPoint[spawnPoint].position + new Vector3(0, .5f, 0);
        }
    }

    /// <summary>
    /// 특정 위치에 물고기 스폰
    /// </summary>
    /// <param name="spawnPos">스폰될 위치</param>
    /// <param name="spawnObjectName">스폰될 물고기 이름 </param>
    public void FishSpawn(int spawnPos, string spawnObjectName)
    {
        Transform fish = PoolManager.Instance.Pop(spawnObjectName).GetComponent<Transform>();
        fish.position = _spawnPoint[spawnPos].position + new Vector3(0, .5f, 0);
    }
}
