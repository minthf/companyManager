namespace Domain.Entities
{
    public class Employee
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string Patronymic { get; set; }
        public DateOnly BirthDay { get; set; }

        public Department Department { get; set; }
        public int DepartmentId { get; set; }
    }
}
