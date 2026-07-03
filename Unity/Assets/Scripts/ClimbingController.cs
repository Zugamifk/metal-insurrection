using System.Collections;
using UnityEngine;

public class ClimbingController : MonoBehaviour
{
    [SerializeField]
    ClimbingSensor handsSensor;
    [SerializeField]
    ClimbingSensor footSensor;
    [SerializeField]
    AnimationCurve upCurve;
    [SerializeField]
    AnimationCurve forwardCurve;
    [SerializeField]
    float climbTime;

    public bool IsClimbing { get; private set; }

    private void Update()
    {
        if (!IsClimbing && footSensor.InContact && !handsSensor.InContact)
        {
            ClimbLedge();
        }
    }

    void ClimbLedge()
    {
        if(Physics.Raycast(handsSensor.transform.position, Vector3.down, out RaycastHit hit, 2))
        {
            IsClimbing = true;
            StartCoroutine(Climb(transform.position, hit.point));
        }
    }

    IEnumerator Climb(Vector3 startPosition, Vector3 endPosition)
    {
        transform.position = startPosition;
        for(float t=0;t<1;t += Time.deltaTime / climbTime)
        {
            var up = Mathf.LerpUnclamped(startPosition.y, endPosition.y, upCurve.Evaluate(t));
            var forward = Vector3.LerpUnclamped(startPosition, endPosition, forwardCurve.Evaluate(t));
            forward.y = 0;
            transform.position = forward + Vector3.up * up;
            yield return null;
        }
        transform.position = endPosition;
        IsClimbing = false;
    }
}
