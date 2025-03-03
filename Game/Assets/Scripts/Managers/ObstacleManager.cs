using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObstacleManager : MonoBehaviour
{
    [SerializeField] int random;
    [SerializeField] int createCount = 5;
    [SerializeField] List<GameObject> obstacles;

    [SerializeField] List<string> obstaclesNames; 

    void Start()
    {
        Create();

        StartCoroutine(ActiveObstacle());
    }

    public void Create()
    {
        obstacles.Capacity = 10;

        for(int i = 0; i < createCount; i++)
        {          
            GameObject prefab = ResourcesManager.Instance.Instantiate(obstaclesNames[Random.Range(0, obstaclesNames.Count)]);

            prefab.SetActive(false);

            obstacles.Add(prefab);
        }
    }

    public bool ExamineActive()
    {
        for(int i = 0; i < obstacles.Count; i++)
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
        while (true)
        { 
            yield return new WaitForSeconds(2.5f);

            random = Random.Range(0, obstacles.Count);

            // 현재 게임 오브젝트가 활성화되어 있는지 확인합니다.
            while (obstacles[random].activeSelf == true)
            {
                // 현재 리스트에 있는 모든 게임 오브젝트가 활성화되어 있는지 확인합니다.
                if (ExamineActive())
                {
                    // 모든 게임 오브젝트가 활성화되어 있다면 게임 오브젝트를 새로
                    // 생성한 다음 obstacles 리스트에 넣어줍니다.
                    GameObject prefab = ResourcesManager.Instance.Instantiate(obstaclesNames[Random.Range(0, obstaclesNames.Count)]);

                    prefab.SetActive(false);

                    obstacles.Add(prefab);
                }

                // 현재 인덱스에 있는 게임 오브젝트가 활성화되어 있으면
                // random 변수의 값을 +1 해서 다시 검색합니다.
                random = (random + 1) % obstacles.Count;
            }

            // 랜덤으로 설정된 Obstacle 오브젝트를 활성화합니다/
            // obstacles[random].SetActive(true);
        }
    }

    public GameObject GetObstacle()
    {
        return obstacles[random];
    }

}
