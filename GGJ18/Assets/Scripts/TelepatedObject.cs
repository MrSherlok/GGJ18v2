using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class TelepatedObject : MonoBehaviour {
    public bool isOnTelepatingMode;
    public float moveSpeed;
    public bool isMoveable;
    public bool isRotateble;
    public bool isUseable;
    public abstract void Move();
    public abstract void Rotate();
    public abstract void Use();
    public abstract void StartTransmission();
    public abstract void StopTransmission();
    public abstract IEnumerator OnTransmissionLogic();
}
