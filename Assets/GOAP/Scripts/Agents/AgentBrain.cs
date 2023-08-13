using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
using CrashKonijn.Goap.Resolver.Interfaces;
using TDS.GOAP.Behaviours;
using TDS.GOAP.Goals;
using UnityEngine;

namespace TDS.GOAP.Agents
{
    public class AgentBrain : MonoBehaviour
    {
        private AgentBehaviour agent;
        private HealthBehavior health;

        private void Awake()
        {
            this.agent = this.GetComponent<AgentBehaviour>();
            this.health = this.GetComponent<HealthBehavior>();
        }

        private void OnEnable()
        {
            this.agent.Events.OnActionStop += this.OnActionStop;
            this.agent.Events.OnNoActionFound += this.OnNoActionFound;
            this.agent.Events.OnGoalCompleted += this.OnGoalCompleted;
        }

        private void OnDisable()
        {
            this.agent.Events.OnActionStop -= this.OnActionStop;
            this.agent.Events.OnNoActionFound -= this.OnNoActionFound;
            this.agent.Events.OnGoalCompleted -= this.OnGoalCompleted;
        }

        private void Start()
        {
            this.agent.SetGoal<WanderGoal>(true);
        }

        private void OnNoActionFound(IGoalBase goal)
        {
            this.agent.SetGoal<WanderGoal>(false);
        }

        private void OnGoalCompleted(IGoalBase goal)
        {
            this.agent.SetGoal<WanderGoal>(false);
        }


        private void OnActionStop(IAction action)
        {
            this.UpdateHunger();
        }

        private void UpdateHunger()
        {
            if (this.health.bleeding > 0f)
            {
                this.agent.SetGoal<FixBleedingGoal>(false);
                return;
            }

            if (this.health.hunger > 80f)
            {
                this.agent.SetGoal<FixHungerGoal>(false);
                return;
            }

            if (this.health.thirst > 80f)
            {
                this.agent.SetGoal<FixThirstGoal>(false);
                return;
            }

            if (this.health.hunger < 20f || this.health.thirst < 20f || this.health.blood < 10f)
            {
                this.agent.SetGoal<WanderGoal>(true);
            }
        }

    }
}