using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Moves the camera instantly to the defined position")]
    public class MoveCameraInstantlyToPosition : ActionTask
    {
        [RequiredField]
        [Tooltip("The final position of the camera")]
        public BBParameter<Vector3> CameraPos;

        protected override string info
        {
            get
            {
                return string.Format("ProCamera2D: Move instantly to {0}", CameraPos);
            }
        }

        protected override void OnExecute()
        {
            if (ProCamera2D.Instance != null)
                ProCamera2D.Instance.MoveCameraInstantlyToPosition(CameraPos.value);

            EndAction();
        }
    }
}