using UnityEngine;

public class BlueBirdPatrolState : EnemyState
{
    Enemy_BlueBird blueBird;

    public BlueBirdPatrolState(Enemy _Enemy, EnemyStateMachine _stateMachine, string _animBoolName, Enemy_BlueBird _blueBird) : base(_Enemy, _stateMachine, _animBoolName)
    {
        this.blueBird = _blueBird;
    }

    public override void Enter()
    {
        base.Enter();

        blueBird.destinationPointIndex++;

        if (blueBird.destinationPointIndex >= blueBird.patrolPoints.Length)
        {
            blueBird.destinationPointIndex = 0;
        }

        blueBird.FlyFlipCheck(blueBird.patrolPoints[blueBird.destinationPointIndex]);

        blueBird.SetVelocity(blueBird.patrolSpeed);
    }

    public override void Exit()
    {
        base.Exit();
    }

    public override void Update()
    {
        if (blueBird.playerDetect && !blueBird.isReturning)
        {
            stateMachine.ChangeState(blueBird.FollowState);
            return;
        }

        float destinationDistance = Vector2.Distance(enemy.transform.position, blueBird.patrolPoints[blueBird.destinationPointIndex].position);

        if (destinationDistance <= 0.1f)
        {
            stateMachine.ChangeState(blueBird.IdleState);
        }
    }
}
