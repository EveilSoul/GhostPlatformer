using UnityEngine;

/// Этот класс двигает заданный Transform при помощи метода Translate.
public class RotateState : State
{
    /// Transform, задается в Inspector'е.
    [SerializeField]
    Transform transformToRotate;

    public ConditionTransition Transition;

    public float RotationSpeed;
    public int Angle;
    private int currentAngle;

    private void Start()
    {
        if (transformToRotate == null)
            transformToRotate = transform;
        currentAngle = Angle;
    }

    private void Update()
    {
        var rot = Quaternion.Euler(0, currentAngle, 0);
        transformToRotate.rotation = Quaternion.Lerp(transformToRotate.rotation, rot, RotationSpeed * Time.deltaTime);
        if (Quaternion.Angle(transformToRotate.rotation, rot)<=1)
        {
            Transition.IsCondition = true;
            currentAngle = (currentAngle + Angle) % 360;
        }
    }

}
