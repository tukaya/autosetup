using System.Collections.Generic;

namespace AutoSetup.CodeAnalyzers
{
    public interface IClassUnderTestNameFinder
    {
        string GetClassUnderTestName(string testClassName);
    }

    public class ClassUnderTestNameFinder : IClassUnderTestNameFinder
    {
        public string GetClassUnderTestName(string testClassName)
        {
            if (string.IsNullOrWhiteSpace(testClassName))
            {
                return null;
            }

            var keys = new List<string> { "UnitTests", "Tests", "Test" };

            foreach (var key in keys)
            {
                var indexKey = testClassName.IndexOf(key);
                if (indexKey > -1)
                {
                    return testClassName.Substring(0, indexKey);
                }
            }

            return testClassName;
        }
    }
}
