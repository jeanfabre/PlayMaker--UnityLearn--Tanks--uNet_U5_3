using System.Collections;

using UnityEngine;
using UnityEngine.Networking;

using HutongGames.PlayMaker;

public class PlayMakerUnetGameObjectProxy : NetworkBehaviour {


	[Command]
	public void CmdSendPlayMakerEvent(string eventName,Object eventData)
	{

		PlayMakerUtils.SendEventToGameObject(null,this.gameObject,eventName);

	}
}