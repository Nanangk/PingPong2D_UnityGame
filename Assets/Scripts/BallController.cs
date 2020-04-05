using UnityEngine;
using UnityEngine.UI;

public class BallController : MonoBehaviour {
	public int force;
	Rigidbody2D rigid;
	int scoreP1;
	int scoreP2;
	Text scoreUIP1;
	Text scoreUIP2;
	GameObject selesai;
	Text txmenang;
	AudioSource audios;
	public AudioClip hitSound;
	public PaddleController pad;
	public PaddleController2 pad2;
	// Use this for initialization
	void Start () {
		scoreP1 = 0;
		scoreP2 = 0;
		rigid = GetComponent<Rigidbody2D>();
		Vector2 arah = new Vector2(2,0).normalized;
		rigid.AddForce(arah*force);
		scoreUIP1 = GameObject.Find ("score1").GetComponent<Text> ();
		scoreUIP2 = GameObject.Find ("score2").GetComponent<Text> ();
		selesai = GameObject.Find("selesai");
		selesai.SetActive(false);
		audios = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}
	void ResetBall(){
		transform.localPosition = new Vector2(0,0);
		rigid.velocity = new Vector2(0,0);
	}
	private void OnCollisionEnter2D(Collision2D other) {
		audios.PlayOneShot(hitSound);
		if(other.gameObject.name == "tp_kanan"){
			scoreP1 += 1;
			TampilkanScore();
			if(scoreP1==5){
				selesai.SetActive(true);
				txmenang = GameObject.Find("isi").GetComponent<Text>();
				txmenang.text = "Player 1 Menang!";
				Destroy(gameObject);
				return;
			}
			
			Rintangan(scoreP1,scoreP2);
			ResetBall();
			Vector2 arah = new Vector2(2,0).normalized;
			rigid.AddForce(arah*force);
		}
		if(other.gameObject.name == "tp_kiri"){
			scoreP2 += 1;
			TampilkanScore();
			if(scoreP2==5){
				selesai.SetActive(true);
				txmenang = GameObject.Find("isi").GetComponent<Text>();
				txmenang.text = "Player 2 Menang!";
				Destroy(gameObject);
				return;
			}
		
			Rintangan(scoreP1,scoreP2);
			ResetBall();
			Vector2 arah = new Vector2(-2,0).normalized;
			rigid.AddForce(arah*force);
		}
		if(other.gameObject.name == "Player1"||other.gameObject.name == "Player2"){
			float sudut = (transform.position.y - other.transform.position.y)*5f;
			Vector2 arah = new Vector2(rigid.velocity.x,sudut).normalized;
			rigid.velocity = new Vector2(0,0);
			rigid.AddForce(arah*force*2);
		}
	}
	void TampilkanScore(){
		Debug.Log("Score P1: "+scoreP1+" Score P2: "+scoreP2);
		scoreUIP1.text = scoreP1+"";
		scoreUIP2.text = scoreP2+"";
	}
	void Rintangan(int scoreP1,int scoreP2){
		if(scoreP1==2||scoreP2==2){
			force+=50;
			pad.kecepatan+=1;
			pad2.kecepatan+=1;
			Debug.Log("Force: "+force);
			Debug.Log("Padde: "+pad.kecepatan);
			Debug.Log("Padde2: "+pad2.kecepatan);
		}
		else if(scoreP1==4||scoreP2==4){
			force+=50;
			pad.kecepatan+=1;
			pad2.kecepatan+=1;
			Debug.Log("Force: "+force);
			Debug.Log("Padde: "+pad.kecepatan);
			Debug.Log("Padde2: "+pad2.kecepatan);
		}
	}
}
