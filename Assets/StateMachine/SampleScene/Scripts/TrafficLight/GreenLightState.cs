using UnityEngine;

namespace StateMachinePattern
{
    public class GreenLightState : IState
    {
        private float duration;
        private TrafficLight trafficLight;
        private AnimationCurve lightAnimation;
        private Material material;

        private float timer;

        public GreenLightState(float duration, Material material, AnimationCurve lightAnimation, TrafficLight trafficLight)
        {
            this.duration = duration;
            this.material = material;
            this.lightAnimation = lightAnimation;
            this.material.color = new Color(0f, lightAnimation.Evaluate(0f), 0f);
            this.trafficLight = trafficLight;
        }

        public void OnEnter()
        {
            timer = 0f;
            material.color = new Color(0f, lightAnimation.Evaluate(0f), 0f);
        }

        public void OnExit()
        {
            material.color = new Color(0f, lightAnimation.Evaluate(1f), 0f);
        }

        public void OnFixedUpdate()
        {
            //
        }

        public void OnUpdate()
        {
            timer += Time.deltaTime;
            material.color = new Color(0f, lightAnimation.Evaluate(timer / duration), 0f);

            if (timer >= duration)
            {
                trafficLight.ChangeState(trafficLight.YellowLightState);
            }
        }
    }
}