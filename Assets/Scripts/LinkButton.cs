using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LinkButton : MonoBehaviour
{
    public static void GoToSite(string url)
    {
        System.Diagnostics.Process.Start(url);
    }
}
