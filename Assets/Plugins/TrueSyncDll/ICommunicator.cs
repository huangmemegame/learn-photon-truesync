using System;

// 通信器 接口
public interface ICommunicator
{
    // 往返时间 / 延迟
	int RoundTripTime();

    // 调用事件
	void OpRaiseEvent(byte eventCode, object message, bool reliable, int[] toPlayers);

    // 监听事件
	void AddEventListener(OnEventReceived onEventReceived);
}
