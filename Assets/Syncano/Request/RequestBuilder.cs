using UnityEngine;
using System;
using System.Collections;

public class RequestBuilder {
	
	private Syncano syncano;

	public RequestBuilder() {
		this.syncano = Syncano.Instance;
	}

	public Coroutine Get<Response>(int id, Action<Response> callback) {
		return Send(id, callback); 
	}

	private Coroutine Send<Response>(int id, Action<Response> callback) {
		return HttpClient.Instance.GetAsync(id, callback);
	}


}