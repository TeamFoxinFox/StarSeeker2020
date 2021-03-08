using UnityEngine;
namespace GameScene
{
  public abstract class Status : MonoBehaviour
  {
    protected readonly Player Player;
    private float? timeLeft;

    protected Status(float duration, Player player)
    {
      timeLeft = duration;
      Player = player;
    }

    protected abstract void Awake();
    protected abstract void OnDestroy();
    
    protected void Update()
    {
      if (timeLeft != null)
      {
        timeLeft = Mathf.Max((float)timeLeft - Time.deltaTime, 0f);
      }

      if (timeLeft == 0)
      {
        Player.DestroyStatus(this);
      }
    }
  }

  public class PowerUpStatus : Status
  {
    private const int Factor = 5;
    private const float Duration = 5.0f;

    public PowerUpStatus(Player player) : base(Duration, player)
    {
      
    }

    protected override void Awake()
    {
      Player.Power += Factor;
    }

    protected override void OnDestroy()
    {
      Player.Power -= Factor;
    }
  }
}