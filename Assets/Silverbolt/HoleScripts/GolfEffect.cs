using System.Collections;
using UnityEngine;

public class GolfEffect : MonoBehaviour
{
    [SerializeField] private string playerName = default;
    private GameObject player;
    private Rigidbody2D playerRB;
    [SerializeField] private float golfEffectRadius = 1f;
    [SerializeField] private float forceMultiplier = 1f;
    void Start()
    {
        player = GameObject.Find(playerName);
        playerRB = player.GetComponent<Rigidbody2D>();
    }
    void Update()
    {
        float distance = Vector2.Distance(this.transform.position, player.transform.position);
        if(distance < golfEffectRadius)
        {
            //Vector3 direction = transform.position - player.transform.position;
            //playerRB.AddForce(direction * forceMultiplier * 1/distance);
            Vector3 direction = transform.position - player.transform.position;
            
            float angleinBetween = Vector2.Angle((Vector2)playerRB.velocity, (Vector2)direction);
            float directionMultiplier = angleinBetween > 90 ? 1f+ ((angleinBetween-90)/90): 1; //scale from 1 to 2 so pull ball harder when it's going away
            playerRB.AddForce(direction * forceMultiplier * 1/distance * directionMultiplier);
        }
    }
    private void OnDrawGizmos()
    {
        Gizmos.color = Color.red;
        Gizmos.DrawWireSphere(transform.position, golfEffectRadius);
    }
}
