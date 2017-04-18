using UnityEngine;

public abstract class PuzzleBase : MonoBehaviour
{
	protected PuzzleManager manager;
	protected void Start()
	{
		manager = this.GetComponent<PuzzleManager> ();
	}
	public virtual void startPuzzle(){}
	protected abstract void onSolve();
	public abstract void check();
	public virtual void cancel(){}
}
