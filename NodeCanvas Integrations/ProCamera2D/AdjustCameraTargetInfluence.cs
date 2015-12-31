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
        [RequiredField] [Tooltip("The Transform of the target")] public BBParameter<Transform> target;

        [SliderField(0f, 1f)] [Tooltip(
            "The influence this target horizontal position should have when calculating the average position of all the targets"
            )] public BBParameter<float> targetInfluenceH = 1;

        [SliderField(0f, 1f)] [Tooltip(
            "The influence this target vertical position should have when calculating the average position of all the targets"
            )] public BBParameter<float> targetInfluenceV = 1;

        [Tooltip("The time it takes for this target to reach it's influence")] public BBParameter<float> duration = 0;

        protected override string info
        {
            get
            {
                return string.Format("ProCamera2D: Adjust target {0}, influence H:{1}, V:{2}, ReachDuration:{3}", target,
                    targetInfluenceH, targetInfluenceV, duration);
            }
        }

        protected override void OnExecute()
        {
            if (ProCamera2D.Instance != null && target.value)
                ProCamera2D.Instance.AdjustCameraTargetInfluence(
                    target.value.transform, targetInfluenceH.value,
                    targetInfluenceV.value, duration.value);

            EndAction();
        }
    }
}