using UnityEngine;

namespace StateMachinePattern
{
    public class RedLightState : IState
    {
        private float duration;
        private TrafficLight trafficLight;
        private Material material;

        private float timer;

        public RedLightState(float duration, Material material, TrafficLight trafficLight)
        {
            this.duration = duration;
            this.material = material;
            this.material.color = new Color(0.5f, 0f, 0f);
            this.trafficLight = trafficLight;
        }

        public void OnEnter()
        {
            timer = 0f;
            material.color = new Color(1f, 0f, 0f);
        }

        public void OnExit()
        {
            material.color = new Color(0.5f, 0f, 0f);
        }

        public void OnFixedUpdate()
        {
            //
        }

        public void OnUpdate()
        {
            timer += Time.deltaTime;

            if (timer >= duration)
            {
                trafficLight.ChangeState(trafficLight.GreenLightState);
            }
        }
    }
}