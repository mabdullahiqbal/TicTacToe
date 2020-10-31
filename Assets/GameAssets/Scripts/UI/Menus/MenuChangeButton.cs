using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuChangeButton : MonoBehaviour
{
    [SerializeField]
    private MenuName ChangeTo_;
    public MenuName ChangeTo { get { return ChangeTo_; } }
}
