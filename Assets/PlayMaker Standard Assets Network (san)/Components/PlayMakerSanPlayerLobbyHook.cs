// (c) Copyright HutongGames, LLC 2010-2016. All rights reserved.

using UnityEngine;
using System.Collections;
using UnityEngine.Networking;

public class PlayMakerSanPlayerLobbyHook : UnityStandardAssets.Network.LobbyHook  {

	public override void OnLobbyServerSceneLoadedForPlayer(NetworkManager manager, GameObject lobbyPlayer, GameObject gamePlayer)
	{
		Debug.Log("PlayMakerSanPlayerLobbyHook OnLobbyServerSceneLoadedForPlayer lobbyPlayer:"+lobbyPlayer+" gamePlayer:"+gamePlayer);

		if (lobbyPlayer == null)
			return;

		UnityStandardAssets.Network.LobbyPlayer lp = lobbyPlayer.GetComponent<UnityStandardAssets.Network.LobbyPlayer>();

		if(lp != null)
		{
			// let's jsut pass the lobbyPlayer, we can then propose the whole set of properties
			PlayMakerSanGameManager.AddPlayer(gamePlayer,lp); // lp.slot, lp.playerColor, lp.nameInput.text, lp.playerControllerId);
		}
	}
}