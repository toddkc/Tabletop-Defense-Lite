namespace TowerDefense{
	using UnityEngine;

	public class MapWaves : MonoBehaviour {
		

		public virtual void StopSpawning(){}

		public virtual void CountdownOne(){}
		public virtual void CountdownTwo(){}
		public virtual void CountdownThree(){}
		public virtual void CountdownFour(){}
		public virtual void CountdownFive(){}
		public virtual void CountdownSix(){}
		public virtual void CountdownSeven(){}
		public virtual void CountdownEight(){}
		public virtual void CountdownNine(){}
		public virtual void CountdownTen(){}

		public virtual void WaveOne(){}
		public virtual void WaveTwo(){}
		public virtual void WaveThree(){}
		public virtual void WaveFour(){}
		public virtual void WaveFive(){}
		public virtual void WaveSix(){}
		public virtual void WaveSeven(){}
		public virtual void WaveEight(){}
		public virtual void WaveNine(){}
		public virtual void WaveTen(){}
		public virtual void WinMap(){}
		public virtual void EndlessWave(int wave, int mobs){}
	}
}