using System;

namespace TaylorBank.Configuration
{
    /// <summary>
    /// Project level configuration settings
    /// </summary>
    public static class Settings
    {
        /// <summary>
        /// Customer codes should start from 1001; incremented by 1
        /// </summary>
        public static long BaseCustomerNo { get; set; } = 1000;

        /// <summary>
        /// Account numbers should start from 1000000; incremented by 1
        /// </summary>
        public static long BaseAccountNo { get; set; } = 1000000;
    }
}
