using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;
using ProjectDawn.Navigation.Hybrid;
using Unity.Mathematics;

namespace TDS.GOAP.Behaviours
{
    public class AgentMoveBehaviour : MonoBehaviour
    {
        private AgentBehaviour agent;
        private AgentAuthoring navigationAgent;

        // private ITarget currentTarget;
        private bool shouldMove;
        private ITarget currentTarget;

        private void Awake()
        {
            this.agent = this.GetComponent<AgentBehaviour>();
            this.navigationAgent = this.GetComponent<AgentAuthoring>();
        }

        private void OnEnable()
        {
            this.agent.Events.OnTargetInRange += this.OnTargetInRange;
            this.agent.Events.OnTargetChanged += this.OnTargetChanged;
            this.agent.Events.OnTargetOutOfRange += this.OnTargetOutOfRange;
        }

        private void OnDisable()
        {
            this.agent.Events.OnTargetInRange -= this.OnTargetInRange;
            this.agent.Events.OnTargetChanged -= this.OnTargetChanged;
            this.agent.Events.OnTargetOutOfRange -= this.OnTargetOutOfRange;
        }

        private void OnTargetInRange(ITarget target) { }

        private void OnTargetChanged(ITarget target, bool inRange)
        {
            currentTarget = target;
            this.navigationAgent.SetDestination(target.Position);
        }

        private void OnTargetOutOfRange(ITarget target)
        {
            // TODO: find new target?
        }

        private void OnDrawGizmos()
        {
            if (this.currentTarget == null)
                return;

            Gizmos.DrawLine(this.transform.position, this.currentTarget.Position);

            Gizmos.color = Color.red;
            Gizmos.DrawWireSphere(this.currentTarget.Position, 0.5f);
        }
    }
}