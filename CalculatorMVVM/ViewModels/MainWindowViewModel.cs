using Prism.Mvvm;
using Prism.Commands;
using System.Windows.Controls;
using System;

namespace CalculatorMVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private string _title;
        public string Title
        {
            get { return _title; }
            set { SetProperty(ref _title, value); }
        }

        private string _Num1 = "0";
        private double _dblnum1 = 0;
        public string Num1
        {
            get => _Num1;
            set {
                double.TryParse(value, out _dblnum1);
                SetProperty(ref _Num1, value);
                AddCommand.RaiseCanExecuteChanged();
                SubCommand.RaiseCanExecuteChanged();
                MultiCommand.RaiseCanExecuteChanged();
                DivideCommand.RaiseCanExecuteChanged();
            }
        }

        public bool blnCanDivide { get; set; }

        private string _Num2 = "0";
        private double _dblnum2 = 0;
        public string Num2
        {
            get => _Num2;
            set
            {
                double.TryParse(value, out _dblnum2);
                SetProperty(ref _Num2, value);
                AddCommand.RaiseCanExecuteChanged();
                SubCommand.RaiseCanExecuteChanged();
                MultiCommand.RaiseCanExecuteChanged();
                DivideCommand.RaiseCanExecuteChanged();
            }
        }

        private string _Result = "";
        public string Result
        {
            get => _Result;
            set => SetProperty(ref _Result, value);
            
        }

        public DelegateCommand AddCommand { get; }
        public DelegateCommand SubCommand { get; }
        public DelegateCommand MultiCommand { get; }
        public DelegateCommand DivideCommand { get; }

        public MainWindowViewModel()
        {
            Title = "Calculator";
            AddCommand = new DelegateCommand(Add, CanCalculate);
            SubCommand = new DelegateCommand(Sub, CanCalculate);
            MultiCommand = new DelegateCommand(Multi, CanCalculate);
            DivideCommand = new DelegateCommand(Divide, CanDivide);
            //DivideCommand = new DelegateCommand(Divide).ObservesCanExecute(() => blnCanDivide);
            
        }

        public void Add()
        {
            Result = (_dblnum1 + _dblnum2).ToString();
        }

        void Sub()
        {
            Result = (_dblnum1 - _dblnum2).ToString();
        }

        void Multi()
        {
            Result = (_dblnum1 * _dblnum2).ToString();
        }

        void Divide()
        {
            Result = (_dblnum1 / _dblnum2).ToString();
        }

        public bool CanCalculate()
        {
            bool problem = !double.TryParse(Num1, out _dblnum1) || !double.TryParse(Num2, out _dblnum2);
            if (problem)
            {
                Result = "Error";
            }
            return !problem;
        }

        public bool CanDivide()
        {
            return CanCalculate() && Num2 != "0";
        }
    }
}
