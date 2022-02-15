﻿using UnityEngine;
using System.Collections;
using System.Collections.Generic;

public delegate void SMDelegate();

public class StateMachine {

	public Dictionary<string, State> states;
	public Dictionary<State, List<Transition>> transitions;

	private State currentState;

	public State CurrentState
	{
		get { return currentState; }
	}

	public StateMachine()
	{
		states = new Dictionary<string, State>();
		transitions = new Dictionary<State, List<Transition>>();
	}	

	public void Update () 
	{

		if (currentState!= null)
		{
			currentState.onUpdate();
		}
	}

	public void SetCurrentState( string name)
	{
		currentState = states[name];
	}
	
	public void SetCurrentState( object state)
	{
		currentState = states[state.ToString()];
	}

	public void ProcessTriggerEvent( object triggerName )
	{
		ProcessTriggerEvent( triggerName.ToString() );
		
	}

	public void ProcessTriggerEvent( string triggerName )
	{
		List<Transition> currentTransitions = transitions[currentState];

		foreach ( Transition tr in currentTransitions)
		{
			if (tr.triggerAction == triggerName)
			{
				tr.Execute();
				currentState = tr.target;
			}
		}
	}

	public void CreateState( string name, SMDelegate onUpdateDelegate)
	{
		State st = new State(name);
		st.onUpdate += onUpdateDelegate;

		states.Add(name, st);
		transitions.Add(st, new List<Transition>());
	}
	
	public void CreateState( object name, SMDelegate onUpdateDelegate)
	{
		CreateState( name.ToString(), onUpdateDelegate);
	}

	public void CreateTransition( string source, string target, string triggerEvent, SMDelegate onTransiteOut = null, SMDelegate onTransiteIn = null)
	{
		Transition tr = new Transition( states[source], states[target], triggerEvent, onTransiteOut, onTransiteIn);
		transitions[states[source]].Add( tr );
	}
	
	public void CreateTransition( object source, object target, object triggerEvent, SMDelegate onTransiteOut = null, SMDelegate onTransiteIn = null)
	{
		Transition tr = new Transition( states[source.ToString()], states[target.ToString()], triggerEvent.ToString(), onTransiteOut, onTransiteIn);
		transitions[states[source.ToString()]].Add( tr );
	}
}