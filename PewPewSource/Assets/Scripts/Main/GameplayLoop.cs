using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameplayLoop
{
	private List<BaseController> _listController;
	private int _listLength;
	private int _capacity;

	public GameplayLoop(int SizeListController = 100)
	{
		_listController = new List<BaseController>(SizeListController);
		_listLength = 0;
		_capacity = SizeListController;
	}

	public void TickFixed()
	{
		for (int i = 0; i < _listLength; ++i)
		{
			_listController[i].TickFixed();
		}
	}

	public void SubElement(BaseController Element)
	{
		if (_listController.Find(e => Element == e) == null)
		{
			if (_capacity <= _listLength)
			{
				_capacity *= 2;
				_listController.Capacity = _capacity;
			}
			++_listLength;
			_listController.Add(Element);
		}
		else
		{
			Debug.LogWarning("[GameplayLoop/SubElement]: Already sub : " + Element.name);
		}
	}

	public void RemoveElement(BaseController Element)
	{
		var index = _listController.FindIndex(e => Element == e);
		if (index != -1)
		{
			_listController.RemoveAt(index);
			--_listLength;
		}
	}
}
