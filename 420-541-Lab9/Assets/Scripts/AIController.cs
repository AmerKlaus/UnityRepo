using UnityEngine;
using UnityEngine.AI;

public class AIController : MonoBehaviour
{
    public StateMachine StateMachine { get; private set; }
    public NavMeshAgent Agent { get; private set; }
    public Animator Animator { get; private set; } // Not needed since we're not using animations
    public Transform[] Waypoints;
    public Transform Player;
    public float SightRange = 10f;
    public float AttackRange = 2f; // New attack range variable
    public LayerMask PlayerLayer;
    public StateType currentState;
    void Start()
    {
        Agent = GetComponent<NavMeshAgent>();
        Animator = GetComponent<Animator>(); // Commented out since we're not using animations

        StateMachine = new StateMachine();
        StateMachine.AddState(new IdleState(this));
        StateMachine.AddState(new PatrolState(this));
        StateMachine.AddState(new ChaseState(this));
        StateMachine.AddState(new AttackState(this)); // Add the new AttackState

        StateMachine.TransitionToState(StateType.Idle);
    }

    void Update()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);

        if (distanceToPlayer < AttackRange)
            ChangeState(StateType.Attack);
        else if (distanceToPlayer < SightRange)
            ChangeState(StateType.Chase);
        else if (currentState == StateType.Chase)
            ChangeState(StateType.Patrol);

        StateMachine.Update();
        Animator.SetFloat("CharacterSpeed", Agent.velocity.magnitude);
        currentState = StateMachine.GetCurrentStateType();
    }

    public bool CanSeePlayer()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        if (distanceToPlayer <= SightRange)
        {
            // Optionally, add line of sight checks here using Raycast
            return true;
        }
        return false;
    }

    // New method to check if the AI is within attack range
    public bool IsPlayerInAttackRange()
    {
        float distanceToPlayer = Vector3.Distance(transform.position, Player.position);
        return distanceToPlayer <= AttackRange;
    }

    // Method to handle state transitions
    private void ChangeState(StateType newStateType)
    {
        if (currentState != newStateType)
        {
            StateMachine.TransitionToState(newStateType);
            currentState = newStateType;
        }
    }
}
