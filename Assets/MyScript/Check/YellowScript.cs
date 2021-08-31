using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class YellowScript : MonoBehaviour
{
	public GameObject YellowPrefab;
	public Sprite[] YellowSprites;
	private GameObject firstYellow;
	private GameObject lastYellow;
	private string currentName;
	List<GameObject> removableYellowList = new List<GameObject>();

	void Update()
	{
		if (Input.GetMouseButtonDown(0) && firstYellow == null)
		{
			OnDragStart();
		}
		else if (Input.GetMouseButtonUp(0))
		{
			//クリックを終えた時
			OnDragEnd();
		}
		else if (firstYellow != null)
		{
			OnDragging();
		}
	}

	private void OnDragStart()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);

		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;
			string ballName = hitObj.name;
			if (ballName.StartsWith("Yellow"))
			{
				firstYellow = hitObj;
				lastYellow = hitObj;
				currentName = hitObj.name;
				removableYellowList = new List<GameObject>();
				PushToList(hitObj);
			}
		}
	}

	private void OnDragging()
	{
		RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
		if (hit.collider != null)
		{
			GameObject hitObj = hit.collider.gameObject;

			if (hitObj.name == currentName && lastYellow != hitObj)
			{
				float distance = Vector2.Distance(hitObj.transform.position, lastYellow.transform.position);
				if (distance < 1.0f)
				{
					lastYellow = hitObj;
					PushToList(hitObj);
				}
			}
		}
	}

	private void OnDragEnd()
	{
		int remove_cnt = removableYellowList.Count;
		if (remove_cnt >= 2)
		{
			for (int i = 0; i < remove_cnt; i++)
			{
                Destroy(removableYellowList[i]);
            }
		}
		firstYellow = null;
		lastYellow = null;
	}

	void PushToList(GameObject obj)
	{
		removableYellowList.Add(obj);
	}
}
