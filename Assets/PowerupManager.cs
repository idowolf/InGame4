using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupName{
    SPEED,
    LANE,
    SHIELD
}
public class PowerupManager : MonoBehaviour {
    public YAxisMovement yAxisController;
    public EnemyPath xSpeedController;
    public float xSpeedMultiplier = 1.5f, ySpeedMultiplier = 1.5f;

    private bool[] powerupsActive;
    private float[] elapsedTimes;
    private float[] durations;
    private float initXSpeed, initYSpeed;
    private bool spaceshipInvincible;
	// Use this for initialization
	void Start () {
        initXSpeed = xSpeedController.speed;
        initYSpeed = yAxisController.speed;
        powerupsActive = new bool[3];
        elapsedTimes = new float[powerupsActive.Length];
        durations = new float[powerupsActive.Length];
    }

    // Update is called once per frame
    void Update () {
        for (int i = 0; i < powerupsActive.Length; i++)
        {
            if (powerupsActive[i])
            {
                elapsedTimes[i] += Time.deltaTime;
                if(elapsedTimes[i] > durations[i])
                {
                    DeactivatePowerup(i);
                }
            }
        }
	}

    public void ActivatePowerup(PowerupName powerUp, float duration)
    {
        if (!powerupsActive[(int)powerUp])
        {
            powerupsActive[(int)powerUp] = true;
            switch(powerUp)
            {
                case PowerupName.SPEED:
                    ActivateSpeedPowerup();
                    break;
                case PowerupName.LANE:
                    ActivateLanePowerup();
                    break;
                case PowerupName.SHIELD:
                    ActivateShieldPowerup();
                    break;
            }
        }
            
        durations[(int)powerUp] += duration;
    }

    public void DeactivatePowerup(int i)
    {
        elapsedTimes[i] = 0;
        durations[i] = 0;
        powerupsActive[i] = false;
        switch ((PowerupName)i)
        {
            case PowerupName.SPEED:
                DeactivateSpeedPowerup();
                break;
            case PowerupName.LANE:
                DeactivateLanePowerup();
                break;
            case PowerupName.SHIELD:
                DeactivateShieldPowerup();
                break;
        }
    }
    private void ActivateSpeedPowerup()
    {
        xSpeedController.speed *= xSpeedMultiplier;
    }
    private void DeactivateSpeedPowerup()
    {
        xSpeedController.speed = initXSpeed;
    }
    private void ActivateLanePowerup()
    {
        yAxisController.speed *= ySpeedMultiplier;
    }
    private void DeactivateLanePowerup()
    {
        yAxisController.speed = initYSpeed;
    }
    private void ActivateShieldPowerup()
    {
        spaceshipInvincible = true;
    }
    private void DeactivateShieldPowerup()
    {
        spaceshipInvincible = false;
    }
    public void DestroySpaceshipIfPossible()
    {
        if (!spaceshipInvincible)
        {
            Destroy(gameObject);
        }
    }
}
