using Microsoft.Unity.VisualStudio.Editor;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.UIElements;

public class SpriteStretch : MonoBehaviour
{
	public bool KeepAspectRatio;

	void Start()
	{
		var topRightCorner = Camera.main.ScreenToWorldPoint(new Vector3(Screen.width, Screen.height, Camera.main.transform.position.z));
		var worldSpaceWidth = topRightCorner.x * 2;
		var worldSpaceHeight = topRightCorner.y * 2;

		var spriteSize = gameObject.GetComponent<SpriteRenderer>().bounds.size;

		var scaleFactorX = worldSpaceWidth / spriteSize.x;
		var scaleFactorY = worldSpaceHeight / spriteSize.y;

		if (KeepAspectRatio)
		{
			if (scaleFactorX > scaleFactorY)
			{
				scaleFactorY = scaleFactorX;
			}
			else
			{
				scaleFactorX = scaleFactorY;
			}
		}
		gameObject.transform.localScale = new Vector3(scaleFactorX, scaleFactorY, 1);
	}
}