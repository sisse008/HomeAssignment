using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    [SerializeField] List<Robot> robots;
    [SerializeField] InstructionBuilder instructionBuilder;


    private void OnEnable()
    {
        Robot.OnRobotSelected += instructionBuilder.ExecuteInstructionOnRobot;
    }

    private void OnDisable()
    {
        Robot.OnRobotSelected -= instructionBuilder.ExecuteInstructionOnRobot;
    }

}
