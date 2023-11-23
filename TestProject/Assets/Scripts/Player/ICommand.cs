using UnityEngine;

public interface ICommand
{
    void Execute(Transform cubeTransform, float horizontalInput, float verticalInput);
}