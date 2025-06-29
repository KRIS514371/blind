using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Playables;

[System.Serializable]
public class SubtitlePlayableAsset : PlayableAsset
{
    public string text;
    public string textEN;
    const string Line_TEMPLATE = "<b>{0}</b><br><size=60%>{1}";
    // Factory method that generates a playable based on this asset
    public override Playable CreatePlayable(PlayableGraph graph, GameObject go)
    {
        var ScriptPlayable = ScriptPlayable<SubtitleBehaviour>.Create(graph);
        var subtitleBehaviour =  ScriptPlayable.GetBehaviour();
        subtitleBehaviour.text = string.Format(Line_TEMPLATE, textEN, text);
      
        return ScriptPlayable;
    }
}
