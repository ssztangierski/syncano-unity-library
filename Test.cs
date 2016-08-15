using UnityEngine;
using System.Collections;

public class Test : MonoBehaviour {

	IEnumerator Start()
	{
		Syncano s = Syncano.Instance;
		s.Init("7aa2f6396632efd9e93c02cf6aaec401f77a481b", "unity-quiz-app");

		yield return StartCoroutine (s.CallScriptEndpoint ("d019a1036c7ec1348713de2770385b728f050ed1","get_questions", res));
	}



	private void res (Response res)
	{

		Debug.Log(res.webError);


	}

}
