using UnityEngine;

public class PaddleController2 : MonoBehaviour {
	public float kecepatan;
  	public string axis;
	public float batasAtas;
	public float batasBawah;
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		float gerak = Input.GetAxis(axis) * kecepatan * Time.deltaTime;
		float nextpos = transform.position.y + gerak;
		if(nextpos>batasAtas){
			gerak = 0;
		}
		if(nextpos<batasBawah){
			gerak = 0;
		}
		transform.Translate(gerak,0,0);
	}
}
