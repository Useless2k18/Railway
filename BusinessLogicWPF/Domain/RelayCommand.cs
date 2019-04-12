// --------------------------------------------------------------------------------------------------------------------
// <copyright file="RelayCommand.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the RelayCommand type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.Domain
{
    using System;
    using System.Windows.Input;

    using BusinessLogicWPF.Properties;

    /// <inheritdoc />
    /// <summary>
    /// The relay command.
    /// </summary>
    /// <typeparam name="T">
    /// T may be of Type object
    /// </typeparam>
    public class RelayCommand<T> : ICommand
    {
        /// <summary>
        /// The execute.
        /// </summary>
        private readonly Action<T> execute;

        /// <summary>
        /// The can execute.
        /// </summary>
        private readonly Predicate<T> canExecute;

        /// <inheritdoc />
        /// <summary>
        /// Initializes a new instance of the <see cref="T:BusinessLogicWPF.Domain.RelayCommand`1" /> class.
        /// </summary>
        /// <param name="execute">
        /// The execute.
        /// </param>
        public RelayCommand([NotNull] Action<T> execute)
            : this(execute, null)
        {
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="RelayCommand{T}"/> class.
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
        public RelayCommand([NotNull] Action<T> execute, Predicate<T> canExecute)
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
            add => CommandManager.RequerySuggested += value;
            remove => CommandManager.RequerySuggested -= value;
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
            return this.canExecute?.Invoke((T)parameter) ?? true;
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
            this.execute((T)parameter);
        }
    }
}
