using System;
using UnityEngine;

/// <summary>
/// Класс представление монетки в игровом мире
/// </summary>
public class CoinView : ActorView
{
    public event Action<PlayerView> Contact;

    private void OnTriggerEnter2D(Collider2D col)
    {
        var player = col.GetComponent<PlayerView>();
        if (player != null)
            Contact?.Invoke(player);
    }
}