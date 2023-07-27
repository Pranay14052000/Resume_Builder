using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace OnlineResumeBuilder.Models
{
    public class CustomValidationAttributes
    {
         [AttributeUsage(AttributeTargets.Property, AllowMultiple = false)]
        public sealed class ValidateFirstName : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string firstName = (string)value;
                    firstName=firstName.Trim();
            
                   if (Regex.Match(firstName,@"^[A-Z][a-zA-Z]*$").Success)


                    {
                        return ValidationResult.Success;
                    }

                    else
                    {
                        return new ValidationResult("Invalid first name");

                    }
                }
               
                return new ValidationResult("Invalid First name.");

            }
        }
        public sealed class ValidateLastName : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string lastName = (string)value;
                    lastName = lastName.Trim();

                    if (Regex.Match(lastName, @"^[A-Z][a-zA-Z]*$").Success)
                    {
                        return ValidationResult.Success;
                    }

                  
                }
                return new ValidationResult("Invalid Last Name");

            }
        }

        public sealed class ValidateBirthDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime birth = Convert.ToDateTime(value);
                    if (birth > DateTime.Now)
                    {
                        return new ValidationResult("Invalid Birthdate.Can't > current date");
                    }

                }
                return ValidationResult.Success;
            }
        }

        public sealed class ValidateAge : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    int age = (int)value;
                  

                    if (age>=0)
                    {
                        return ValidationResult.Success;
                    }


                }
                return new ValidationResult("Invalid Age");

            }
        }


        public sealed class ValidateGender : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string gender = (string)value;
                    gender= gender.Trim();


                    if (gender=="Male" || gender =="Female" || gender=="Others")
                    {
                        return ValidationResult.Success;
                    }


                }
                return new ValidationResult("Invalid Age");

            }
        }

        public sealed class ValidatePhoneNumber : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string phoneNumber = (string)value;
                    phoneNumber = phoneNumber.Trim();


                    if (Regex.Match(phoneNumber, @"^\(?([0-9]{3})\)?[-. ]?([0-9]{3})[-. ]?([0-9]{4})$").Success)
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid phone number");

            }
        }

        public sealed class ValidateAddress : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string address = (string)value;
                    address = address.Trim();


                    if (address!="")
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid address");

            }
        }

        public sealed class ValidateEmail : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string email = (string)value;
                    email = email.Trim();


                    if (Regex.Match(email, @"^[\w-\._\+%]+@(?:[\w-]+\.)+[\w]{2,6}$").Success )
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid Email");

            }
        }

        public sealed class ValidateCountry : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string country = (string)value;
                    country = country.Trim();


                    if (country != "")
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid Country");

            }
        }

        public sealed class ValidateState : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string state = (string)value;
                    state = state.Trim();


                    if (state != "")
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid state");

            }
        }

                public sealed class ValidateCity : ValidationAttribute
                {
                    protected override ValidationResult IsValid(object value, ValidationContext validationContext)
                    {
                        if (value != null)
                        {
                            string city = (string)value;
                            city = city.Trim();


                            if (city != "")
                            {
                                return ValidationResult.Success;
                            }

                        }
                        return new ValidationResult("Invalid city");

                    }
                }

    /*   public sealed class ValidateUserName : ValidationAttribute
       {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {



                if (value != null)
                {
                    string userName = (string)value;
                    userName = userName.Trim();


                    UsersData obj = new UsersData();
                    bool isValid = obj.UserIsPresent(userName);


                    if (!isValid)
                    {


                        if (Regex.Match(userName, @"^[A-Z][a-zA-Z]*$").Success)
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("Invalid username");
                        }

                    }
                    else
                    {

                        return new ValidationResult("Invalid username already exists");

                    }

                }
                return new ValidationResult("Invalid username");

            }
        }*/

        public sealed class ValidateUserName : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {



                if (value != null)
                {
                    string userName = (string)value;
                    userName = userName.Trim();


               

                        if (Regex.Match(userName, @"^[A-Z][a-zA-Z]*$").Success)
                        {
                            return ValidationResult.Success;
                        }
                        else
                        {
                            return new ValidationResult("Invalid username");
                        }

                    }
              

                
                return new ValidationResult("Invalid username");

            }
        }

        public sealed class ValidatePassword : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string password = (string)value;
                    password = password.Trim();


                    if (Regex.Match(password, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").Success)
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid password");

            }
        }

        public sealed class ValidateConfirmPassword : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string confirmPassword = (string)value;
                    confirmPassword = confirmPassword.Trim();


                    if (Regex.Match(confirmPassword, @"^(?=.*[a-z])(?=.*[A-Z])(?=.*\d)(?=.*[@$!%*?&])[A-Za-z\d@$!%*?&]{8,}$").Success)
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid confirmPassword");

            }
        }

        public sealed class ValidateField : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    string filedValue = (string)value;
                    filedValue = filedValue.Trim();


                    if (filedValue != "")
                    {
                        return ValidationResult.Success;
                    }

                }
                return new ValidationResult("Invalid Field");

            }
        }


        public sealed class ValidateDate : ValidationAttribute
        {
            protected override ValidationResult IsValid(object value, ValidationContext validationContext)
            {
                if (value != null)
                {
                    DateTime birth = Convert.ToDateTime(value);
                    if (birth > DateTime.Now)
                    {
                        return new ValidationResult("Invalid date.Can't > current date");
                    }

                }
                return ValidationResult.Success;
            }
        }


    }
}