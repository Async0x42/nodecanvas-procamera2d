using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Shakes the camera position along its horizontal and vertical axes with the given values")]
    public class ShakeWithValues : ActionTask
    {
        [RequiredField]
        [Tooltip("The camera with the ProCamera2D component, most probably the MainCamera")]
        public BBParameter<GameObject> MainCamera;

        [Tooltip("The shake strength on each axis")]
        public BBParameter<Vector2> Strength;

        [Tooltip("The duration of the shake")]
        public BBParameter<float> Duration = 1;

        [Tooltip("Indicates how much will the shake vibrate. Don't use values lower than 1 or higher than 100 for better results")]
        public BBParameter<int> Vibration = 10;

        [Tooltip("Indicates how much random the shake will be")]
        [SliderField(0, 1f)]
        public BBParameter<float> Randomness = .1f;

        [Tooltip("The initial angle of the shake. Use -1 if you want it to be random.")]
        [SliderField(-1, 360)]
        public BBParameter<int> InitialAngle = 10;

        [Tooltip("The maximum rotation the camera can reach during shake")]
        public BBParameter<Vector3> Rotation;

        [Tooltip("How smooth the shake should be, 0 being instant")]
        [SliderField(0, .5f)]
        public BBParameter<float> Smoothness;

        protected override string info
        {
            get
            {
                if (MainCamera.value == null)
                    return "ProCamera2D: Default - Shake w/ Values";
                else
                    return string.Format("ProCamera2D: {0} - Shake w/ Values", MainCamera);
            }
        }

        protected override void OnExecute()
        {
            ProCamera2DShake shake;

            if (MainCamera.value == null)
                shake = ProCamera2D.Instance.GetComponent<ProCamera2DShake>();
            else
                shake = MainCamera.value.GetComponent<ProCamera2DShake>();

            if (shake == null)
                Debug.LogError("The ProCamera2D component needs to have the Shake plugin enabled.");

            if (ProCamera2D.Instance != null && shake != null)
                shake.Shake(
                    Duration.value,
                    Strength.value,
                    Vibration.value,
                    Randomness.value,
                    InitialAngle.value,
                    Rotation.value,
                    Smoothness.value);

            EndAction();
        }
    }
}