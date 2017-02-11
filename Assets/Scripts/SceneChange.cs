using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class SceneChange : MonoBehaviour {

	public static int estadoBuild;

	void Awake()
	{
//		if (!SceneManager.GetSceneByBuildIndex (estadoBuild + 1).isLoaded) 
//		{
//			SceneManager.LoadScene( estadoBuild + 1, LoadSceneMode.Additive);
//		}
//		print ("Ha cargado la proxima escena.");
	}

	void OnTriggerEnter(Collider other)
	{
		if (other.tag == "Player") 
		{
			if (this.tag == "Fail") //Misión fallida 
			{ 
				SceneManager.LoadScene (SceneManager.GetActiveScene().buildIndex);		
			} 
			else {	SceneLoadingPreferences ();	} //Nivel completado			
		}
	}


	 public void SceneLoadingPreferences()
	{
		Debug.Log ("Hemos dado a que cargue xdxd");

		estadoBuild++;

		SceneManager.SetActiveScene (SceneManager.GetSceneByBuildIndex(estadoBuild));
		SceneManager.UnloadSceneAsync (SceneManager.GetSceneByBuildIndex(estadoBuild - 1));

			return;

	}



}
