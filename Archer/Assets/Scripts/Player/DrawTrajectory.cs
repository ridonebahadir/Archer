using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DrawTrajectory : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;

    [SerializeField]
    [Range(3, 30)]
    private int lineSegmentCount = 20;

    private List<Vector3> linePoints = new List<Vector3>();

    public static DrawTrajectory Instance;
    public GameObject Target;
    private void Awake()
    {
        Instance = this;
    }

    public void UpdateTarejectory(Vector3 forceVector, Rigidbody rigidbody, Vector3 startingPoint)
    {

        

        Vector3 velocity = (forceVector / rigidbody.mass) * Time.fixedDeltaTime;

        float FlightDuration = ((2 * velocity.y) / (Physics.gravity.y));

        float stepTime = FlightDuration / lineSegmentCount;

        linePoints.Clear();

        for (int i = 0; i < lineSegmentCount; i++)
        {
            float stepTimePassed = stepTime * i;

            Vector3 movementVector = new Vector3(
                    velocity.x * stepTimePassed,
                    velocity.y * stepTimePassed - 0.5f * Physics.gravity.y * stepTimePassed * stepTimePassed,
                    velocity.z * stepTimePassed
            );

            linePoints.Add(-movementVector + startingPoint);
        }

        lineRenderer.positionCount = linePoints.Count;
        lineRenderer.SetPositions(linePoints.ToArray());
        Target.transform.position = linePoints[19];
    }
    public void HideLine()
    {
        lineRenderer.positionCount = 0;
    }
}
