using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using GFrame;


public class FSMDemo : MonoBehaviour
{
    PlayerFSM s;
    private void Start()
    {
        s = new PlayerFSM();
        s.init();
    }

    private void Update()
    {
        s.Update();
    }
}

public class PlayerFSM
{

    FSMStateMachine<Player> playerFSMMachine;
    public void init()
    {
        Player player = new Player();
        playerFSMMachine = new FSMStateMachine<Player>(player);
        PlayState_IDLE state_Idle = new PlayState_IDLE();
        PlayState_WALK state_walk = new PlayState_WALK();
        PlayState_JUMP state_jump = new PlayState_JUMP();
        playerFSMMachine.SetCurrentState(state_Idle);
        playerFSMMachine.SetCurrentState(state_walk);
        playerFSMMachine.SetCurrentState(state_jump);
    }

    public void Update()
    {
        playerFSMMachine.UpdateState(Time.deltaTime);
    }
}





public class Player
{

}


public class PlayState : FSMState<Player>
{
    public override void Execute(Player entity, float dt)
    {
        Log.i(entity.ToString() + ":" + this.GetType().Name + "-->" + "Execute");
    }
}


public class PlayState_IDLE : PlayState
{


}

public class PlayState_WALK : PlayState
{

}

public class PlayState_JUMP : PlayState
{

}




