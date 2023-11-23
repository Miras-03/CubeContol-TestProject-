using UnityEngine;

public class MoveGreenCommand : ICommand
{
    public void Execute(Transform cubeTransform, float horizontalInput, float verticalInput)
    {
        Vector3 offset = new Vector3(horizontalInput, 0, verticalInput);
        cubeTransform.position += offset;
    }
}