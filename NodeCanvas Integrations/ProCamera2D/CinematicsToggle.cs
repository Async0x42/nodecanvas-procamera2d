using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Starts or stops a cinematic")]
    public class CinematicsToggle : ActionTask
    {
        [RequiredField]
        [Tooltip("The gameObject that contains the ProCamera2DCinematics component")]
        public BBParameter<GameObject> Cinematics;

        protected override string info
        {
            get
            {
                return string.Format("ProCamera2D: Toggle cinematics on {0}", Cinematics);
            }
        }

        protected override void OnExecute()
        {
            var cinematicsComp = Cinematics.value.GetComponent<ProCamera2DCinematics>();

            if (Cinematics == null)
                Debug.LogError("No Cinematics component found in the gameObject: " + Cinematics.value.name);

            if (ProCamera2D.Instance != null && Cinematics != null)
                cinematicsComp.Toggle();

            EndAction();
        }
    }
}