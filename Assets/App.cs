using UnityEngine;
using System.Collections;

public class App : MonoBehaviour {

	public GameObject ball;

	// Use this for initialization
	void Start () {

		float y = 5f;

		Vector3[] posArray = {
			new Vector3 (0f, y, -5f),
			new Vector3 (0f, y, 0f),
			new Vector3 (Mathf.Sin(Mathf.PI/180*30), y, Mathf.Cos(Mathf.PI/180*30)),
			new Vector3 (-Mathf.Sin(Mathf.PI/180*30), y, Mathf.Cos(Mathf.PI/180*30)),
			new Vector3 (Mathf.Sin(Mathf.PI/180*30)*2, y, Mathf.Cos(Mathf.PI/180*30)*2),
			new Vector3 (0, y, Mathf.Cos(Mathf.PI/180*30)*2),
			new Vector3 (-Mathf.Sin(Mathf.PI/180*30)*2, y, Mathf.Cos(Mathf.PI/180*30)*2),
			new Vector3 (Mathf.Sin(Mathf.PI/180*30), y, Mathf.Cos(Mathf.PI/180*30)*3),
			new Vector3 (-Mathf.Sin(Mathf.PI/180*30), y, Mathf.Cos(Mathf.PI/180*30)*3),
			new Vector3 (0, y, Mathf.Cos(Mathf.PI/180*30)*4)
		};

		Color32[] colorArray = {
			new Color32(255, 255, 255, 255),
			new Color32(225, 180, 1, 255),
			new Color32(4, 55, 138, 255),
			new Color32(251, 21, 21, 255),
			new Color32(102, 80, 165, 255),
			new Color32(253, 227, 70, 255),
			new Color32(255, 95, 0, 255),
			new Color32(54, 132, 110, 255),
			new Color32(160, 13, 41, 255),
			new Color32(31, 31, 31, 255)
		};

		// Make Balls
		for (int i=0; i < posArray.Length; ++i) {
			GameObject b = (GameObject)Instantiate (ball, posArray[i], Quaternion.identity);
			if(i==0){
				b.name = "MyBall";
			}else{
				b.name = "Ball"+i;
			}
			b.renderer.material.color = colorArray[i];
		}

	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetMouseButtonDown (0)) {
			Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
			RaycastHit hit;

			if(Physics.Raycast(ray, out hit)){
				if(hit.collider.gameObject.name=="MyBall"){

					Vector3 force = ray.direction;
					force.y = 0;
					force.Normalize();
					force *= 60f;

					print ("force:" + force);
					hit.rigidbody.AddForce(force, ForceMode.VelocityChange);

				}
			}
		}

	}
}
