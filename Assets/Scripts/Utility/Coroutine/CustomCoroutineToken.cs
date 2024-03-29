﻿[System.Serializable]
public readonly struct CustomCoroutineToken
{
    public int Index { get; }
    public bool Start { get; }
    public bool Pause{ get; }
    public bool Stop{ get; }
    public bool SyncOrAsync{ get; }

    public CustomCoroutineToken(int index, bool start, bool pause, bool stop, bool syncOrAsync)
    {
        Index = index;
        Start = start;
        Pause = pause;
        Stop = stop;
        SyncOrAsync = syncOrAsync;
    }
    public CustomCoroutineToken OnStart() => new CustomCoroutineToken(Index, true, false, false, SyncOrAsync);

    public CustomCoroutineToken OnPause() => new CustomCoroutineToken(Index, true, true, false, SyncOrAsync);

    public CustomCoroutineToken OnStop() => new CustomCoroutineToken(Index, false, false, true, SyncOrAsync);
    public CustomCoroutineToken OnAsync() => new CustomCoroutineToken(Index, true, false, false, false);
    public CustomCoroutineToken OnSync() => new CustomCoroutineToken(Index, true, false, false, true);

    public bool KeepWaiting(bool isNull) => !Pause && !Stop && (isNull || SyncOrAsync);
}
