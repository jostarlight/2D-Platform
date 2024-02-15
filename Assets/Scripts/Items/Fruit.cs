using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(Collider2D))]

public class Fruit : MonoBehaviour
{

    public string animationName;

    public FruitType fruitType;

    private Animator animator;

    public bool collected = false;

    private void Awake()
    {
        animator = GetComponent<Animator>();
    }
    // Start is called before the first frame update
    void Start()
    {
        animator.SetBool(animationName, true);
    }



    void OnTriggerEnter2D(Collider2D other)
    {
        if (collected) return;


        animator.SetBool("collected", true);
        collected = true;
        GameManager.instance.GetFruit(fruitType);
    }
}

public enum FruitType
{
    apple,
    bananas,
    cherries,
    kiwi,
    melon,
    orange,
    pineapple,
    strawberry,
}
