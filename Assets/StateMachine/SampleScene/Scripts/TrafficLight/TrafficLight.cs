using UnityEngine;

namespace StateMachinePattern
{
	public class TrafficLight : StateMachine
	{
        [SerializeField] private Material greenMaterial;
        [SerializeField] private AnimationCurve greenLightAnimation;
        [SerializeField] private Material yellowMaterial;
        [SerializeField] private AnimationCurve yellowLightAnimation;
        [SerializeField] private Material redMaterial;

		public GreenLightState GreenLightState { get; private set; }
		public YellowLightState YellowLightState { get; private set; }
		public RedLightState RedLightState { get; private set; }

        private void Start()
        {
            GreenLightState = new GreenLightState(5f, greenMaterial, greenLightAnimation, this);
            YellowLightState = new YellowLightState(2f, yellowMaterial, yellowLightAnimation, this);
            RedLightState = new RedLightState(5f, redMaterial, this);

            ChangeState(GreenLightState);
        }

        public bool CanCross => CurrentState is GreenLightState;
    }
}