using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class GameVariables : MonoBehaviour
{

    public bool gamePlaying;
    public bool gamePaused;

    public GameObject timer;
    private CountdownTimer countdownTimer;
    public GameObject silverPan;
    public GameObject copperPan;
    public GameObject panSpawn;
    public GameObject batterGO;
    public GameObject batterSpawn;
    public GameObject infoWindow;
    public GameObject pauseOptions;
    public GameObject pauseBar;
    public GameObject startButton;
    public GameObject soundMgr;
    private SoundManagement soundManagement;

    public int beltSpeed = 5;
    private int spawnSpeed = 1;
    private int actions;

    public TextMeshProUGUI scoreText;
    public int score;

    void Start()
    {
        soundManagement = soundMgr.GetComponent<SoundManagement>();
        countdownTimer = timer.GetComponent<CountdownTimer>();
        gamePlaying = false;
    }


    void SpawnSilverPan()
    {
        Instantiate(silverPan, panSpawn.transform.position, panSpawn.transform.rotation);
    }
    void SpawnCopperPan()
    {
        Instantiate(copperPan, panSpawn.transform.position, panSpawn.transform.rotation);
    }

    void ChoosePanType()
    {
        actions = Random.Range(0, 2);
        if (actions == 0)
        {
            SpawnSilverPan();
        }
        if (actions == 1)
        {
            SpawnCopperPan();
        }
    }

    public void DropBatter()
    {
        Instantiate(batterGO, batterSpawn.transform.position, batterSpawn.transform.rotation);
    }

    public void DestroyObj(GameObject obj)
    {
        Destroy(obj);
    }

    public void PauseGame()
    {
        gamePaused = true;
        infoWindow.SetActive(true);
        pauseBar.SetActive(false);
        Time.timeScale = 0;
    }

    public void UnpauseGame()
    {
        infoWindow.SetActive(false);
        pauseBar.SetActive(true);
        gamePaused = false;
        Time.timeScale = 1;
    }

    public void StartGame()
    {
        DeletePans();
        score = 0;
        scoreText.SetText(score.ToString());
        pauseBar.SetActive(true);
        Time.timeScale = 1;
        countdownTimer.currentTime = countdownTimer.startingTime;
        gamePlaying = true;
        gamePaused = false;
        infoWindow.SetActive(false);
        startButton.SetActive(false);
        pauseOptions.SetActive(true);
        spawnSpeed = 1;
        beltSpeed = 5;
        InvokeRepeating("ChoosePanType", 1, spawnSpeed);
    }

    public void DeletePans()
    {
        GameObject[] silverPans;
        GameObject[] copperPans;
        silverPans = GameObject.FindGameObjectsWithTag("Silver");
        copperPans = GameObject.FindGameObjectsWithTag("Copper");

        foreach(GameObject pan in copperPans)
        {
            DestroyObj(pan);
        }        
        
        foreach(GameObject pan in silverPans)
        {
            DestroyObj(pan);
        }
    }

    public void EndGame()
    {
        pauseBar.SetActive(false);
        CancelInvoke();
        Time.timeScale = 0;
        gamePlaying = false;
        infoWindow.SetActive(true);
        startButton.SetActive(true);
        pauseOptions.SetActive(false);
    }

    public void IncreaseScore(int num)
    {
        score += num;
        scoreText.SetText(score.ToString());
        soundManagement.PlaySound("correct");
    }

    public void IncorrectPan()
    {
        soundManagement.PlaySound("incorrect");
    }    
    
    public void BatterHit()
    {
        soundManagement.PlaySound("batterHit");
    }

    public void IncreaseSpeed()
    {
        beltSpeed += 1;
        spawnSpeed += 2;
    }
}
