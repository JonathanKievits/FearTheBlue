using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum puzzleID
{
	rotate,
	keypad
};

public class PuzzleManager : MonoBehaviour 
{
	private Dictionary<puzzleID, PuzzleBase> puzzles;
	private PuzzleBase current;

	private void Start()
	{
		puzzles = new Dictionary<puzzleID, PuzzleBase>();	
		addState (puzzleID.rotate, FindObjectOfType<RotatePuzzle>());
		setState (puzzleID.rotate);
	}

	private void Update()
	{
		if (current != null)
			current.check ();
	}

	public void setState(puzzleID id) 
	{
		if (!puzzles.ContainsKey (id))
			return;

		if (current != null)
			current.cancel ();
			
		current = puzzles[id];
		current.startPuzzle();
	}

	public void exitState()
	{
		current.cancel ();
		current = null;
	}

	public void addState(puzzleID id, PuzzleBase state)
	{
		puzzles.Add(id, state);
	}
}
