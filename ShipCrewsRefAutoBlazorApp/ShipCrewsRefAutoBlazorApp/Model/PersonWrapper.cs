using System.ComponentModel.DataAnnotations;

namespace ShipCrewsRefAutoBlazorApp.Model
{
    public class PersonWrapper
    {
        public int PersonId
        {
            get => servicePerson.PersonId;
            set => servicePerson.PersonId = value;
        }

        // Simon: the default ErrorMessage includes the name
        [Required, MinLength(2), MaxLength(50)]
        public string FirstName
        {
            get => servicePerson.FirstName;
            set => servicePerson.FirstName = value;
        }

        [Required, MinLength(2, ErrorMessage="LastName must be 2 characters or more"), MaxLength(50)]
        public string LastName
        {
            get => servicePerson.LastName;
            set => servicePerson.LastName = value;
        }

        //[Required, Range(1, 3, ErrorMessage = "Please enter a value between 1 and 3 inclusive.")]
        [Required, Range(1, 3)]
        public int RoleId

        {
            get => servicePerson.RoleId ?? -1;
            set => servicePerson.RoleId = value;
        }

        public PersonHacked PersonHacked
        {
            get => servicePerson;
            set => servicePerson = value;
        }

        private PersonHacked servicePerson = new PersonHacked();
    }
}
