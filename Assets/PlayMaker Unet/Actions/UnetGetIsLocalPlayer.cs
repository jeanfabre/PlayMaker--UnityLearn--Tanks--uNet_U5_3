// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.

using System;
using UnityEngine;

using UnityEngine.Networking;

namespace HutongGames.PlayMaker.Actions
{
	[ActionCategory("Unity Networking")]
	[Tooltip("Get The Networked GameObject is Local Player property")]
	public class UnetGetIsLocalPlayer : FsmStateAction
	{
		[RequiredField]
		[CheckForComponent(typeof(NetworkBehaviour))]
		public FsmOwnerDefault gameObject;

		public FsmEvent IsLocalPlayerEvent;

		public FsmEvent IsNotLocalPlayerEvent;

		[UIHint(UIHint.Variable)]
		public FsmBool isLocalPlayer;


		public override void Reset()
		{
			gameObject = null;
			IsLocalPlayerEvent = null;
			IsNotLocalPlayerEvent = null;
			isLocalPlayer = null;

		}

		public override void OnEnter()
		{
			CheckIfLocalPlayer();


			Finish();

		}

		void CheckIfLocalPlayer()
		{
			GameObject go = Fsm.GetOwnerDefaultTarget(gameObject);

			NetworkBehaviour _nb = go.GetComponent<NetworkBehaviour>();

			if (_nb==null)
			{
				return;
			}


			isLocalPlayer.Value = _nb.isLocalPlayer;

			if (_nb.isLocalPlayer)
			{
				Fsm.Event(IsLocalPlayerEvent);
			}else{
				Fsm.Event(IsNotLocalPlayerEvent);
			}

		}
	}
}

