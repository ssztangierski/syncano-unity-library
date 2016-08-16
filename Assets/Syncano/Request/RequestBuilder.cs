using UnityEngine;
using System;
using System.Collections;

public class RequestBuilder {
	
	private Syncano syncano;

	public RequestBuilder() {
		this.syncano = Syncano.Instance;
	}

	public Coroutine Get<T>(string id, Action<T> callback) where T : SyncanoObject<T>, new() {
		return Send(id, callback);
	}

	private Coroutine Send<T>(string id, Action<T> callback) where T : SyncanoObject<T>, new() {
		return HttpClient.Instance.GetAsync<T>(id, callback);
	}





}
