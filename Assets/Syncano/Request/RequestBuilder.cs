using UnityEngine;
using System;
using System.Collections;

public class RequestBuilder {
	
	private Syncano syncano;

	public RequestBuilder() {
		this.syncano = Syncano.Instance;
	}

	public Coroutine Get<T>(long id, Action<Response<T>> onSuccess, Action<Response<T>> onFailure = null)  where T :SyncanoObject<T>, new() {
		return Send<T>(id, onSuccess, onFailure); 
	}

	public Coroutine Get<T>(Action<Response<T>> onSuccess, Action<Response<T>> onFailure = null) where T :SyncanoObject<T>, new() {
		return HttpClient.Instance.PostAsync<T>(default(T), onSuccess, onFailure, UnityEngine.Networking.UnityWebRequest.kHttpVerbGET);
	}

	public Coroutine Save<T>(T obj, Action<Response<T>> callback) where T :SyncanoObject<T>, new()  {
		return HttpClient.Instance.PostAsync<T>(obj, callback);
	}

	public Coroutine Delete<T>(T obj, Action<Response<T>> onSuccess, Action<Response<T>> onFailure = null) where T :SyncanoObject<T>, new()  {
		return HttpClient.Instance.PostAsync<T>(obj, onSuccess, onFailure, UnityEngine.Networking.UnityWebRequest.kHttpVerbDELETE);
	}

	private Coroutine Send<T>(long id, Action<Response<T>> onSuccess, Action<Response<T>> onFailure = null)  where T :SyncanoObject<T> ,new(){
		return HttpClient.Instance.GetAsync<T>(id, onSuccess, onFailure);
	}



}