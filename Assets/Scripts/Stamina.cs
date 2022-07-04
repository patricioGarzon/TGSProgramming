using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stamina : MonoBehaviour
{
	internal float f_stamina = 6;
	internal float f_maxStamina = 20;
	internal bool b_isRunning;
	PlatyerMovement pl_player;

	internal Rect gui_staminaRect;
	internal Texture2D txr_staminaTexture;

	// Use this for initialization
	void Start()
	{
		pl_player = GetComponent<PlatyerMovement>();
		gui_staminaRect = new Rect(Screen.width / 10, Screen.height * 9 / 10, Screen.width / 3,
							   Screen.height / 50);
		txr_staminaTexture = new Texture2D(1, 1);
		txr_staminaTexture.SetPixel(0, 0, Color.white);
		txr_staminaTexture.Apply();
	}

	// Update is called once per frame
	void Update()
	{
		//Track playing input for running
		if (Input.GetKey(KeyCode.LeftShift))
		{
			SetRunning(true);
		
		}
		if (Input.GetKeyUp(KeyCode.LeftShift))
		{
			SetRunning(false);
		}

		//handle stamina reduction
		if (b_isRunning)
		{
			f_stamina -= Time.deltaTime;
			if (f_stamina < 0)
			{
				f_stamina = 0;
				SetRunning(false);
			}
		}
		else if (f_stamina < f_maxStamina)
		{
			f_stamina += Time.deltaTime;
		}
	}
	public void SetRunning(bool isRunning)
	{
		//increase player speed when running
		this.b_isRunning = isRunning;
		if (isRunning)
		{
			pl_player.currentSpeed = pl_player.f_Speed * 2;
		}
		else if (!isRunning)
		{
			pl_player.currentSpeed = pl_player.f_Speed;
		}
		pl_player.anim.SetBool("isRunning", b_isRunning);
	}
	void OnGUI()
	{
		float ratio = f_stamina / f_maxStamina;
		float rectWidth = ratio * Screen.width / 5;
		gui_staminaRect.width = rectWidth;
		GUI.DrawTexture(gui_staminaRect, txr_staminaTexture);
	}
}

