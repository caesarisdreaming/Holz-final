using System.Collections;
using UnityEngine;

public class DragNShoot : MonoBehaviour
{
    public float power = 10f;
    public Rigidbody2D rb;

    public Vector2 minPower;
    public Vector2 maxPower;

    TrajectoryLine Tl;

    Vector2 force;
    Vector3 startPoint;
    Vector3 endPoint;

    Camera cam;

    private void Start()
    {
        cam = Camera.main;
        Tl = GetComponent<TrajectoryLine>();

        Time.timeScale = 1f;//I added this line
    }
    
    private void Update()
    {
        if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);
            Vector3 currentPoint = cam.ScreenToWorldPoint(touch.position);
            currentPoint.z = 10f;
            Tl.RenderLine(startPoint, currentPoint);
            switch (touch.phase)
            {
                case TouchPhase.Began:
                    startPoint = cam.ScreenToWorldPoint(touch.position);
                    startPoint.z = 10f;
                    break;
                case TouchPhase.Ended:
                    endPoint = cam.ScreenToWorldPoint(touch.position);
                    endPoint.z = 10f;

                    force = new Vector2(Mathf.Clamp(startPoint.x - endPoint.x, minPower.x, maxPower.x), Mathf.Clamp(startPoint.y - endPoint.y, minPower.y, maxPower.y));
                    rb.velocity = new Vector2(0, 0); //I added this line
                    rb.AddForce(force * power, ForceMode2D.Impulse);
                    Tl.EndLine();
                    break;
            }

            //Vector3 touchPosition = cam.ScreenToWorldPoint(touch.position);
            //touchPosition.z = 10f;
            //transform.position = touchPosition;
        }
    }
}
