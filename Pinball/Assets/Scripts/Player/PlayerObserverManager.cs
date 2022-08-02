using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public static class PlayerObserverManager
{
  public static Action<int> OnCoinsChanged;
  public static Action<int> OnCristalChanged;
  public static void CoinsChanged(int value)
  {
    OnCoinsChanged?.Invoke(value);
  }
  public static void CristalChanged(int value)
  {
    OnCristalChanged?.Invoke(value);
  }

}
