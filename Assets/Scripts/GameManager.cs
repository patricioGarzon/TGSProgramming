using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public PlatyerMovement ply_playerObject;
    public UIManager ui_Manager;
    private bool gamePaused = false;
    // Start is called before the first frame update
    void Start()
    {
        Time.timeScale = 1;
    }

    // Update is called once per frame
    void Update()
    {
        
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (!gamePaused)
            {
                PauseGame();
            }
            else
            {
                ResumeGame();
            }
        }
        
    }
   public void PauseGame() {
        ply_playerObject.GetComponent<PlatyerMovement>().pausedGame = true;
        Time.timeScale = 0;
        gamePaused = true;
        ui_Manager.isGamePaused(gamePaused);

    }
    public void ResumeGame()
    {
        ply_playerObject.GetComponent<PlatyerMovement>().pausedGame = false;
        Time.timeScale = 1;
        gamePaused = false;
        ui_Manager.isGamePaused(gamePaused);
    }
}
