// --------------------------------------------------------------------------------------------------------------------
// <copyright file="DotNetPhoneNumberAuthentication.cs" company="SDCWORLD">
//   Sourodeep Chatterjee
// </copyright>
// <summary>
//   The dot net phone number authentication.
// </summary>
// --------------------------------------------------------------------------------------------------------------------

namespace BusinessLogicWPF.JsClasses
{
    using BusinessLogicWPF.Properties;

    /// <summary>
    /// The dot net phone number authentication.
    /// </summary>
    public class DotNetPhoneNumberAuthentication
    {
        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetPhoneNumberAuthentication"/> class.
        /// </summary>
        /// <param name="phoneNumber">
        /// The phone number.
        /// </param>
        public DotNetPhoneNumberAuthentication([NotNull] string phoneNumber)
        {
            this.PhoneNumber = phoneNumber;
        }

        /// <summary>
        /// Initializes a new instance of the <see cref="DotNetPhoneNumberAuthentication"/> class.
        /// </summary>
        /// <param name="phoneNumber">
        /// The phone number.
        /// </param>
        /// <param name="otp">
        /// The OTP.
        /// </param>
        public DotNetPhoneNumberAuthentication([NotNull] string phoneNumber, [NotNull]string otp)
        {
            this.PhoneNumber = phoneNumber;
            this.Otp = otp;
        }

        /// <summary>
        /// Gets or sets the phone number.
        /// </summary>
        [NotNull]
        public string PhoneNumber { get; set; }

        /// <summary>
        /// Gets or sets the OTP
        /// </summary>
        [CanBeNull]
        public string Otp { get; set; }
    }
}