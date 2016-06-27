using UnityEngine;
using System.Collections;

[RequireComponent(typeof(SphereCollider))]
public class CheckPoint : MonoBehaviour
{
    public bool isStart;
    public CheckPoint next;

	private void Start()
	{
		SetActive (isStart);
	}

    public void SetActive(bool active)
    {
        gameObject.SetActive(active);
    }

	public void GetPoint()
	{
		SetActive (false);
		if (next != null)
		{
			next.SetActive(true);
		}
	}

	void OnTriggerEnter(Collider collider)
	{
		Transform objectParent = collider.transform.parent;
		Debug.LogWarning(string.Format("objectParent.name = {0}", objectParent.name));
		if (objectParent == null)
		{
			return;
		}

		var vehicleController = objectParent.GetComponent<VehicleController>();
		Debug.LogWarning(string.Format("vehicleController == null {0}", vehicleController == null));
		if (vehicleController == null)// || !vehicleController.isLocalPlayer)
		{
			return;
		}

		Debug.LogWarning("OnTriggerEnter");


		GetPoint ();

		//        var point = collider.GetComponent<CheckPoint>();
		//        if (point == null || point == checkPoint) { return; }
		//
		//        if (checkPoint == null || checkPoint.next == point)
		//        {
		//            if (checkPoint != null) { checkPoint.next.SetActive(false); }
		//
		//            checkPoint = point;
		//            checkPoint.next.SetActive(true);
		//        }
	}

#if UNITY_EDITOR

    void OnDrawGizmosSelected()
    {
        if (next == null) { return; }

        Gizmos.color = Color.yellow;
        Gizmos.DrawLine(transform.position, next.transform.position);
    }

#endif
}
