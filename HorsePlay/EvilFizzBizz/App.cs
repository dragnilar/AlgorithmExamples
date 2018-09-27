namespace EvilFizzBizz
{
    /// <summary>
    /// This is a static class that is used as a singleton to store access to the utility methods and the in memory configuration settings.
    /// </summary>
    public static class App
    {
        public static readonly UtilityMethods Util = new UtilityMethods();

        /// <summary>
        /// This is the class that houses the actual string values for the fizz bizz strings. We can add to this if we desire to
        /// allow for more values. This is not meant to be an example of a good pattern or anything of that nature, this was just done
        /// for the sake of KISS.
        /// </summary>
        private static class FizzBizzValues
        {
            public const string Fizz = "Fizz";
            public const string Bizz = "Bizz";
            public const string FizzBizz = "Fizz Bizz!";
            public const string Pozz = "Pozz!";


            public const string Fuck = "Fuck";
            public const string You = "You";
            public const string FuckYou = "Fuck Yo Fizz Bizz";
            public const string ItsShitty = ", Its Shit";
        }

        /// <summary>
        /// This is the in memory configuration. It is used to keep track of what is currently contained in the string values used for
        /// the fizz bizz game methods.
        /// </summary>
        public static class Config
        {
            public static string FizzBizzString = FizzBizzValues.FizzBizz;
            public static string FizzString = FizzBizzValues.Fizz;
            public static string BizzString = FizzBizzValues.Bizz;
            public static string PozzString = FizzBizzValues.Pozz;
            private static bool _obscene;

            /// <summary>
            /// For fun, this is used to enable or disable using obscenities instead of Fizz, Bizz, Pozz etc...
            /// </summary>
            public static void ToggleObscenities()
            {
                if (_obscene)
                {
                    FizzBizzString = FizzBizzValues.FizzBizz;
                    FizzString = FizzBizzValues.Fizz;
                    BizzString = FizzBizzValues.Bizz;
                    PozzString = FizzBizzValues.Pozz;
                    _obscene = false;
                }
                else
                {
                    FizzBizzString = FizzBizzValues.FuckYou;
                    FizzString = FizzBizzValues.Fuck;
                    BizzString = FizzBizzValues.You;
                    PozzString = FizzBizzValues.ItsShitty;
                    _obscene = true;
                }
            }
        }
    }
}