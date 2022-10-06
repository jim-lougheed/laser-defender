using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pathfinder : MonoBehaviour
{
    EnemySpawner enemySpawner;
    WaveConfigSO waveConfig;
    List<Transform> waypoints;
    int waypointIndex = 0;

    void Awake() {
        enemySpawner = FindObjectOfType<EnemySpawner>();
    }
    void Start()
    {
        waveConfig = enemySpawner.GetCurrentWave();
        waypoints = waveConfig.GetWaypoints();
        transform.position = waypoints[waypointIndex].position;
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
    }

    void Update()
    {
        FollowPath();
        Debug.Log(transform.position.x);
        Debug.Log(transform.position.y);
    }

    void FollowPath() {
        if (waypointIndex < waypoints.Count) {
            Vector3 targetPosition = waypoints[waypointIndex].position;
            float delta = waveConfig.GetMoveSpeed() * Time.deltaTime;
            transform.position = Vector2.MoveTowards(transform.position, targetPosition, delta);
            if (transform.position == targetPosition) {
                waypointIndex++;
            }
        } else {
            Destroy(gameObject);
        }
    }
}
