# State-Machine for Unity
Easy-to-use state machine

## How to use
### How to Create a new State
You will need to create a class that inherits from BaseState
```cs
 public class ExempleState: BaseState
 {
  public ExempleState();
  public override void StartState(MonoBehavior mono)
  {
    //Do something
  }
  
  public override void UpdateState()
  {
    //Do something
  }
 }
```
## How to Create a new State Machine
here I assume that it is a state machine for a player and that you have created 3 states: IdleState, WalkState and RunState as seen before 
```cs
  public class Player : MonoBehaviour
  {
    StateMachine playerStateMachine;
    
    IdleState idle;
    WalkState walk;
    RunState run;
    
    Transition toIdle;
    Transition idleToWalk;
    Transiton walkToRun;
    
    void Start()
    {
      void InitStates(); // here we will initialize our states
      void InitTransition(); // here we will initialise our transitions for this we will need a function that returns a boolean for each transition
      void InitStatesMachine(); // now that we have initialized our states and transitions we will initialize the state machine with all these 
    }
    
    void InitStates()
    {
      idle = new IdleState();
      walk = new WalkState();
      run = new RunState();
    }
    
    //you will need to create conditions to move from one state to another as follows
     bool isIdle()
    {
      return velocity == 0; // here if the velocity of the player reaches 0 the condition will be true
    }
    
    bool isWalking()
    {
      return velocity > 0 && velocity < 5; // if the velocity is between 1 and 5 the condition will be true
    }
    
    bool isRunning()
    {
      return velocity > 5; // if the velocity is greater than 5 then our character is running
    }
    /*once done you will initialize the transitions there are two constructors
    Transition(fromState, ToState, Condition) this constructor will start from a state to go to another and there is 
    Transition(ToState, Condition) which makes that state accessible from any state */
    
    void InitTransition()
    {
      toIdle = new Transition(idle, isIdle); // I want the idle state to be accessible from any state so I don't put an origin state but only the destination
      idleToWalk = new Transition(idle, walk, isWalking); // now I want to be able to go from idle to walk
      walkToRun = new Transition(walk, run, isRunning); //I want to go from walking to running
    }
    
    void InitStatesMachine()
    {
      playerStateMachine = new StateMachine(idle, this) // idle will be our starting state and this refers to our MonoBehaviour to be able to access it in our states to be able to modify variables that are there
      
      //we will add our previously initialized states to our state machine
      playerStateMachine.AddState(idle);
      playerStateMachine.AddState(walk);
      playerStateMachine.AddState(run);
      
      //we will add our previously initialized transitions to our state machine
      playerStateMachine.AddTransition(toIdle);
      playerStateMachine.AddTransition(idleToWalk);
      playerStateMachine.AddTransition(walkToRun);
      
      playerStateMachine.Start();
    }
    
    void Update()
    {
      playerStateMachine.Update(); // this will execute the code done in the active state update
    }
   }
```

in the example there are few transitions to show how it works but in a real use case you would need for example a transition to go from running to walking as well as from walking to idle
