using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Splines;
using Unity.Mathematics;

public class SplineFollower : MonoBehaviour
{
    [SerializeField] SplineContainer splineContainer;
    [SerializeField] GameObject endPanel;
    public float speed = 1.0f;
    public float tDistance = 0; // distance along spline (0-1)


    //public float speed { get; set; }

    // length in world coordinates
    public float length { 
        get {
            if (splineContainer != null) return splineContainer.CalculateLength();
            else return 0;
        } 
    }

    // distance in world coordinates
    public float distance { 
        get { return tDistance * length; }
        set { tDistance = value / length; }
    }

	void Update()
    {
        distance += speed * Time.deltaTime;
        UpdateTransform(math.frac(tDistance));
        if(tDistance >= 0.995)
        {
            if(endPanel != null) endPanel.SetActive(true);
        }
    }

    void UpdateTransform(float t)
    {
        if(splineContainer != null)
        {
            Vector3 position = splineContainer.EvaluatePosition(t);
            Vector3 up = splineContainer.EvaluateUpVector(t);
            Vector3 forward = Vector3.Normalize(splineContainer.EvaluateTangent(t));
            Vector3 right = Vector3.Cross(up, forward);

            transform.position = position;
            transform.rotation = Quaternion.LookRotation(forward, up);
        }
    }
}
