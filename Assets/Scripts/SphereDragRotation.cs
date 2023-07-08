using UnityEngine;

public class SphereDragRotation : Draggable
{
    public void ResetSphereRotation()
    {
       transform.eulerAngles = Vector3.zero;
    }

    protected override void Do(Vector3 deltaMousePosition) => Rotate(deltaMousePosition);

    private void Rotate(Vector3 deltaMousePosition)
    {
        // Convert the mouse movement into rotation angles
        float rotationSpeed = 0.3f;
        float rotationX = deltaMousePosition.y * rotationSpeed;
        float rotationY = -deltaMousePosition.x * rotationSpeed;

        // Rotate the sphere around its local axes based on the mouse movement
        transform.Rotate(Vector3.up, rotationY, Space.Self);
        transform.Rotate(Vector3.right, rotationX, Space.Self);
    }
}
