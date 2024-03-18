using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LicenseHubWF.Presenters.Common
{
    public class ModelDataValidation
    {
        public void Validate(object model)
        {
            string errorMessage = string.Empty;
            List<ValidationResult> results = new List<ValidationResult>();
            ValidationContext context = new ValidationContext(model);

            bool isValid = Validator.TryValidateObject(model, context, results, true);
            if (!isValid)
            {
                foreach (ValidationResult result in results)
                {
                    errorMessage = result.ErrorMessage + "\n";
                }

                throw new Exception(errorMessage);
            }
        }
    }
}
