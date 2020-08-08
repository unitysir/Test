using System;
using System.Collections.Generic;

public interface IEventInfo { }

public class EventInfo<T> : IEventInfo {
    public Action<T> actions;
    public EventInfo ( Action<T> action ) {
        actions += action;
    }
}
public class EventInfo : IEventInfo {
    public Action actions;
    public EventInfo ( Action action ) {
        actions += action;
    }
}

public class EventCenter : Single<EventCenter> {
    private Dictionary<string, IEventInfo> actionDic = new Dictionary<string, IEventInfo>( );

    public void AddEventListener<T> ( string name, Action<T> action ) {
        if ( actionDic.ContainsKey(name) ) {
            ( actionDic [name] as EventInfo<T> ).actions += action;
        } else {
            actionDic.Add(name, new EventInfo<T>(action));
        }
    }
    public void AddEventListener ( string name, Action action ) {
        if ( actionDic.ContainsKey(name) ) {
            ( actionDic [name] as EventInfo ).actions += action;
        } else {
            actionDic.Add(name, new EventInfo(action));
        }
    }

    public void EventTrigger<T> ( string name, T info ) {
        if ( actionDic.ContainsKey(name) )
            ( actionDic [name] as EventInfo<T> ).actions?.Invoke(info);
    }
    public void EventTrigger ( string name ) {
        if ( actionDic.ContainsKey(name) )
            ( actionDic [name] as EventInfo ).actions?.Invoke( );
    }
    public void DeleteEventListener<T> ( string name, Action<T> action ) {
        ( actionDic [name] as EventInfo<T> ).actions -= action;
    }
    public void DeleteEventListener ( string name, Action action ) {
        ( actionDic [name] as EventInfo ).actions -= action;
    }

    public void Clear ( ) {
        actionDic.Clear( );
    }
}