using System.Collections.Generic;
using UnityEngine;

[RequireComponent( typeof( Camera ) )]
public class MultipleTargetCamera : MonoBehaviour
{
    public Camera cam;
    public List<Transform> targets;

    public Vector3 offset;
    public float smoothTime = 0.5f;

    public float minZoom = 40;
    public float maxZoom = 10;
    public float zoomLimiter = 50;

    private Vector3 velocity;

    private void Reset()
    {
        cam = GetComponent<Camera>();
    }

    private void LateUpdate()
    {
        if ( targets.Count == 0 ) return;

        Move();
        Zoom();
    }

    private void Zoom()
    {
        var newZoom = Mathf.Lerp( maxZoom, minZoom, GetGreatestDistance() / zoomLimiter );
        cam.fieldOfView = Mathf.Lerp( cam.fieldOfView, newZoom, Time.deltaTime );
    }

    private void Move()
    {
        if (!this.needToMove()) {
            return;
        }
        var centerPoint = GetCenterPoint();
        var newPosition = centerPoint + offset;
        transform.position = Vector3.SmoothDamp( transform.position, newPosition, ref velocity, smoothTime );
    }

    private bool needToMove() {
        // キャラクターが画面端の方に行ったら移動が必要
        for ( int i = 0; i < targets.Count ; i++) {
            float xDistance = Mathf.Abs(targets[i].position.x) - Mathf.Abs(transform.position.x);
            Debug.Log(xDistance);
            if (xDistance > 6.2) {
                return true;
            }

        }
        return false;
    }

    private float GetGreatestDistance()
    {
        var bounds = new Bounds( targets[0].position, Vector3.zero );
        for ( int i = 0; i < targets.Count; i++ )
        {
            bounds.Encapsulate( targets[i].position );
        }
        return bounds.size.x;
    }

    private Vector3 GetCenterPoint()
    {
        if ( targets.Count == 1 ) return targets[0].position;
        var bounds = new Bounds( targets[0].position, Vector3.zero );
        for ( int i = 0; i < targets.Count; i++ )
        {
            bounds.Encapsulate( targets[i].position );
        }
        return bounds.center;
    }
}