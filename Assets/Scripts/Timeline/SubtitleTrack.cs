using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Timeline;

[TrackBindingType(typeof(SubtitleManager))]
[TrackClipType(typeof(SubtitlePlayableAsset))]
public class SubtitleTrack : PlayableTrack
{
}
