using UnityEngine;
using System;
using System.Collections;

public class RequestBuilder {
	
	private Syncano syncano;

	public RequestBuilder() {
		this.syncano = Syncano.Instance;
	}

	public Coroutine Get<Response>(int id, Action<Response> onSuccess, Action<Response> onFailure = null) {
		return Send(id, onSuccess, onFailure); 
	}

	private Coroutine Send<Response>(int id, Action<Response> onSuccess, Action<Response> onFailure = null) {
		return HttpClient.Instance.GetAsync(id, onSuccess, onFailure);
	}



}