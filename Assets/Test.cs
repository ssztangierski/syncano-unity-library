using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using Syncano;
using Syncano.Data;
using System;

public class Test : MonoBehaviour {

	IEnumerator Start()
	{
		//SyncanoClient s = SyncanoClient.Instance.Init("adfee89ec99b7022de16383185b299c29459e1fa", "syncano-io");
		SyncanoClient s = SyncanoClient.Instance.Init("adfee89ec99b7022de16383185b299c29459e1fa", "unity-quiz-app");

		//s.Please().Get<Question>(null);

		//yield return s.Please().Get<Question>(onSuccessList, onFailureList);
		//yield return s.Please().Get<Question>(300, onSuccess, onFailure);

		/*
		Channel c = new Channel ("test123");
		c.custom_publish = true;
		c.description = "desc";

		yield return s.Please().CreateChannel(c, OnChanelCreated, OnChanelFailed);
		*/

		//ChannelConnection channelConnection = new ChannelConnection(this, onNotification, onError);
		//channelConnection.Start(this, "syncano-io-channel");

		/*

		*/

		Dictionary<string, string> payload= new Dictionary<string, string>();
		payload.Add("nickname", "test124");
		payload.Add("room", "238");

		//yield return s.Please().CallScriptEndpoint("2c86dc4e1820400e1e0cd1c3e2da34a5d6ee3e06", "join_room", onSuccessCreatePlayer, payload);

		yield return null;
	}

	private void onSuccessList(ResponseGetList<Question> res)
	{
		Debug.Log("*** onSuccessList ***");
		Debug.Log(res.Objects.Count);
		Debug.Log(res.Objects[0].answers[0]);
		Debug.Log("*** onSuccessList ***");
	}

	private void onFailureList (ResponseGetList<Question> res)
	{
		if(res.IsSyncanoError)
			Debug.Log(res.syncanoError);
		else
			Debug.Log(res.webError);
	}

	private void onNotification(Response<Notification> response) { Debug.Log("received " + response.Data.payload); }

	private void onError(Response<Notification> response) { Debug.Log("received " + response.ToString()); }

	private void onSuccessCreatePlayer(ScriptEndpoint res)
	{
		Debug.Log(res.IsSuccess);
		Debug.Log(res.result.stdout);
	}

	private void onSuccessScriptEndpoint (ScriptEndpoint res) {

		Question q = JsonUtility.FromJson<Question>(res.result.stdout);// Question.FromJson(res.result.stdout);
	
		Debug.Log(" q to moderate id= " + q.id + " ;length" + q.answers.Length);
	}


	/*

	private void resList (GetResponseList<Questions> res)
	{
		//Debug.Log(res.Data.Count);
	}
	*/

	private void OnChanelCreated(Response<Channel> response)
	{
		Debug.Log(response.Data.name + " asd");
	}

	private void OnChanelFailed(Response<Channel> response)
	{
		Debug.Log(response.syncanoError);
		Debug.Log(response.webError);
	}

	private void onSuccess (Response<Question> res)
	{
		Debug.Log("*** onSuccess ***");
		Debug.Log(res.Data.text);
		Debug.Log("*** onSuccess ***");
	}

	private void onFailure (Response<Question> res)
	{
		if(res.IsSyncanoError)
			Debug.Log(res.syncanoError);
		else
			Debug.Log(res.webError);
			
	}


	#region dataobjects
	// CREATE NEW OBJECT
	/*
		Question q = new Question();
		q.text = "new text";
		q.answers = new string[] {"a", "b", "c", "d"};
		Syncano.Instance.Please().Save(q, onSuccess, onFailure);
		*/

	// MODIFY TEXT

	/*
		Question q = new Question();
		q.id = 221;
		q.text = "modified text";
		q.isModerated = true;

		q.answers = new string[] {"d", "e", "f", "g"};
		Syncano.Instance.Please().Save(q, onSuccess);
		*/

	// DELETE OBJECT
	/*
		Question q = new Question();
		q.id = 232;
		Syncano.Instance.Please().Delete(q, onSuccess);
		*/

	// GET ONE QUESTION
	//yield return s.Please().Get<Question>(235, onSuccess, onFailure);

	//yield return s.Please().GetList<Question>(null, null);


	//yield return s.Please().CallScriptEndpoint("6349c3ec1208c0be5ade53b154427d4eb5cb1628", "get_question_to_moderate", onSuccessScriptEndpoint);
	#endregion 



}
