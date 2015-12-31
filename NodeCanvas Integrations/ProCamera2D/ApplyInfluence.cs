using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Apply the given influence to the camera")]
    public class ApplyInfluence : ActionTask
    {
        [Tooltip("The vector representing the influence to be applied")]
        public BBParameter<Vector2> Influence;

        protected override string info
        {
            get
            {
                return string.Format("ProCamera2D: Apply influence {0}", Influence);
            }
        }

        protected override void OnUpdate()
        {
            if (ProCamera2D.Instance != null)
                ProCamera2D.Instance.ApplyInfluence(Influence.value);

            EndAction();
        }
    }
}