using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PositionManager : MonoBehaviour
{
    [SerializeField] Coroutine coroutine;

    [SerializeField] int index = -1;
    [SerializeField] Transform[] parentRoads;
    [SerializeField] Transform[] positionRandomX;

    [SerializeField] ObstacleManager obstacleManager;
    [SerializeField] float[] randomPositionZ = new float[16];

    private void Awake()
    {
        for (int i = 0; i < randomPositionZ.Length; i++)
        {
            randomPositionZ[i] = i * 2.5f + -10.0f;
        }
    }

    public IEnumerator SetPosition()
    {
        while (GameManager.Instance.State)
        {
            yield return CoroutineCache.WaitForSecond(TimeManager.Instance.ActiveTime);

            transform.localPosition = new Vector3(0, 0, randomPositionZ[Random.Range(0, randomPositionZ.Length)]);

            obstacleManager.GetObstacle().SetActive(true);

            obstacleManager.GetObstacle().transform.position = positionRandomX[Random.Range(0, positionRandomX.Length)].position;

            obstacleManager.GetObstacle().transform.SetParent(transform.root.GetChild(index));
        }
    }

    public void InitializePosition()
    {
        if (coroutine == null)
        {
            coroutine = StartCoroutine(SetPosition());
        }

        index = (index + 1) % parentRoads.Length;

        transform.SetParent(parentRoads[index]);

        transform.localPosition += new Vector3(0, 0, 40);
    }

}