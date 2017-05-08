using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum puzzleID
{
	rotate,
	keypad
};

/// <summary>
/// Puzzle manager.
/// </summary>
public class PuzzleManager : MonoBehaviour 
{
    /// <summary>
    /// Dictionary with puzzles.
    /// </summary>
	private Dictionary<puzzleID, PuzzleBase> puzzles;
    /// <summary>
    /// The current puzzle.
    /// </summary>
	private PuzzleBase current;
    /// <summary>
    /// Start this instance.
    /// </summary>
	private void Start()
	{
		puzzles = new Dictionary<puzzleID, PuzzleBase>();	
		addState (puzzleID.keypad, FindObjectOfType<KeypadPuzzle>());
		addState (puzzleID.rotate, FindObjectOfType<RotatePuzzle>());
	}

    /// <summary>
    /// Update this instance.
    /// </summary>
	private void Update()
	{
		if (current != null)
			current.check ();
	}

    /// <summary>
    /// Sets the current puzzle.
    /// </summary>
    /// <param name="id">Identifier.</param>
	public void setState(puzzleID id) 
	{
		if (!puzzles.ContainsKey (id))
			return;

		if (current != null)
			current.cancel ();
			
		current = puzzles[id];
		current.startPuzzle();
	}

    /// <summary>
    /// Exits the current puzzle.
    /// </summary>
	public void exitState()
	{
		if (current == null)
			return;
		current.cancel ();
		current = null;
	}

    /// <summary>
    /// Adds a puzzle.
    /// </summary>
    /// <param name="id">Identifier.</param>
    /// <param name="state">State.</param>
	public void addState(puzzleID id, PuzzleBase puzzleClass)
	{
		puzzles.Add(id, puzzleClass);
	}
}
