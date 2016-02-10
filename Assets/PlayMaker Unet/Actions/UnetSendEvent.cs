// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.

using System;
using UnityEngine;

using UnityEngine.Networking;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Unity Networking")]
	[Tooltip("Send a PlayMaker Event over the Network")]
	public class UnetSendEvent : FsmStateAction
	{
		
		[RequiredField]
		[CheckForComponent(typeof(PlayMakerUnetGameObjectProxy))]
		public FsmOwnerDefault gameObject;

		// ONLY ACCEPTS BROADCAST OR SELF
		public FsmEventTarget eventTarget;

		public FsmEvent eventToSend;

		public override void Reset()
		{
			gameObject = null;
			eventTarget = null;
			eventToSend = null;

		}

		public override void OnEnter()
		{
			SendNetworkedEvent();


			Finish();

		}

		void SendNetworkedEvent()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);

			PlayMakerUnetGameObjectProxy _proxy = go.GetComponent<PlayMakerUnetGameObjectProxy>();

			if (_proxy==null)
			{
				return;
			}

			_proxy.CmdSendPlayMakerEvent(eventToSend.Name,null);

		}
	}
}

