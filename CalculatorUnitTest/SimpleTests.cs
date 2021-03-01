using NUnit.Framework;
using CalculatorMVVM.ViewModels;

namespace CalculatorUnitTest
{
    public class Tests
    {
        [Test]
        public void GoodInputAdd()
        {
            var window = new MainWindowViewModel {Num1 = "1", Num2 = "2"};
            window.AddCommand.CanExecute();
            window.AddCommand.Execute();

            var expected = "3";

            Assert.AreEqual(expected, window.Result);
        }
    
        [Test]
        public void BadInputAdd()
        {
            var window = new MainWindowViewModel {Num1 = "a", Num2 = "0"};
            var expected = window.AddCommand.CanExecute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void GoodInputSub()
        {
            var window = new MainWindowViewModel {Num1 = "1", Num2 = "2"};
            window.SubCommand.CanExecute();
            window.SubCommand.Execute();

            var expected = "-1";

            Assert.AreEqual(expected, window.Result);
        }

        [Test]
        public void BadInputSub()
        {
            var window = new MainWindowViewModel {Num1 = "a", Num2 = "0"};
            var expected = window.SubCommand.CanExecute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void GoodInputMulti()
        {
            var window = new MainWindowViewModel {Num2 = "2", Num1 = "2"};
            window.MultiCommand.CanExecute();
            window.MultiCommand.Execute();

            var expected = "4";

            Assert.AreEqual(expected, window.Result);
        }

        [Test]
        public void BadInputMulti()
        {
            var window = new MainWindowViewModel {Num1 = "a", Num2 = "0"};
            var expected = window.MultiCommand.CanExecute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void GoodInputDivide()
        {
            var window = new MainWindowViewModel {Num1 = "1", Num2 = "2"};
            window.DivideCommand.CanExecute();
            window.DivideCommand.Execute();

            var expected = "0.5";

            Assert.AreEqual(expected, window.Result);
        }

        [Test]
        public void BadInputDivide()
        {
            var window = new MainWindowViewModel {Num1 = "a", Num2 = "1"};
            var expected = window.DivideCommand.CanExecute();

            Assert.IsFalse(expected);
        }

        [Test]
        public void BadDivideZero()
        {
            var window = new MainWindowViewModel {Num1 = "1", Num2 = "0"};
            var expected = window.DivideCommand.CanExecute();

            Assert.IsFalse(expected);
        }

    }
}