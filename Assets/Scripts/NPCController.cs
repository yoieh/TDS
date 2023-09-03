using System.Collections;
using System.Collections.Generic;
using ProjectDawn.Navigation.Hybrid;
using Unity.Mathematics;
using UnityEngine;

public class NPCController : MonoBehaviour
{
    private AgentAuthoring navigationAgent;
    private float3 currentTarget;

    // Start is called before the first frame update
    void Start()
    {
        this.navigationAgent = this.GetComponent<AgentAuthoring>();

        this.currentTarget = GetRandomPosition();
        this.navigationAgent.SetDestination(this.currentTarget);
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log("Agent position: " + this.navigationAgent.transform.position);


        if (this.transform.position.x == this.currentTarget.x && this.transform.position.y == this.currentTarget.y)
        {
            this.currentTarget = GetRandomPosition();
            this.navigationAgent.SetDestination(this.currentTarget);
        }
    }

    float3 GetRandomPosition()
    {
        return new float3(UnityEngine.Random.Range(-10f, 10f), UnityEngine.Random.Range(-10f, 10f), .0f);
    }
}
