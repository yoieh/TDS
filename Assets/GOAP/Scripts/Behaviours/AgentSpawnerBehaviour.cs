using CrashKonijn.Goap.Behaviours;
using CrashKonijn.Goap.Interfaces;
// using CrashKonijn.Goap.Interfaces;
using UnityEngine;

namespace TDS.GOAP.Behaviours
{
    public class AgentSpawnerBehaviour : MonoBehaviour
    {
        private static readonly Vector2 Bounds = new(15f, 8f);

        [SerializeField]
        private GoapSetBehaviour goapSet;

        [SerializeField]
        private int spawnAmount = 10;

        [SerializeField]
        private GameObject agentPrefab;

        private void Awake()
        {
            this.goapSet = FindObjectOfType<GoapSetBehaviour>();
            this.agentPrefab.SetActive(false);
        }

        private void Start()
        {
            for (var i = 0; i < this.spawnAmount; i++)
            {
                this.SpawnAgent();
                Debug.Log($"Spawned agent {i}");
            }
        }

        private void SpawnAgent()
        {
            GameObject go = Instantiate(this.agentPrefab, this.GetRandomPosition(), Quaternion.identity);

            AgentBehaviour agent = go.GetComponent<AgentBehaviour>();
            agent.goapSetBehaviour = this.goapSet;


            go.SetActive(true);
        }

        private Vector3 GetRandomPosition()
        {
            var randomX = Random.Range(-Bounds.x, Bounds.x);
            var randomY = Random.Range(-Bounds.y, Bounds.y);

            return new Vector3(randomX, randomY, 0f);
        }
    }
}
