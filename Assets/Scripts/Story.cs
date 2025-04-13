using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Timeline;

[Serializable]
public class Story 
{
   public string name;
   public TimelineAsset timelineAsset; 
   public UnityEvent storyEvent;
}
