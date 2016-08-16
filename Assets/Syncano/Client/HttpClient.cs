using UnityEngine;
using System;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class HttpClient : SelfInstantiatingSingleton<HttpClient> {

	/// <summary>
	/// The base URL variable.
	/// </summary>
	private string baseUrl;

	public Coroutine GetAsync<T>(string id, Action<T> callback) where T : SyncanoObject<T>, new() {

		return StartCoroutine(SendGetOneRequest(id, callback));
	}

	private IEnumerator SendGetOneRequest<T>(string id, Action<T> callback) where T : SyncanoObject<T>, new() {

		string url = GetRequestOneBuilder(id, typeof(T));
	
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add(Constants.HTTP_HEADER_API_KEY, Syncano.Instance.ApiKey);
	
		WWW www = new WWW(url, new byte[]{0}, headers);

		yield return www;
		T data = SyncanoObject<T>.FromJson(www.text);
		callback(data);
	}

	private string GetRequestOneBuilder(string id, Type classType) {
		
		StringBuilder sb = new StringBuilder(Constants.PRODUCTION_SERVER_URL);
		sb.Append(string.Format(Constants.OBJECTS_DETAIL_URL, Syncano.Instance.InstanceName, classType.ToString(), id));

		return sb.ToString();
	}
}
