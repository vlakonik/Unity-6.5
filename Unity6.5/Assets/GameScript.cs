using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using System.Threading;
using Random = System.Random;

public class GameScript : MonoBehaviour
{
    public GameObject MainCanvas;
    public GameObject PauseCanvas;
    public GameObject StartGameButton;
    public GameObject EndGamePanel;
    public GameObject PauseButton;
    public Text Timer;
    public Text FirstPin;
    public Text SecondPin;
    public Text ThirdPin;
    public Text ResultGameText;
    public Text StartGameButtonText;

    int firstPin;
    int secondPin;
    int thirdPin;
    float timer;
    bool gameIsProceed;

    void Start() // ������� ����������� ����������
    {
        firstPin = 0;
        secondPin = 0;
        thirdPin = 0;
        timer = 0f;
        Timer.text = "60 ������";
        gameIsProceed = false;
        PauseButton.SetActive(false);
        StartGameButton.SetActive(true);
        MainCanvas.SetActive(true);
        PauseCanvas.SetActive(false);
        EndGamePanel.SetActive(false);
    }
    void Update()
    {
        GameStart();
        GameWin();
        GameDefeat();
    }
    private void GameStart() // ����� ��� ������� ��� ������ ����
    {
        if (gameIsProceed == true)
        {
            timer -= Time.deltaTime;
            Timer.text = timer.ToString("# ������");
            if (StartGameButtonText.text != "������ ������")
            {
                StartGameButtonText.text = "������ ������";
            }
            PauseButton.SetActive(true);
        }
    }
    private void GameDefeat() // ����� ��� ���������
    {
        if (timer < 0)
        {
            gameIsProceed = false;
            EndGamePanel.SetActive(true);
            ResultGameText.text = "�� ���������!";
            timer = 0f;
        }
    }
    private void GameWin() // ����� ��� ������
    {
        if (firstPin == secondPin && firstPin == thirdPin && gameIsProceed == true) // ������� ������
        {
            gameIsProceed = false;
            EndGamePanel.SetActive(true);
            ResultGameText.text = "�� ��������!";
            timer = 0f;
        }
    }
    public void Pause() // �����
    {
        if (gameIsProceed)
        {
            gameIsProceed = false;
            MainCanvas.SetActive(false);
            PauseCanvas.SetActive(true);
        }
        else if (!gameIsProceed)
        {
            Thread.Sleep(1000);
            gameIsProceed = true;
            MainCanvas.SetActive(true);
            PauseCanvas.SetActive(false);
        }
    }
    public void DrillButton() // ����� ��� �����
    {
        if (firstPin != 10)
        {
            firstPin++;
        }
        if (secondPin != 0)
        {
            secondPin--;
        }
        WritingMethod();
    }
    public void HammerButton() // ����� ��� �������
    {
        if (firstPin != 0)
        {
            firstPin--;
        }
        if (secondPin < 9)
        {
            secondPin += 2;
        }
        if (thirdPin != 0)
        {
            thirdPin--;
        }
        WritingMethod();
    }
    public void PicklockButton() // ����� ��� �������
    {
        if (firstPin != 0)
        {
            firstPin--;
        }
        if (secondPin != 10)
        {
            secondPin++;
        }
        if (thirdPin != 10)
        {
            thirdPin++;
        }
        WritingMethod();
    }
    public void GameCycleMethod() // ����� ���������� ������ ��� ����� ���� "������" � "������ ����"
    {
        EndGamePanel.SetActive(false);

        Random random = new Random();
        firstPin = random.Next(0,11);
        secondPin = random.Next(0, 11);
        thirdPin = random.Next(0, 11);

        timer = 60f;
        WritingMethod();

        gameIsProceed = true;
    }
    private void WritingMethod() // ������ ������ � ��������� ����
    {
        FirstPin.text = firstPin.ToString();
        SecondPin.text = secondPin.ToString();
        ThirdPin.text = thirdPin.ToString();
    }
}