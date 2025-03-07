using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles = new List<GameObject>();  // 리스트 초기화

    [SerializeField] List<string> obstacleNames;

    void Start()
    {
        if (obstacleNames == null || obstacleNames.Count == 0)
        {
            Debug.LogError("obstacleNames 리스트가 비어 있습니다!");
            return;
        }

        if (ResourcesManager.Instance == null)
        {
            Debug.LogError("ResourcesManager instance is null!");
            return;
        }

        Create();
        StartCoroutine(ActiveObstacle());
    }

    public void Create()
    {
        obstacles.Capacity = 10;

        for (int i = 0; i < createCount; i++)
        {
            GameObject prefab = ResourcesManager.Instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)]);

            if (prefab == null)
            {
                Debug.LogError("Prefab instantiation failed!");
                return;
            }

            prefab.SetActive(false);
            obstacles.Add(prefab);
        }
    }

    public bool ExamineActive()
    {
        for (int i = 0; i < obstacles.Count; i++)
        {
            if (obstacles[i].activeSelf == false)
            {
                return false;
            }
        }

        return true;
    }

    IEnumerator ActiveObstacle()
    {
        while (GameManager.Instance.State)
        {
            yield return CoroutineCache.WaitForSecond(TimeManager.Instance.ActiveTime);

            if (obstacles.Count == 0)
            {
                Debug.LogError("obstacles 리스트가 비어 있습니다!");
                yield break;
            }

            random = Random.Range(0, obstacles.Count);

            while (obstacles[random].activeSelf == true)
            {
                if (ExamineActive())
                {
                    GameObject prefab = ResourcesManager.Instance.Instantiate(obstacleNames[Random.Range(0, obstacleNames.Count)]);

                    if (prefab == null)
                    {
                        Debug.LogError("Prefab instantiation failed!");
                        yield break;
                    }

                    prefab.SetActive(false);
                    obstacles.Add(prefab);
                }

                random = (random + 1) % obstacles.Count;
            }
        }
    }

    public GameObject GetObstacle()
    {
        return obstacles[random];
    }
}
