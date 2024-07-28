
namespace TrackerLibrary.Models
{
    public class PersonModel
    {
        public int ID { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string EmailAddress { get; set; }
        public string CellPhoneNumber { get; set; }

        public string FullName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }
        }
        private int myVar;
        public int MyProperty
        {
            get { return myVar; }
            set { myVar = value; }
        }
    }
}
