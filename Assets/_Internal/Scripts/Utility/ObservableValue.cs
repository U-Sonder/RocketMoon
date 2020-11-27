using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObservableValue<T>
{
    public event Action<T> OnChangedEvent;

    private T variable;

    public T Value
    {
        get => variable;
        set
        {
            variable = value;
            OnChangedEvent?.Invoke(variable);
        }
    }
}
