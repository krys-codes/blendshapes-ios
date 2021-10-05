using System.Text;
using Unity.Collections;
using UnityEngine;
using UnityEngine.XR.ARFoundation;
using UnityEngine.XR.ARKit;

[RequireComponent(typeof(ARFace))]
public class PrintBlendShapes : MonoBehaviour
{
    void Update()
    {
#if UNITY_IOS
        if (FindObjectOfType<ARFaceManager>() is ARFaceManager manager)
        {
            if (manager.subsystem is ARKitFaceSubsystem subsystem)
            {
                using (var blendShapeCoefficients = subsystem.GetBlendShapeCoefficients(GetComponent<ARFace>().trackableId, Allocator.Temp))
                {
                    var sb = new StringBuilder();
                    foreach (var coefficient in blendShapeCoefficients)
                    {
                        sb.Append($"\t{coefficient.blendShapeLocation}: {coefficient.coefficient}\n");
                    }
                    Debug.Log($"Blend shape coefficients:\n{sb.ToString()}");
                }
            }
        }
#endif
    }
}