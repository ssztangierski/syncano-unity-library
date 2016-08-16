using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public class Test : MonoBehaviour {

	IEnumerator Start()
	{
		Syncano s = Syncano.Instance;
		s.Init("7aa2f6396632efd9e93c02cf6aaec401f77a481b", "unity-quiz-app");

		//yield return s.Please().Get<Questions>(16, res);

		yield return s.Please().Get<Response<Questions>>(16, res);



		//yield return StartCoroutine (s.CallScriptEndpoint ("d019a1036c7ec1348713de2770385b728f050ed1","get_questions", res));
	}



	private void res (Response<Questions> res)
	{
		Debug.Log(res.Data.answers[0]);
		//Debug.Log(res.answers.Length);


	}

}
