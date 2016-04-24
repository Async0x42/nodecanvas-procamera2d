using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Remove a target from the camera")]
    public class RemoveCameraTarget : ActionTask
    {
        [RequiredField]
        [Tooltip("The Transform of the target")]
        public BBParameter<GameObject> Target;

        [Tooltip("The time it takes for this target to reach a zero influence. Use for a more progressive transition.")]
        public BBParameter<float> Duration = 0;

        protected override string info
        {
            get
            {
                return string.Format("ProCamera2D: Remove target {0} ReachDuration: {1}s", Target, Duration);
            }
        }

        protected override void OnExecute()
        {
            if (ProCamera2D.Instance != null && Target.value)
                ProCamera2D.Instance.RemoveCameraTarget(Target.value.transform, Duration.value);

            EndAction();
        }
    }
}