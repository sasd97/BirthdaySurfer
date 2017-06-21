using UnityEngine;
using System.Collections;

public class EventsConfig
{
    //states
    public const string OnGameStateChangedEvent = "event.game.state.changed";
	public const string OnGameOverEvent = "event.game.end";
    public const string OnUserResetTag = "event.user.reset.tag";

    //game logic
    public const string OnPlatformSpawnEvent = "event.platform.spawn";
    public const string OnIncreaseScoreEvent = "event.collect.increase.score";

    //music
    public const string OnNextSong = "event.song.next";
	public const string OnStopSong = "event.song.stop";

    //ui
	public const string OnPlayerDistanceChanedEvent = "event.player.disctance.changed";
    public const string OnFpsChangedEvent = "event.debug.fps";
}
