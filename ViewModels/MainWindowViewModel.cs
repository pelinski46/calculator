using calculator.Models;
using ReactiveUI;
using System;
using System.Reactive;
using calculator.ViewModels;

namespace calculator.ViewModels;

public class MainWindowViewModel : ViewModelBase
{
#pragma warning disable CA1822 // Mark members as static
    private double firstValue;
    private double secondValue;
    private Operation _operation = Operation.Add;

    public double shownValue
    {
        get => secondValue;
        set => this.RaiseAndSetIfChanged(ref secondValue, value);
    }

    public ReactiveCommand<int, Unit> AddNumberCommand { get; }
    public ReactiveCommand<Unit, Unit> RemoveLastNumberCommand { get; }
    public ReactiveCommand<Operation, Unit> ExecuteOperationCommand { get; }

    public MainWindowViewModel()
    {
        AddNumberCommand = ReactiveCommand.Create<int>(AddNumber);
        ExecuteOperationCommand = ReactiveCommand.Create<Operation>(ExecuteOperation);
        RemoveLastNumberCommand = ReactiveCommand.Create(RemoveLastNumber);
    }

    private void AddNumber(int value)
    {
        shownValue = shownValue * 10 + value;
    }

    public void ClearScreen()
    {
        shownValue = 0;
        _operation = Operation.Add;
        firstValue = 0;
    }

    public void Exit()
    {
        Environment.Exit(0);
    }

    public void RemoveLastNumber()
    {
        shownValue = (long)shownValue / 10;
    }

    private void ExecuteOperation(Operation operation)
    {
        switch (_operation)
        {
            case Operation.Add:
                {
                    firstValue += secondValue;
                    shownValue = 0;
                    break;
                }
            case Operation.Subtract:
                {
                    firstValue -= secondValue;
                    shownValue = 0;
                    break;
                }
            case Operation.Multiply:
                {
                    firstValue *= secondValue;
                    shownValue = 0;
                    break;
                }
            case Operation.Divide:
                {
                    firstValue /= secondValue;
                    shownValue = 0;
                    break;
                }
        }
        if (operation == Operation.Result)
        {
            shownValue = firstValue;
            _operation = Operation.Add;
            firstValue = 0;
        }
        else
        {
            _operation = operation;
        }





















#pragma warning restore CA1822 // Mark members as static
    }
}