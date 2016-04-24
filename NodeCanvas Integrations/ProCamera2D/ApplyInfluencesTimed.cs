using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Apply the given influences to the camera during the corresponding durations")]
    public class ApplyInfluencesTimed : ActionTask
    {
        [RequiredField]
        [Tooltip("An array of the vectors representing the influences to be applied")]
        public BBParameter<Vector2[]> Influences;

        [RequiredField]
        [Tooltip("An array of the vectors representing the influences to be applied")]
        public BBParameter<float[]> Durations;

        protected override string info
        {
            get
            {
                return "ProCamera2D: Apply timed influences";
            }
        }

        protected override void OnExecute()
        {
            if (ProCamera2D.Instance != null)
            {
                var entries = this.Influences.value.GetLength(0);

                var influences = new Vector2[entries];
                for (int i = 0; i < entries; i++)
                {
                    influences[i] = (Influences.value.GetValue(i) as BBParameter<Vector2>).value;
                }

                var durations = new float[entries];
                for (int i = 0; i < entries; i++)
                {
                    durations[i] = (Durations.value.GetValue(i) as BBParameter<float>).value;
                }

                ProCamera2D.Instance.ApplyInfluencesTimed(influences, durations);
            }

            EndAction();
        }
    }
}