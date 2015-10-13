using UnityEngine;
using System.Collections;
using System;
using UnityEngine.UI;
using com.shephertz.app42.paas.sdk.csharp;
using com.shephertz.app42.paas.sdk.csharp.app42Event;
using System.Collections.Generic;

public class MA : MonoBehaviour, App42CallBack {

	EventService eventService = null;

	public Text ResponseText;

	// Use this for initialization
	void Start () {
		App42API.Initialize ("API_KEY","SECRET_KEY");
		App42API.EnableEventService (true);
		eventService = App42API.BuildEventService ();
	}

	/// <summary>
	/// Tracks the event.
	/// </summary>
	/// <param name="IF">I.</param>
	public void TrackEvent (InputField IF) {
		String eventName = IF.text;
		Dictionary<String,object> props = new Dictionary<string, object> ();
		props.Add ("Level","First");
		props.Add ("Difficulty","Normal");
		eventService.TrackEvent (eventName, props, this);
	}

	public void OnSuccess (object response)
	{
		print ("Success : " + response.ToString());
		ResponseText.color = Color.green;
		ResponseText.text = "Success.";
	}

	public void OnException (Exception ex)
	{
		print ("Exception : " + ex.ToString());
		ResponseText.color = Color.red;
		ResponseText.text = "Error.";
	}
}
