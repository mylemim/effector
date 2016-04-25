using UnityEngine;
using System.Collections;

public class DroneMovement : MonoBehaviour
{

    public string TargetTag = "Player";
    public float Speed = 4f;

    /// <summary>
    /// Distance from other objects before the script-owning objects starts to avoid them
    /// </summary>
    private float objectAvoidanceDistance = 6f;

    /// <summary>
    /// Angle of turning when an obstructing object is detected
    /// </summary>
    private float turnSpeed = 8;

    /// <summary>
    /// We're giving a randomized turn direction (either up (1) or down (-1))
    /// </summary>
    private int preferredTurnDirection;

    private GameObject targetGameObject;
    private Rigidbody2D droneRigidbody;

    // Use this for initialization
    void Start()
    {
        preferredTurnDirection = Random.Range(1, 2) % 2 == 0 ? 1 : -1;
        targetGameObject = GameObject.FindGameObjectWithTag(TargetTag);
        droneRigidbody = gameObject.GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        if (targetGameObject != null)
            MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        Vector2 directionTowardsPlayer = targetGameObject.transform.position - transform.position;

        AttemptAvoidanceManoeuvre(directionTowardsPlayer);
        RotateTowardsPlayer(directionTowardsPlayer);

        if (directionTowardsPlayer.magnitude > objectAvoidanceDistance)
            droneRigidbody.AddForce(directionTowardsPlayer.normalized * Speed);
    }

    private void AttemptAvoidanceManoeuvre(Vector2 directionTowardsPlayer)
    {
        RaycastHit2D hit = Physics2D.Raycast(transform.position, directionTowardsPlayer.normalized, objectAvoidanceDistance, LayerMask.GetMask(new string[] { "World" }));
        if (hit.collider != null)
            //Turn harder the closer you are to the target object
            droneRigidbody.AddForce(Vector2.up * preferredTurnDirection * turnSpeed * hit.distance / objectAvoidanceDistance);
    }

    private void RotateTowardsPlayer(Vector2 directionTowardsPlayer)
    {
        Vector2 normalizedDirection = directionTowardsPlayer.normalized;
        float rotationAmount = Mathf.Atan2(normalizedDirection.y, normalizedDirection.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotationAmount - 90);
    }
}
