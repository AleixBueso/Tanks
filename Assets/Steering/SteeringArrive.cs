using UnityEngine;
using System.Collections;

public class SteeringArrive : MonoBehaviour {

	public float min_distance = 0.1f;
	public float slow_distance = 5.0f;
	public float time_to_target = 0.1f;

	Move move;

	// Use this for initialization
	void Start () { 
		move = GetComponent<Move>();
	}

	// Update is called once per frame
	void Update () 
	{
		Steer(move.target.transform.position);
	}

	public void Steer(Vector3 target)
	{
		if(!move)
			move = GetComponent<Move>();

        // TODO 3: Create a vector to calculate our ideal velocity
        // then calculate the acceleration needed to match that velocity
        // before sending it to move.AccelerateMovement() clamp it to 
        // move.max_mov_acceleration

        // v = v0 + a*t
        // a = v - v0 / t
        //v2 - v20 = 2 * a * (x - x0)
        //v2 - v20 / (2 * (x-x0) = a

        Vector3 diff = move.target.transform.position - transform.position;

        if(diff.magnitude == slow_distance)
        {
            float acceleration = (- (2 * (move.target.transform.position - transform.position)) / Mathf.Sqrt(move.movement.magnitude)).magnitude;
            move.AccelerateMovement(move.movement);
        }

        if (transform.position == move.target.transform.position)
            move.AccelerateMovement(new Vector3(0,0,0));
    }

	void OnDrawGizmosSelected() 
	{
		// Display the explosion radius when selected
		Gizmos.color = Color.white;
		Gizmos.DrawWireSphere(transform.position, min_distance);

		Gizmos.color = Color.green;
		Gizmos.DrawWireSphere(transform.position, slow_distance);
	}
}
