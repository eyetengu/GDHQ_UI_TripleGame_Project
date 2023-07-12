using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.AI;

public class SpyBehavior : MonoBehaviour
{
    [SerializeField] private Transform[] _waypoints;    
    private bool _moveToWaypoint;
    private bool _isInSafeZone;
    [SerializeField] private bool _isHiding;
    [SerializeField] private Transform selectedWaypoint;
    private NavMeshAgent _navMeshAgent;
    [SerializeField] private float distance;


    void Start()
    {
        _navMeshAgent= GetComponent<NavMeshAgent>();
        selectedWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];
    }

    void Update()
    {
        distance = Vector3.Distance(transform.position, selectedWaypoint.position);
        if (distance < 1.0f)
        {
            _isHiding = true;
            StartCoroutine(PauseAtWaypoint());
        }

        if (_isHiding == false)
        {
            Debug.Log("Not Hiding");
            MoveSpy(); 
        }        
    }

    private void MoveSpy()
    {
        _navMeshAgent.SetDestination(selectedWaypoint.transform.position);
    }
    
    public void TriggerIsHiding()
    {
        //_isHiding = true;
        StartCoroutine(PauseAtWaypoint());
    }

    private void ChooseNewWaypoint()
    {
        selectedWaypoint = _waypoints[Random.Range(0, _waypoints.Length)];
    }

    IEnumerator PauseAtWaypoint()
    {
        _navMeshAgent.speed = 0;
        yield return new WaitForSeconds(5);
        ChooseNewWaypoint();
        _isHiding = false;
        _navMeshAgent.speed = 8;
    }
}
