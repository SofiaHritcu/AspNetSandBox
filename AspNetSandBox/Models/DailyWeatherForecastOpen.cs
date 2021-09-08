namespace AspNetSandBox.Models
{
    /// <summary>
    ///   <para>Daily Forecast Open Class.</para>
    /// </summary>
    public class DailyWeatherForecastOpen
    {
        /// <summary>Initializes a new instance of the <see cref="DailyWeatherForecastOpen" /> class.</summary>
        /// <param name="timeFromNow">The time from now.</param>
        /// <param name="dailyTemperature">The daily temperature.</param>
        /// <param name="windSpeed">The wind speed.</param>
        /// <param name="dailyDescription">The daily description.</param>
        /// <param name="dailyIconCode">The daily icon code.</param>
        public DailyWeatherForecastOpen(string timeFromNow, double dailyTemperature, double windSpeed, string dailyDescription, string dailyIconCode)
        {
            TimeFromNow = timeFromNow;
            DailyTemperature = dailyTemperature;
            WindSpeed = windSpeed;
            DailyDescription = dailyDescription;
            DailyIconCode = dailyIconCode;
        }

        /// <summary>Gets or sets the time from now.</summary>
        /// <value>The time from now.</value>
        public string TimeFromNow { get; set; }

        /// <summary>Gets or sets the daily temperature.</summary>
        /// <value>The daily temperature.</value>
        public double DailyTemperature { get; set; }

        /// <summary>Gets or sets the wind speed.</summary>
        /// <value>The wind speed.</value>
        public double WindSpeed { get; set; }

        /// <summary>Gets or sets the daily description.</summary>
        /// <value>The daily description.</value>
        public string DailyDescription { get; set; }

        /// <summary>Gets or sets the daily icon code.</summary>
        /// <value>The daily icon code.</value>
        public string DailyIconCode { get; set; }

        /// <summary>Determines whether the specified <see cref="object" />, is equal to this instance.</summary>
        /// <param name="obj">The <see cref="object" /> to compare with this instance.</param>
        /// <returns>
        ///   <c>true</c> if the specified <see cref="object" /> is equal to this instance; otherwise, <c>false</c>.</returns>
        public override bool Equals(object obj)
        {
            return base.Equals(obj);
        }

        /// <summary>Returns a hash code for this instance.</summary>
        /// <returns>A hash code for this instance, suitable for use in hashing algorithms and data structures like a hash table.</returns>
        public override int GetHashCode()
        {
            return base.GetHashCode();
        }

        /// <summary>Converts to string.</summary>
        /// <returns>A <see cref="string" /> that represents this instance.</returns>
        public override string ToString()
        {
            return "DailyWeatherForecastOpen " + TimeFromNow + " " + WindSpeed + " " + DailyDescription + " " + DailyIconCode;
        }
    }
}
