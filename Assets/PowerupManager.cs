using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum PowerupName
{
    SPEED,
    LANE,
    SHIELD,
    MAGNET
}
public class PowerupManager : MonoBehaviour
{
    public GameObject ShieldEffect;
    public YAxisMovement yAxisController;
    public SizeController xSpeedController;
    public GameObject Magnet;
    public float xSpeedMultiplier = 1.5f, ySpeedMultiplier = 1.5f, storeDuration = 10f;

    private bool[] powerupsActive;
    private float[] elapsedTimes;
    private float[] durations;
    private float initXSpeed, initYSpeed;
    private bool spaceshipInvincible;
    // Use this for initialization
    void Start()
    {
        initXSpeed = xSpeedController.speedMultiplier;
        initYSpeed = yAxisController.speed;
        powerupsActive = new bool[System.Enum.GetNames(typeof(PowerupName)).Length];
        elapsedTimes = new float[powerupsActive.Length];
        durations = new float[powerupsActive.Length];
        HandleStore();
    }

    private void HandleStore()
    {
        for (int i = 0; i < StoreManager.ItemsSold.Length; i++)
        {
            if (StoreManager.ItemsSold[i])
            {
                ActivatePowerup((PowerupName)i, storeDuration);
                StoreManager.ItemsSold[i] = false;
            }
        }
    }
    // Update is called once per frame
    void Update()
    {
        for (int i = 0; i < powerupsActive.Length; i++)
        {
            if (powerupsActive[i])
            {
                elapsedTimes[i] += Time.deltaTime;
                if (elapsedTimes[i] > durations[i])
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
            switch (powerUp)
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
                case PowerupName.MAGNET:
                    ActivateMagnetPowerup();
                    break;
            }
        }

        durations[(int)powerUp] += duration;
    }
    public bool IsPowerupActive(PowerupName powerup)
    {
        return powerupsActive[(int)powerup];
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
            case PowerupName.MAGNET:
                DeactivateMagnetPowerup();
                break;
        }
    }
    private void ActivateMagnetPowerup()
    {
        Magnet.SetActive(true);
    }
    private void DeactivateMagnetPowerup()
    {
        Magnet.SetActive(false);
    }
    private void ActivateSpeedPowerup()
    {
        xSpeedController.speedMultiplier *= xSpeedMultiplier;
        ParticleSystem.MainModule em = GameObject.Find("par1").GetComponent<ParticleSystem>().main;
        em.startSpeedMultiplier = 5;
    }
    private void DeactivateSpeedPowerup()
    {
        xSpeedController.speedMultiplier = initXSpeed;
        ParticleSystem.MainModule em = GameObject.Find("par1").GetComponent<ParticleSystem>().main;
        em.startSpeedMultiplier = 1;
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
        ShieldEffect.SetActive(true);
        spaceshipInvincible = true;
    }
    private void DeactivateShieldPowerup()
    {
        ShieldEffect.SetActive(false);
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
