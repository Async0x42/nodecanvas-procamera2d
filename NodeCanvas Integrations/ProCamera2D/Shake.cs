using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description("Shakes the camera position along its horizontal and vertical axes with the values setup in the editor"
        )]
    public class Shake : ActionTask
    {
        [Tooltip("The camera with the ProCamera2D component, most probably the MainCamera. If empty, the ProCamera2D instance will be used.")] public
            BBParameter<GameObject> MainCamera;

        protected override string info
        {
            get
            {
                if (MainCamera.value == null)
                    return "ProCamera2D: Default - Shake";
                else
                    return string.Format("ProCamera2D: {0} - Shake", MainCamera);
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
                shake.Shake();

            EndAction();
        }
    }
}