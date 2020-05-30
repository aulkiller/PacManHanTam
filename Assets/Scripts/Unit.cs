using UnityEngine;
using System.Collections;
using System.Collections.Specialized;

public class Unit : MonoBehaviour
{

	public Transform target;
	public float speed;
	[SerializeField] private float RotationSpeed;

	Vector2[] path;
	int targetIndex;

	//private void Update()
	//{
	//	if (!gameObject.activeSelf) StopAllCoroutines();
	//}

	public IEnumerator RefreshPath()
	{
		//if (gameObject.activeSelf)
		//{
			Vector2 targetPositionOld = (Vector2)target.position + Vector2.up; // ensure != to target.position initially

			while (true)
			{
				if (targetPositionOld != (Vector2)target.position)
				{
					targetPositionOld = (Vector2)target.position;

					path = Pathfinding.RequestPath(transform.position, target.position);
					StopCoroutine("FollowPath");
					StartCoroutine("FollowPath");
				}

				yield return new WaitForSeconds(.25f);
			}
		//}
		//else StopAllCoroutines();
	}

	public IEnumerator FollowPath()
	{
		//if (gameObject.activeSelf)
		//{

			if (path.Length > 0)
			{
				targetIndex = 0;
				Vector2 currentWaypoint = path[0];

				while (true)
				{

					if ((Vector2)transform.position == currentWaypoint)
					{
						targetIndex++;
						if (targetIndex >= path.Length)
						{
							targetIndex = 0;
							path = new Vector2[0];
							yield break;
						}
						currentWaypoint = path[targetIndex];

					}
					transform.position = Vector2.MoveTowards(transform.position, currentWaypoint, this.speed * Time.deltaTime);
					yield return null;

				}
			}
		//}
		//else StopAllCoroutines();
	}

	public void OnDrawGizmos()
	{
		if (path != null)
		{
			for (int i = targetIndex; i < path.Length; i++)
			{
				Gizmos.color = Color.black;
				//Gizmos.DrawCube((Vector3)path[i], Vector3.one *.5f);

				if (i == targetIndex)
				{
					Gizmos.DrawLine(transform.position, path[i]);
				}
				else
				{
					Gizmos.DrawLine(path[i - 1], path[i]);
				}
			}
		}
	}
	private void OnCollisionEnter2D(Collision2D collision)
	{
		if(collision.gameObject.CompareTag("Player"))
		{
			GameStatus gameStatus = FindObjectOfType<GameStatus>();
			gameStatus.Health();
			gameStatus.Stop();

		}
	}
}