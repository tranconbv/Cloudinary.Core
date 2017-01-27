// Decompiled with JetBrains decompiler
// Type: CloudinaryDotNet.Actions.Face
// Assembly: CloudinaryDotNet, Version=1.0.30.0, Culture=neutral, PublicKeyToken=c8234dc617ae7841
// MVID: 85795B22-FB3A-4216-BE8E-309002E93AB1
// Assembly location: C:\Users\Joel.TRANCON\AppData\Local\Temp\Mudimuk\dbdb731dac\lib\net40\CloudinaryDotNet.dll

using System.Collections.Generic;
using System.Runtime.Serialization;

namespace CloudinaryDotNet.Actions
{
  [DataContract]
  public class Face
  {
    [DataMember(Name = "boundingbox")]
    public BoundingBox BoundingBox { get; protected set; }

    [DataMember(Name = "confidence")]
    public double Confidence { get; protected set; }

    [DataMember(Name = "age")]
    public double Age { get; protected set; }

    [DataMember(Name = "smile")]
    public double Smile { get; protected set; }

    [DataMember(Name = "glasses")]
    public double Glasses { get; protected set; }

    [DataMember(Name = "sunglasses")]
    public double Sunglasses { get; protected set; }

    [DataMember(Name = "beard")]
    public double Beard { get; protected set; }

    [DataMember(Name = "mustache")]
    public double Mustache { get; protected set; }

    [DataMember(Name = "eye_closed")]
    public double EyeClosed { get; protected set; }

    [DataMember(Name = "mouth_open_wide")]
    public double MouthOpenWide { get; protected set; }

    [DataMember(Name = "beauty")]
    public double Beauty { get; protected set; }

    [DataMember(Name = "sex")]
    public double Gender { get; protected set; }

    [DataMember(Name = "race")]
    public Dictionary<string, double> Race { get; protected set; }

    [DataMember(Name = "emotion")]
    public Dictionary<string, double> Emotion { get; protected set; }

    [DataMember(Name = "quality")]
    public Dictionary<string, double> Quality { get; protected set; }

    [DataMember(Name = "pose")]
    public Dictionary<string, double> Pose { get; protected set; }

    [DataMember(Name = "eye_left")]
    public Point EyeLeftPosition { get; protected set; }

    [DataMember(Name = "eye_right")]
    public Point EyeRightPosition { get; protected set; }

    [DataMember(Name = "e_ll")]
    public Point EyeLeft_Left { get; protected set; }

    [DataMember(Name = "e_lr")]
    public Point EyeLeft_Right { get; protected set; }

    [DataMember(Name = "e_lu")]
    public Point EyeLeft_Up { get; protected set; }

    [DataMember(Name = "e_ld")]
    public Point EyeLeft_Down { get; protected set; }

    [DataMember(Name = "e_rl")]
    public Point EyeRight_Left { get; protected set; }

    [DataMember(Name = "e_rr")]
    public Point EyeRight_Right { get; protected set; }

    [DataMember(Name = "e_ru")]
    public Point EyeRight_Up { get; protected set; }

    [DataMember(Name = "e_rd")]
    public Point EyeRight_Down { get; protected set; }

    [DataMember(Name = "nose")]
    public Point NosePosition { get; protected set; }

    [DataMember(Name = "n_l")]
    public Point NoseLeft { get; protected set; }

    [DataMember(Name = "n_r")]
    public Point NoseRight { get; protected set; }

    [DataMember(Name = "mouth_l")]
    public Point MouthLeft { get; protected set; }

    [DataMember(Name = "mouth_r")]
    public Point MouthRight { get; protected set; }

    [DataMember(Name = "m_u")]
    public Point MouthUp { get; protected set; }

    [DataMember(Name = "m_d")]
    public Point MouthDown { get; protected set; }
  }
}
