using UnityEngine;
using System;
using System.Reflection;
using System.Text;
using System.Collections;
using System.Collections.Generic;

public class HttpClient : SelfInstantiatingSingleton<HttpClient> {

	/// <summary>
	/// The base URL variable.
	/// </summary>
	private string baseUrl;

	public Coroutine GetAsync<Response>(int id, Action<Response> onSuccess, Action<Response> onFailure = null) {

		return StartCoroutine(SendGetOneRequest(id, onSuccess, onFailure));
	}

	private IEnumerator SendGetOneRequest<Response>(int id, Action<Response> onSuccess, Action<Response> onFailure = null) {
		
		Type responseType = typeof(Response);
		Type genericResponseType = responseType.GetGenericArguments()[0];

		string url = GetRequestOneBuilder(id, genericResponseType);
	
		Dictionary<string, string> headers = new Dictionary<string, string>();
		headers.Add(Constants.HTTP_HEADER_API_KEY, Syncano.Instance.ApiKey);
	
		WWW www = new WWW(url, new byte[]{0}, headers);
		yield return www;
		Debug.Log(www.text);
		Response response = (Response)Activator.CreateInstance(responseType);

		MethodInfo methodInfo = responseType.GetMethod("CreateData", BindingFlags.NonPublic | BindingFlags.Instance);
		methodInfo.Invoke(response, new object[] { www.text });

		onSuccess(response);

		if (string.IsNullOrEmpty (www.error) == false)
		{
			if (onFailure != null)
			{
				onFailure(response);
			}
		}

		else
		{
			if (onSuccess != null)
			{
				onSuccess(response);
			}
		}
	}

	private string GetRequestOneBuilder(int id, Type classType) {
		
		StringBuilder sb = new StringBuilder(Constants.PRODUCTION_SERVER_URL);
		sb.Append(string.Format(Constants.OBJECTS_DETAIL_URL, Syncano.Instance.InstanceName, classType.ToString(), id.ToString()));

		return sb.ToString();
	}
}
