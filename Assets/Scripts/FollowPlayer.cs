using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;
using UnityEngine.SceneManagement;

public class FollowPlayer : MonoBehaviour
{

    [SerializeField] private Transform playerTransform;

    [SerializeField] private GameObject player;
    [SerializeField] private GameObject enemy;

    private NavMeshAgent agent;

    // Start is called before the first frame update
    void Start()
    {
        playerTransform = player.transform;
        agent = GetComponent<NavMeshAgent>();
    }

    // Update is called once per frame
    void Update()
    {
        agent.SetDestination(playerTransform.position);
    }
}
