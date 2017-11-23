namespace TowerDefense{
	using UnityEngine;
	using UnityEngine.UI;

	public class Gem : MonoBehaviour {

		private GameObject levelManagerObject;
		private TDLevelManager levelManager;
		private MobStats mobStats;
		private WaveStats waveStats;
		private GameObject gemCanvas;
		public Image healthBarImage;
		public GameObject gemSphere;
		public GameObject winFX;
		public float maxHealth = 20;
		public float rotateSpeed;
		[HideInInspector]
		public float currentHealth;

		public void GemStart () 
		{
			levelManagerObject = GameObject.Find ("LevelManager");
			levelManager = levelManagerObject.GetComponent<TDLevelManager> ();
			mobStats = levelManagerObject.GetComponent<MobStats> ();
			waveStats = levelManagerObject.GetComponent<WaveStats> ();
			currentHealth = maxHealth;
			gemCanvas = GetComponentInChildren <Canvas>().gameObject;
			gemCanvas.SetActive (true);
		}

		void Update(){
			gemSphere.transform.Rotate (Vector3.right, rotateSpeed * Time.deltaTime);

		}

		void OnTriggerEnter(Collider coll){
			if(coll.tag=="Ground Mob" || coll.tag=="Air Mob" || coll.tag == "Basic Mob"){
				var mob = coll.GetComponentInParent<MobHealth> ();
				//Destroy (mob.healthBar);
				Destroy (mob.gameObject);
				if (mobStats.mobsCurrentlyActive > 0 && mob.hasDeathBeenCounted==false) {
					mob.hasDeathBeenCounted = true;
					mobStats.mobsCurrentlyActive--;
				}
				Hit ();
			}	
		}

		public void Hit(){
			waveStats.flawless = false;
			//if health is 1 or more then lower it
			if (currentHealth >= 1.0f) 
			{
				currentHealth -= 1.0f;
				healthBarImage.fillAmount = currentHealth / maxHealth;
			} 
			//if health is less that one gem is destroyed
			else {
				Destroy (gameObject);
				levelManager.GemDestroyed();
			}
		}
		public void Hit(int value){
			waveStats.flawless = false;
			//if health is 1 or more then lower it
			if (currentHealth >= value) {
				currentHealth -= value;
				healthBarImage.fillAmount = currentHealth / maxHealth;
			} 
			//if health is less that one gem is destroyed
			else {
				Destroy (gameObject);
				levelManager.GemDestroyed();
			}
		}

		public void Win(){
			InvokeRepeating ("Fireworks", 0.0f, 2.0f);
		}

		void Fireworks(){
			if (winFX) {
				var rand = new Vector3 (Random.Range (-5, 5), Random.Range (5, 30), Random.Range (-5, 5));
				var up = transform.position + rand;
				GameObject partyfavor = (GameObject)Instantiate (winFX, up, transform.rotation);
				Destroy (partyfavor, 5.0f);
			}
		}

	}
}