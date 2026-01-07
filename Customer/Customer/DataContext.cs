namespace Customer
{
    public class DataContext
    {
        public  List<Lawyer> Lawyers { get; set; }    

        public List<Customer> Customers { get; set; }

        public  List<Meet> Meets {get;set; }

        public DataContext()
        {
            Lawyers = new List<Lawyer> { new Lawyer { Id = 1, Name = "yossef", Age = 40 } };
            Customers = new List<Customer> { new Customer { Id = 1, Name = "sara", Age = 20 } };
            Meets = new List<Meet> { new Meet { CustomerId = 1, LawyerId = 1, Date = DateTime.Now, Hour = 13, Durationofmeeting = 1 } };
        }
    }
}
