using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using UnityEngine;
using ProjectDawn.Navigation;
using ProjectDawn.Navigation.Hybrid;


namespace TDS.GOAP.Behaviours
{
    public class AgentMoveBehaviour : MonoBehaviour
    {
        private AgentBehaviour agent;
        private AgentAuthoring navigationAgent;
        private ITarget currentTarget;
        // private bool shouldMove;

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
            this.currentTarget = target;
            this.navigationAgent.SetDestination(this.currentTarget.Position);
        }

        private void OnTargetOutOfRange(ITarget target) { }
    }
}