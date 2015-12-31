using Com.LuisPedroFonseca.ProCamera2D;
using UnityEngine;
using NodeCanvas.Framework;
using ParadoxNotion.Design;

namespace NodeCanvas.Tasks.PC2D
{
    [Category("ProCamera2D")]
    [Description(
        "Shakes the camera position along its horizontal and vertical axes using a preset configured in the editor")]
    public class ShakeWithPreset : ActionTask
    {
        [RequiredField] [Tooltip("The camera with the ProCamera2D component, most probably the MainCamera")] public
            BBParameter<GameObject> MainCamera;

        [Tooltip("The name of the shake preset configured in the editor")] public BBParameter<string> PresetName;
        
        protected override string info
        {
            get
            {
                if (MainCamera.value == null)
                    return string.Format("ProCamera2D: Default - Shake w/ Present: {0}", PresetName);
                else
                    return string.Format("ProCamera2D: {0} - Shake w/ Present: {1}", MainCamera, PresetName);
            }
        }

        protected override void OnExecute()
        {
            var shake = MainCamera.value.GetComponent<ProCamera2DShake>();

            if (shake == null)
                Debug.LogError("The ProCamera2D component needs to have the Shake plugin enabled.");

            if (ProCamera2D.Instance != null && shake != null)
                shake.ShakeUsingPreset(PresetName.value);

            EndAction();
        }
    }
}