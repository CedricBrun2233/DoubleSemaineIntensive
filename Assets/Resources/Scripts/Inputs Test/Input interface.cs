using UnityEngine;
using System.Collections;
using UnityEngine.EventSystems;


public interface IYButtonHandler : IEventSystemHandler
{
	void OnYButton (BaseEventData eventData);
}


