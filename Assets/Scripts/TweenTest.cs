using System;
using GoTween;
using UnityEngine;

public class TweenTest : MonoBehaviour
{
    private Material _material;

    private void Awake()
    {
        _material = GetComponent<Renderer>().material;
    }

    private void Start()
    {
        TweenSequence seq = new TweenSequence();
        seq.Append(transform.MoveBy(new Vector3(5f, 0f, 0f), 5f));
        seq.Join(_material.ColorTo(Color.magenta, 2f));
        seq.Join(transform.RotateTo(new Vector3(0f, 90f, 0f), 5f));
        seq.Append(transform.MoveBy(new Vector3(-5f, 5f, 0f), 5f));
        seq.Join(_material.ColorTo(Color.red, 2f));
        seq.Join(transform.RotateTo(new Vector3(90f, 0f, 0f), 5f));
        seq.Play();
    }
}
