using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Adjusts a target influence")]
    public class AdjustCameraTargetInfluence : ActionTask
    {
        [RequiredField]
        [Tooltip("The Transform of the target")]
        public BBParameter<Transform> Target;

        [SliderField(0f, 1f)]
        [Tooltip("The influence this target horizontal position should have when calculating the average position of all the targets")]
        public BBParameter<float> TargetInfluenceH = 1;

        [SliderField(0f, 1f)]
        [Tooltip("The influence this target vertical position should have when calculating the average position of all the targets")]
        public BBParameter<float> TargetInfluenceV = 1;

        [Tooltip("The time it takes for this target to reach it's influence")]
        public BBParameter<float> Duration = 0;

        protected override string info
        {
            get
            {
                return string.Format("ProCamera2D: Adjust target {0}, influence H:{1}, V:{2}, ReachDuration:{3}", Target,
                    TargetInfluenceH, TargetInfluenceV, Duration);
            }
        }

        protected override void OnExecute()
        {
            if (ProCamera2D.Instance != null && Target.value)
                ProCamera2D.Instance.AdjustCameraTargetInfluence(Target.value.transform, TargetInfluenceH.value,TargetInfluenceV.value, Duration.value);

            EndAction();
        }
    }
}