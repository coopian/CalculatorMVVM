using Prism.Mvvm;
using Prism.Commands;

namespace CalculatorMVVM.ViewModels
{
    public class MainWindowViewModel : BindableBase
    {
        private double _dblNum1;
        private string _Num1 = "0";
        public string Num1
        {
            get => _Num1;
            set {
                SetProperty(ref _Num1, value);
                AddCommand.RaiseCanExecuteChanged();
                SubCommand.RaiseCanExecuteChanged();
                MultiCommand.RaiseCanExecuteChanged();
                DivideCommand.RaiseCanExecuteChanged();
            }
        }

        private double _dblNum2;
        private string _Num2 = "0";
        public string Num2
        {
            get => _Num2;
            set
            {
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
            AddCommand = new DelegateCommand(Add, CanCalculate);
            SubCommand = new DelegateCommand(Sub, CanCalculate);
            MultiCommand = new DelegateCommand(Multi, CanCalculate);
            //DivideCommand = new DelegateCommand(Divide, CanCalculate);
            DivideCommand = new DelegateCommand(Divide, CanDivide);
        }

        private void Add()
        {
            Result = (_dblNum1 + _dblNum2).ToString();
        }

        private void Sub()
        {
            Result = (_dblNum1 - _dblNum2).ToString();
        }

        private void Multi()
        {
            Result = (_dblNum1 * _dblNum2).ToString();
        }

        private void Divide()
        {
            Result = (_dblNum1 / _dblNum2).ToString();
        }

        public bool CanCalculate()
        {
            var problem = !double.TryParse(Num1, out _dblNum1) || !double.TryParse(Num2, out _dblNum2);

            if (problem)
            {
                Result = "Error";
            }

            return !problem;
        }

        public bool CanDivide()
        {
            var problem = !double.TryParse(Num1, out _dblNum1) || !double.TryParse(Num2, out _dblNum2);

            if (problem)
            {
                return false;
            }
            else if (_dblNum2 == 0.00)
            {
                return false;
            }
            else
            {
                return true;
            }
           
        }
    }
}
