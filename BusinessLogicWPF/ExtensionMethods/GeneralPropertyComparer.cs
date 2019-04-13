// --------------------------------------------------------------------------------------------------------------------
// <copyright file="GeneralPropertyComparer.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   Defines the GeneralPropertyComparer type.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.ExtensionMethods
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// The general property comparer.
    /// </summary>
    /// <typeparam name="T">
    /// The T
    /// </typeparam>
    /// <typeparam name="TKey">
    /// The TKey
    /// </typeparam>
    public class GeneralPropertyComparer<T, TKey> : IEqualityComparer<T>
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="GeneralPropertyComparer{T,TKey}"/> class.
        /// </summary>
        /// <param name="expr">
        /// The expression.
        /// </param>
        public GeneralPropertyComparer(Func<T, TKey> expr)
        {
            this.Expr = expr;
        }

        /// <summary>
        /// Gets the expression.
        /// </summary>
        private Func<T, TKey> Expr { get; }

        /// <summary>
        /// The equals.
        /// </summary>
        /// <param name="left">
        /// The left.
        /// </param>
        /// <param name="right">
        /// The right.
        /// </param>
        /// <returns>
        /// The <see cref="bool"/>.
        /// </returns>
        public bool Equals(T left, T right)
        {
            var leftProp = this.Expr.Invoke(left);
            var rightProp = this.Expr.Invoke(right);
            if (leftProp == null && rightProp == null)
            {
                return true;
            }

            if (leftProp == null ^ rightProp == null)
            {
                return false;
            }

            return leftProp.Equals(rightProp);
        }

        /// <summary>
        /// The get hash code.
        /// </summary>
        /// <param name="obj">
        /// The object.
        /// </param>
        /// <returns>
        /// The <see cref="int"/>.
        /// </returns>
        public int GetHashCode(T obj)
        {
            var prop = this.Expr.Invoke(obj);
            return prop == null ? 0 : prop.GetHashCode();
        }
    }
}