using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class Bar : UIToolKitRoot
{

    private SurvivalValue survival;
    private Label hpLabel;
    private Label waterLabel;
    private Label o2Label;
    private Label foodLabel;

    private void Awake()
    {
        
        survival = FindObjectOfType<SurvivalValue>();

    }

    protected override void OnEnable()
    {
        
        base.OnEnable();

        hpLabel = rootElement.Q<Label>("HP");
        o2Label = rootElement.Q<Label>("O2");

    }

    private void FixedUpdate()
    {

        hpLabel.text = SetText(survival.hp, "HP");
        o2Label.text = SetText(survival.o2, "O2");

    }

    private string SetText(int value, string name)
    {

        return $"{value}% : {name}";

    }

}
