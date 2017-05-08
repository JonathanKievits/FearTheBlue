using UnityEngine;

/// <summary>
/// Puzzle base.
/// </summary>
public abstract class PuzzleBase : MonoBehaviour
{
    /// <summary>
    /// Reference to the PuzzleManager
    /// </summary>
	protected PuzzleManager manager;
    /// <summary>
    /// Start this instance.
    /// </summary>
	protected virtual void Start(){manager = this.GetComponent<PuzzleManager> ();}
    /// <summary>
    /// Starts the puzzle.
    /// </summary>
	public virtual void startPuzzle(){}
    /// <summary>
    /// Called when the puzzle is solved.
    /// </summary>
	protected abstract void onSolve();
    /// <summary>
    /// Check if the puzzle has been solved.
    /// </summary>
	public abstract void check();
    /// <summary>
    /// Cancel the puzzle.
    /// </summary>
	public virtual void cancel(){}
}
