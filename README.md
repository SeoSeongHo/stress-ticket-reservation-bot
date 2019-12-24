## Ticketting Stress Bot

티켓 예약 클라이언트 대신, 많은 양의 리퀘스트를 만들어 내는 Stateful Bot 입니다.

***

### Language, Framework, Tech

- C# .net core Console App

- 내부 Queue 를 이용한 StateMachine

***

### Architecture

본 프로젝트의 구조

#### State

각 이벤트별로 BaseState 를 상속받아, 이벤트 특성에 맞게 Run(), MoveNextState() 를 구현한다.

- Run()

State 별로 실행해야할 메소드.

예 ) Ticket Reservation Event State 일 땐, 이벤트 모델에 Ticket 에 대한 정보를 담고, WAS 에 요청을 보낸다.

- MoveNextState()

다음 State 로 넘어가는 메소드. currentState 를 변경시키고, Queue 에 넣는다. (EndState 일 때 제외)

예 ) StartState 다음으로는, 60% 확률로 A Event, 40% 확률로 B Event 로 이동시킨다.

``` 
this.currentState = new Random().Next(100) < 60 ? BotStateType.A : BotStateType.B; 
queu.Enqueue(this);
```

***

#### StateMachine

C# 내부 Queue 를 이용하여, finite StateMachine 을 구현

위 BaseState 들이 들어있는 Queue 에서 데이터를 꺼내며, Stateful 한 Machine 구현 (TriggerState Method 호출)

```
while (this.queue.Count != 0)
{
  if(queue.TryDequeue(out var currentState))
  {
    currentState = currentState.TriggerState();
    currentState.MoveNextState(queue);
  }
}
```

***

#### Contants

본 프로젝트에서 사용되는 메타 정보들을 담아두는 Static Class

#### Program.cs (main func)

정해놓은 thread count 만큼 비동기 Task 를 만들어 돌리는 Func

하나의 쓰레드에는 위에서 본 StateMachine 이 State 별로 이벤트를 만들어 전송하는 형태이다.
