using UnityEngine;
using System.Collections;

public class EventsConfig
{
    //states
    public const string OnGameStateChangedEvent = "event.game.state.changed";
	public const string OnGameOverEvent = "event.game.end";

    //game logic
    public const string OnPlatformSpawnEvent = "event.platform.spawn";
    public const string OnCollectMagicSphereEvent = "event.collect.magic.sphere";

    //music
    public const string OnNextSong = "event.song.next";
	public const string OnStopSong = "event.song.stop";

    //ui
	public const string OnPlayerDistanceChanedEvent = "event.player.disctance.changed";
    public const string OnFpsChangedEvent = "event.debug.fps";
}
