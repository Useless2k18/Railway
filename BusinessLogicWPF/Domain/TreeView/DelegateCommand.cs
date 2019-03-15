// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DelegateCommand.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the RootNodeViewModel type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain.TreeView
{
    using System;
    using System.Windows.Input;

    using BusinessLogicWPF.Annotations;

    /// <inheritdoc />
    /// <summary>
    /// The delegate command.
    /// </summary>
    /// <typeparam name="T">
    /// T is the class type
    /// </typeparam>
    public class DelegateCommand<T> : ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        [CanBeNull]
        private Action<T> execute;

        /// <summary>
        /// The can execute.
        /// </summary>
        [CanBeNull]
        private Func<T, bool> canExecute;

        /// <summary>
        /// Initializes a new instance of the <see cref="DelegateCommand{T}"/> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        /// <param name="canExecute">
        /// The can execute.
        /// </param>
        /// <exception cref="ArgumentNullException">
        /// throws if Argument Null Exception
        /// </exception>
        public DelegateCommand([CanBeNull] Action<T> execute, [CanBeNull] Func<T, bool> canExecute = null)
        {
            this.execute = execute ?? throw new ArgumentNullException("execute");
            this.canExecute = canExecute;
        }

        /// <inheritdoc />
        /// <summary>
        /// The can execute changed.
        /// </summary>
        public event EventHandler CanExecuteChanged
        {
            add
            {
                if (this.canExecute != null)
                {
                    CommandManager.RequerySuggested += value;
                }
            }

            remove
            {
                if (this.canExecute != null)
                {
                    CommandManager.RequerySuggested -= value;
                }
            }
        }

        /// <inheritdoc />
        /// <summary>
        /// The can execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        /// <returns>
        /// The <see cref="T:System.Boolean" />.
        /// </returns>
        public bool CanExecute(object parameter)
        {
            return this.canExecute?.Invoke((T)parameter) != false;
        }

        /// <inheritdoc />
        /// <summary>
        /// The execute.
        /// </summary>
        /// <param name="parameter">
        /// The parameter.
        /// </param>
        public void Execute(object parameter)
        {
            var action = this.execute;
            action?.Invoke((T)parameter);
        }
    }
}
