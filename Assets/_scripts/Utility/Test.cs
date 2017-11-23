namespace TowerDefense{
	using UnityEngine;

	public class Test : MonoBehaviour {

		public GameObject bombLaser;
		public GameObject bombSmall;
		public GameObject bombBig;

		public GameObject slowLaser;
		public GameObject slowSmall;
		public GameObject slowBig;

		private GameObject manager;
		private WaveStats waveStats;

		private GameObject raiseMenu;
		private GameObject lowerMenu;
		private HeightAdjust raise;
		private HeightAdjust lower;

		public bool visualFx;
		public bool waveStart;
		[Tooltip("up arrow/down arrow")]
		public bool height;

		void Start(){
			if (waveStart == true) {
				manager = GameObject.Find ("LevelManager");
				waveStats = manager.GetComponent<WaveStats> ();
			}
			if(height==true){
				raiseMenu = GameObject.Find ("raise");
				lowerMenu = GameObject.Find ("lower");
				raise = raiseMenu.GetComponent<HeightAdjust> ();
				lower = lowerMenu.GetComponent<HeightAdjust> ();
			}
		}

		void Update () {
			if(height==true){
				if (Input.GetKeyDown (KeyCode.UpArrow)) {
					raise.Raise ();
				}
				if (Input.GetKeyDown (KeyCode.DownArrow)) {
					lower.Lower ();
				}
			}


			if (visualFx == true) {
				if (Input.GetKeyDown (KeyCode.Q)) {
					ObjectPool.Instantiate (bombLaser, transform.position, transform.rotation);
				}

				if (Input.GetKeyDown (KeyCode.W)) {
					ObjectPool.Instantiate (bombSmall, transform.position, transform.rotation);
				}

				if (Input.GetKeyDown (KeyCode.E)) {
					ObjectPool.Instantiate (bombBig, transform.position, transform.rotation);
				}

				if (Input.GetKeyDown (KeyCode.Z)) {
					ObjectPool.Instantiate (slowLaser, transform.position, transform.rotation);
				}

				if (Input.GetKeyDown (KeyCode.X)) {
					ObjectPool.Instantiate (slowSmall, transform.position, transform.rotation);
				}

				if (Input.GetKeyDown (KeyCode.C)) {
					ObjectPool.Instantiate (slowBig, transform.position, transform.rotation);
				}
			}

			if(waveStart==true){
				if(Input.GetKeyDown(KeyCode.Backspace)){
					if (waveStats.gameStarted == false) 
					{
						waveStats.gameStarted = true;
					} else 
					{
						waveStats.NextWave ();
					}
				}
			}
		}
	}
}