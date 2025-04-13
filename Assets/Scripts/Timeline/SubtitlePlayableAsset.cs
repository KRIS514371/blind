using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class SubtitlePlayableAsset : PlayableAsset
{
    public string text;

    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var ScriptPlayable = ScriptPlayable<SubtitleBehaviour>.Create(graph);
        var subtitleBehaviour =  ScriptPlayable.GetBehaviour();
        subtitleBehaviour.text = text;
      
        return ScriptPlayable;
    }
}
