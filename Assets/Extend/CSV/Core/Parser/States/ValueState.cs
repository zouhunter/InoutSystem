﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using UnityEngine.EventSystems;
using System;
using System.Collections;
using System.Collections.Generic;

public class ValueState : ParserState
{
    public ValueState(ParserStateMachine machine) : base(machine)
    {
    }

    public override void AnyChar(char ch)
    {
        machine.context.AddChar(ch);
        machine.SetState(machine.ValueState);
    }

    public override void Comma()
    {
        machine.context.AddValue();
        machine.SetState(machine.ValueStartState);

    }

    public override void EndOfLine()
    {
        machine.context.AddValue();
        machine.context.AddLine();
        machine.SetState(machine.LineStartState);
    }

    public override void Quote()
    {
        machine.context.AddChar(ParserStateMachine.QuoteCharacter);
        machine.SetState(machine.ValueState);
    }
}
