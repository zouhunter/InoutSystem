﻿using System;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using System.Collections;
using System.Collections.Generic;
/// <summary>
/// 3维元素打开
/// </summary>
public class ElementOpen : MonoBehaviour {
    public List<ElementAction> elementActions;
	public void OpenTargetElement(string elementName)
	{
		var action = elementActions.Find (x => x.elementName == elementName);
		if (action != null) {
            action.action.Invoke();
		}
	}
}