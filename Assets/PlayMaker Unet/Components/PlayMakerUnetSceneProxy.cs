using UnityEngine;
using UnityEngine.Networking;

using System.Collections;

using HutongGames.PlayMaker;

public class PlayMakerUnetSceneProxy : NetworkBehaviour {


	public override void OnStartServer()
	{
		// disable client stuff
		PlayMakerFSM.BroadcastEvent("UNET / ON START SERVER");
	}

	public override void OnStartClient()
	{
		// register client events, enable effects
		PlayMakerFSM.BroadcastEvent("UNET / ON START CLIENT");
	}

	public override void OnStartAuthority ()
	{
		base.OnStartAuthority ();
	}

	public override void OnNetworkDestroy ()
	{
		base.OnNetworkDestroy ();
	}

}
