using System.Collections;
using System.Collections.Generic;
using UnityEngine;

using AssetsPattern;

public class GameCamera : MonoBehaviour
{
	public ControllerSet ListEntityToWatch;
	public float OffsetY;


	private Transform _transCam;

	public void Awake()
	{
		_transCam = transform;
	}

	public void Reset()
	{
		OffsetY = 4;
	}

	public void UpdatePosCam()
	{
		//NONE
	}

	public void UpdateFollowingCam()
	{
		float Center = 0f;
		if (ListEntityToWatch != null && ListEntityToWatch.Items.Count > 0)
		{

			for (int i = ListEntityToWatch.Items.Count - 1; i >= 0; --i)
			{
				if (ListEntityToWatch.Items[i] != null)
					Center += ListEntityToWatch.Items[i].PawnPosition.y;
			}
			Center /= ListEntityToWatch.Items.Count;
			//Center = Mathf.Clamp(Center, -OffsetY, OffsetY);
		}

		_transCam.position = new Vector3(_transCam.position.x, Center, _transCam.position.z);
	}
}
