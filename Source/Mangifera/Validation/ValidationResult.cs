using System.Collections.Generic;

namespace Mangifera.Validation
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
        public IList<string> Errors { get; private set; }

        public ValidationResult()
        {
            Errors = new List<string>();
        }
    }
}
