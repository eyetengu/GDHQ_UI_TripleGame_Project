using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WaypointTriggerScript : MonoBehaviour
{
    [SerializeField] private SpyBehavior _spyBehavior;


    private void Start()
    {
        _spyBehavior = FindObjectOfType<SpyBehavior>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.tag == "Spy")
        {
            _spyBehavior.TriggerIsHiding();
        }

    }


}
